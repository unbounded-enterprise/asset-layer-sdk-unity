using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using System;
using static AssetLayer.Unity.ApiManager;
using PimDeWitte.UnityMainThreadDispatcher;
using static AssetLayer.Unity.UtilityFunctions;
using AssetLayer.SDK.Collections;
using Newtonsoft.Json;
using AssetLayer.SDK.Assets;
using AssetLayer.SDK;
using Newtonsoft.Json.Linq;

namespace AssetLayer.Unity
{

    public class Inventory : MonoBehaviour
    {
        public string menuName;
        public bool closeOnSelection = true;

        public bool displayAll = false;

        public bool autoSelect = true;



        private string currentSearchString = "";
        private Coroutine debounceCoroutine = null;
        private InventoryUIManagerUnityUI uiManager;

        private string selectedSlotId;
        private string selectedCollectionId;
        private string selectedAssetId;

        private Asset selectedAsset;
        private Collection selectedCollection;
        private Slot selectedSlot;

        private enum DisplayType { Slots, Collections, Assets }
        private DisplayType currentDisplayType;

        private IEnumerable<Slot> loadedSlots;
        private IEnumerable<Collection> loadedCollections;
        private IEnumerable<Asset> loadedAssets;

        private AssetBundleDownloader bundleDownloader;

        [System.Serializable]
        public class AssetSelectedUnityEvent : UnityEvent<Asset>
        {
        }

        [System.Serializable]
        public class AssetLayerUserIdFetchedUnityEvent : UnityEvent<string>
        {
        }

        public AssetSelectedUnityEvent onAssetSelection;
        public AssetLayerUserIdFetchedUnityEvent onUserIdFetched;

        public string slotId;
        public List<string> slotIds;
        public string assetExpressionId;
        public KeyCode toggleKey = KeyCode.I;
        public bool useToggleKey = true;

        public bool ignoreSavedSelection = false;

        private void Awake()
        {
            bundleDownloader = GetComponent<AssetBundleDownloader>();

        }

        private void Start()
        {
            uiManager = GetComponent<InventoryUIManagerUnityUI>();
            uiManager.UISearchInitiated += OnSearchValueChanged;
            uiManager.UICloseInitiated += HideInventoryUI;
            InventoryUIManagerUnityUI.OnInventoryToggled += ToggleInventoryUI;
            uiManager.UIBackInitiated += BackClickedHandler;
            uiManager.UIAssetSelected += UIAssetSelectedHandler;
            StartCoroutine(GetUserCoroutine());
        }

        private IEnumerator Loading()
        {
            if (string.IsNullOrEmpty(slotId) && displayAll)
            {
                displayAll = false;
            }
            if (string.IsNullOrEmpty(slotId) || displayAll)
            {
                StartCoroutine(DisplaySlots());
            }
            else
            {

                if (loadedSlots == null)
                {
                    Task<IEnumerable<Slot>> fetchTask = FetchSlots();
                    yield return WaitForTask(fetchTask);
                    loadedSlots = fetchTask.Result;

                }
                SelectSlot(slotId);
                // StartCoroutine(DisplayCollectionsForSelectedSlot());
            }
            uiManager.UpdateInventoryTitle(menuName);

        }

        IEnumerator GetUserCoroutine()
        {
            Task<AssetLayer.SDK.Users.User> task = null;
            // Start the asynchronous operation without waiting here.
            try
            {
                ApiManager manager = new ApiManager(); // initializing sdk
                task = AssetLayer.SDK.AssetLayerSDK.Users.GetUser();
            }
            catch (Exception e)
            {
                Debug.Log("Starting GetUser task failed: " + e.Message);
                // Proceed to loading even if starting the task fails.
            }

            // If the task was successfully started, wait for it to complete.
            if (task != null)
            {
                yield return new WaitUntil(() => task.IsCompleted);

                if (task.IsFaulted)
                {
                    Debug.LogError("An error occurred: " + task.Exception.ToString());
                }
                else
                {
                    var user = task.Result;
                    if (user != null && !string.IsNullOrEmpty(user.userId))
                    {
                        PlayerPrefs.SetString("AssetLayerUserId", user.userId); // Use the property to get the value
                        onUserIdFetched.Invoke(user.userId);
                    }
                }
            }

            // Always proceed to Loading, regardless of the outcome above.
            StartCoroutine(Loading());
        }



        private void Update()
        {
            if (useToggleKey && Input.GetKeyDown(toggleKey))
            {
                uiManager.ToggleInventoryUI();
            }
        }

        public async Task<IEnumerable<Asset>> FetchSlotAssets(string slotId)
        {
            ApiManager apiManager = new ApiManager();

            IEnumerable<Asset> slotAssets = await apiManager.GetBalanceOfSlot(slotId);
            return slotAssets;
        }

        private IEnumerator DisplaySlots()
        {
            ApiManager apiManager = new ApiManager();
            currentDisplayType = DisplayType.Slots;

            if (displayAll)
            {

                Task<IEnumerable<Asset>> fetchSlotAssetsTask = FetchSlotAssets(slotId);
                yield return WaitForTask(fetchSlotAssetsTask);
                loadedAssets = fetchSlotAssetsTask.Result;
                // Check if loadedAssets is null or empty
                if (loadedAssets == null || !loadedAssets.Any())
                {
                    Debug.LogWarning("No assets loaded or result is null.");
                    yield break; // Exit the coroutine early if no assets are loaded
                }
                loadedAssets = loadedAssets.OrderByDescending(asset => asset.updatedAt).ToList();
                currentDisplayType = DisplayType.Assets;
                List<UIAsset> convertedUIAssets = new List<UIAsset>();
                foreach (var asset in loadedAssets)
                {
                    convertedUIAssets.Add(UIAsset.ConvertToUIAsset(asset, assetExpressionId));
                }

                IEnumerable<UIAsset> filteredSlotAssets = FilterBySearch(convertedUIAssets, currentSearchString);
                if (uiManager.IsInventoryVisible)
                {
                    uiManager.DisplayUIAssets(filteredSlotAssets);
                }
                string selectionKey = "AssetLayerSelectedAssetId";
                if (PlayerPrefs.HasKey("AssetLayerUserId"))
                {
                    string userId = PlayerPrefs.GetString("AssetLayerUserId");
                    if (!string.IsNullOrEmpty(userId))
                    {
                        selectionKey = "AssetLayerSelectedAssetId" + userId;
                    }
                }
                if ((string.IsNullOrEmpty(PlayerPrefs.GetString(selectionKey)) || ignoreSavedSelection) && filteredSlotAssets.Count() > 0 && autoSelect)
                {
                    UIAssetSelectedHandler(filteredSlotAssets.First(), true);
                }

                yield break;

            }

            if (loadedSlots == null)
            {
                Task<IEnumerable<Slot>> fetchTask = FetchSlots();
                yield return WaitForTask(fetchTask);
                loadedSlots = fetchTask.Result;
            }

            var slots = loadedSlots;

            if (slots == null)
            {
                yield break; // Exit the coroutine early
            }
            List<UIAsset> convertedUISlots = new List<UIAsset>();

            // Only consider slots with slotId present in the slotIds list.
            IEnumerable<Slot> filteredLoadedSlots;
            if (slotIds.Any())
            {
                // If slotIds is not empty, filter the slots based on it.
                filteredLoadedSlots = slots.Where(slot => slotIds.Contains(slot.slotId));
            }
            else
            {
                // If slotIds is empty, use all the loadedSlots.
                filteredLoadedSlots = slots;
            }

            foreach (var slot in filteredLoadedSlots)
            {
                convertedUISlots.Add(UIAsset.ConvertToUIAsset(slot));
            }
            IEnumerable<UIAsset> filteredSlots = FilterBySearch(convertedUISlots, currentSearchString);
            uiManager.DisplayUIAssets(filteredSlots);
        }

        private IEnumerator DisplayCollectionsForSelectedSlot()
        {
            currentDisplayType = DisplayType.Collections;
            Task<IEnumerable<Collection>> fetchTask = FetchCollections(selectedSlot.collections);
            yield return WaitForTask(fetchTask);
            loadedCollections = fetchTask.Result ?? Enumerable.Empty<Collection>(); // Handle potential null

            List<UIAsset> convertedUICollections = new List<UIAsset>();

            foreach (var collection in loadedCollections)
            {
                long collectionBalanceCount = 0;
                Slot collectionSlot = loadedSlots.FirstOrDefault(s => s.slotId == collection.slotId);
                if (collectionSlot == null || collectionSlot.balanceCounts == null)
                {
                    continue;
                }
                if (collectionSlot.balanceCounts.TryGetValue(collection.collectionId, out collectionBalanceCount))
                {
                    convertedUICollections.Add(UIAsset.ConvertToUIAsset(collection, assetExpressionId, (int)collectionBalanceCount));
                }
            }

            IEnumerable<UIAsset> filteredCollections = FilterBySearch(convertedUICollections, currentSearchString);

            uiManager.DisplayUIAssets(filteredCollections);
        }





        private IEnumerator DisplayAssetsForSelectedCollection()
        {
            currentDisplayType = DisplayType.Assets;

            Task<IEnumerable<Asset>> fetchTask = FetchAssetsByCollectionId(selectedCollectionId);
            yield return WaitForTask(fetchTask);
            loadedAssets = fetchTask.Result;
            // Check if loadedAssets is null or empty
                if (loadedAssets == null || !loadedAssets.Any())
                {
                    Debug.LogWarning("No assets loaded or result is null.");
                    yield break; // Exit the coroutine early if no assets are loaded
                }
            List<UIAsset> convertedUIAssets = new List<UIAsset>();
            loadedAssets = loadedAssets.OrderByDescending(asset => asset.updatedAt).ToList();
            foreach (var asset in loadedAssets)
            {
                AssetCacheManager.Instance.AddToCache(asset);
                convertedUIAssets.Add(UIAsset.ConvertToUIAsset(asset, assetExpressionId));
            }

            IEnumerable<UIAsset> filteredAssets = FilterBySearch(convertedUIAssets, currentSearchString);

            uiManager.DisplayUIAssets(filteredAssets);
        }


        public IEnumerable<UIAsset> FilterBySearch(IEnumerable<UIAsset> items, string searchString)
        {
            var loweredSearchString = searchString.ToLower();
            var results = new List<UIAsset>();

            foreach (var item in items)
            {
                if (item.Name.ToLower().Contains(loweredSearchString))
                {
                    results.Add(item);
                }
            }
            return results;
        }


        private IEnumerator DebounceSearch()
        {
            yield return new WaitForSeconds(0.3f);

            switch (currentDisplayType)
            {
                case DisplayType.Slots:
                    yield return StartCoroutine(DisplaySlots());
                    break;

                case DisplayType.Collections:
                    yield return StartCoroutine(DisplayCollectionsForSelectedSlot());
                    break;

                case DisplayType.Assets:
                    if (displayAll)
                    {
                        yield return StartCoroutine(DisplaySlots());
                        break;
                    }
                    yield return StartCoroutine(DisplayAssetsForSelectedCollection());
                    break;
            }

            debounceCoroutine = null;
        }



        private void OnSearchValueChanged(string newValue)
        {
            currentSearchString = newValue;

            if (debounceCoroutine != null)
            {
                StopCoroutine(debounceCoroutine);
            }
            debounceCoroutine = StartCoroutine(DebounceSearch());
        }

        private void BackClickedHandler()
        {
            switch (currentDisplayType)
            {
                case DisplayType.Assets:
                    if (displayAll)
                    {
                        HideInventoryUI();
                        break;
                    }
                    selectedCollectionId = "";
                    SelectCollection(selectedCollectionId);
                    break;

                case DisplayType.Collections:
                    selectedSlotId = "";
                    if (string.IsNullOrEmpty(slotId)) // only show slot selection if slotId was not specified
                    {
                        SelectSlot(selectedSlotId);
                    }
                    else  // a slotId was specified, slot selection should not be shown, closing menu instead
                    {
                        HideInventoryUI();
                    }

                    break;

                case DisplayType.Slots:
                    selectedSlotId = "";
                    HideInventoryUI();
                    break;

                default:
                    HideInventoryUI();
                    break;
            }
        }

        private void UIAssetSelectedHandler(UIAsset asset, bool autoselection = false)
        {

            switch (asset.AssetType)
            {
                case UIAssetType.Slot:
                    SelectSlot(asset.UIAssetId);
                    break;

                case UIAssetType.Collection:
                    SelectCollection(asset.UIAssetId);
                    break;

                case UIAssetType.Asset:

                    Asset selectedAsset = loadedAssets.FirstOrDefault(a => a.assetId == asset.UIAssetId);
                    if (selectedAsset != null)
                    {
                        if (closeOnSelection && !autoselection)
                        {
                            uiManager.HideInventoryUI();
                        }

                        SelectAsset(asset.UIAssetId);
                        if (asset.LoadedAssetBundle == null && asset.LoadedGLBData == null)
                        {
                            string bundleUrl = string.IsNullOrEmpty(assetExpressionId)
                                ? GetExpressionValueAssetBundle(selectedAsset.expressionValues)
                                : GetExpressionValueByExpressionIdAssetBundle(selectedAsset.expressionValues, assetExpressionId);

                            bundleDownloader.DownloadAndLoadBundle(bundleUrl, loadedData =>
                            {
                                // Check if loadedData is an AssetBundle
                                if (loadedData is AssetBundle loadedBundle)
                                {
                                    asset.LoadedAssetBundle = loadedBundle;
                                    onAssetSelection.Invoke(selectedAsset);
                                }
                                // Check if loadedData is a byte array, indicating a GLB file
                                else if (loadedData is byte[] glbData)
                                {
                                    asset.LoadedGLBData = glbData;
                                    onAssetSelection.Invoke(selectedAsset);
                                }
                            }); 
                        }
                        else
                        {
                            onAssetSelection.Invoke(selectedAsset);
                        }
                    }
                    break;

                default:
                    break;
            }
        }



        private void HideInventoryUI()
        {
            uiManager.HideInventoryUI();

        }

        private void ToggleInventoryUI(bool open)
        {
            if (open)
            {
                StartCoroutine(Loading());
            }
        }

        public void SelectSlot(string slotId)
        {
            selectedSlotId = slotId;
            if (string.IsNullOrEmpty(slotId))
            {
                currentDisplayType = DisplayType.Slots;
                selectedSlot = null;
                StartCoroutine(DisplaySlots());
                uiManager.UpdateInventoryTitle(menuName);
            }
            else
            {
                if (loadedSlots != null)
                {
                    currentDisplayType = DisplayType.Collections;
                    selectedSlot = loadedSlots.FirstOrDefault(a => a.slotId == selectedSlotId);
                    if (selectedSlot != null)
                    {
                        uiManager.UpdateInventoryTitle(selectedSlot.slotName);
                    }
                }

                StartCoroutine(DisplayCollectionsForSelectedSlot());
            }
        }

        public void SelectCollection(string collectionId)
        {
            selectedCollectionId = collectionId;
            if (string.IsNullOrEmpty(collectionId))
            {
                selectedCollection = null;
                currentDisplayType = DisplayType.Collections;
                SelectSlot(selectedSlotId);
            }
            else
            {

                if (loadedCollections != null)
                {
                    selectedCollection = loadedCollections.FirstOrDefault(a => a.collectionId == selectedCollectionId);
                    if (selectedCollection != null)
                    {
                        uiManager.UpdateInventoryTitle(selectedCollection.collectionName);
                    }

                }
                currentDisplayType = DisplayType.Assets;
                StartCoroutine(DisplayAssetsForSelectedCollection());


            }

        }

        public void SelectAsset(string assetId)
        {
            selectedAssetId = assetId;
            if (string.IsNullOrEmpty(assetId))
            {
                selectedAsset = null;
                SelectCollection(selectedCollectionId);
            }
            else
            {
                if (loadedAssets != null)
                {
                    selectedAsset = loadedAssets.FirstOrDefault(a => a.assetId == selectedAssetId);
                    uiManager.UpdateInventoryTitle(selectedAsset.collectionName + " #" + selectedAsset.serial);
                }

                // Fetch asset details or handle interactions specific to the selected asset.
            }

        }

        public async Task<IEnumerable<Collection>> FetchCollections(List<string> collectionIds)
        {
            try
            {
                ApiManager manager = new ApiManager();
                IEnumerable<Collection> collectionInfos = await manager.GetCollectionInfo(collectionIds);
                return collectionInfos;
            }
            catch (Exception e)
            {
                Debug.Log("Fetch Collections fail: " + e.Message);
                return null;
            }
        }


        public async Task<IEnumerable<Slot>> FetchSlots()
        {
            ApiManager manager = new ApiManager();
            string[] slotIdArr = await manager.GetAppSlots();
            if (slotIdArr == null || slotIdArr.Length == 0)
            {
                return Enumerable.Empty<Slot>();
            }
            slotIds = new List<string>(slotIdArr);

            

            List<Slot> slots = new List<Slot>();

            foreach (var slotId in slotIds)
            {
                if (string.IsNullOrEmpty(slotId))
                {
                    continue;
                }
                SlotInfo slotInfo = await manager.GetSlotInfo(slotId);
                var slotBalance = await manager.GetAssetBalance(slotId, true, true);
                if (slotInfo != null)
                {
                    slots.Add(new Slot
                    {
                        slotId = slotInfo.slotId,
                        slotName = slotInfo.slotName,
                        slotImage = slotInfo.slotImage,
                        description = slotInfo.description,
                        appId = slotInfo.appId,
                        collections = slotInfo.collections,
                        expression = slotInfo.expressions,
                        balanceCounts = slotBalance as Dictionary<string, long>
                    });
                }
            }

            return slots;
        }

        public async Task<IEnumerable<Asset>> FetchAssetsByCollectionId(string collectionId)
        {
            ApiManager manager = new ApiManager();
            IEnumerable<Asset> collectionAssets = await manager.GetBalanceOfCollection(collectionId);
            return collectionAssets;
        }
    }

    public enum UIAssetType
    {
        Slot,
        Collection,
        Asset
    }

    public enum LoadedAssetType
    {
        None,
        AssetBundle,
        GLB
    }
    public class UIAsset
    {
        public string UIAssetId { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }

        public string AssetBundleURL { get; set; }
        public int CountOrSerial { get; set; }
        public Texture2D LoadedTexture { get; set; }
        public AssetBundle LoadedAssetBundle { get; set; }
        public byte[] LoadedGLBData { get; set; } 
        public UIAssetType AssetType { get; set; }

        public LoadedAssetType LoadedAssetType { get; set; }

        public UIAsset(string id, string name, string url, string assetBundleUrl, int countOrSerial, UIAssetType type)
        {
            UIAssetId = id;
            Name = name;
            ImageURL = url;
            CountOrSerial = countOrSerial;
            AssetType = type;
            AssetBundleURL = assetBundleUrl;
            LoadedAssetType = LoadedAssetType.None;
        }

        public static UIAsset ConvertToUIAsset(Slot slot)
        {
            if (slot == null)
            {
                return null;
            }
            // Sum as long, then safely cast to int, providing a default value of 0 if null
            long balanceCountSumLong = slot.balanceCounts?.Values?.Sum() ?? 0L;
            int balanceCountSum = (int)Math.Min(balanceCountSumLong, int.MaxValue);
            return new UIAsset(slot.slotId, slot.slotName, slot.slotImage, "", balanceCountSum, UIAssetType.Slot);
        }

        public static UIAsset ConvertToUIAsset(Collection collection, string assetExpressionId, int count)
        {
            return new UIAsset(
                collection.collectionId,
                collection.collectionName,
                collection.collectionImage,
                string.IsNullOrEmpty(assetExpressionId)
                ?
                    GetExpressionValueAssetBundle(collection.exampleExpressionValues)
                :
                    GetExpressionValueByExpressionIdAssetBundle(collection.exampleExpressionValues, assetExpressionId),
                count,
                UIAssetType.Collection);
        }

        public static string GetNameOfProperties(Dictionary<string, object> properties)
        {
            var firstPropertyObject = properties.Values.FirstOrDefault() as JObject;

            if (firstPropertyObject != null)
            {
                // Using JObject to get the "name" value
                var name = firstPropertyObject["name"];
                if (name != null)
                {
                    return name.ToString();
                }
            }

            return null; // or some default value if the name isn't found
        }



        public static UIAsset ConvertToUIAsset(Asset asset, string assetExpressionId)
        {

            string name = GetNameOfProperties(asset.properties);


            return new UIAsset(
                asset.assetId,
                name != null ? name : asset.collectionName,
                GetExpressionValue(asset.expressionValues, "Menu View"),
                string.IsNullOrEmpty(assetExpressionId)
                ?
                    GetExpressionValueAssetBundle(asset.expressionValues)
                :
                    GetExpressionValueByExpressionIdAssetBundle(asset.expressionValues, assetExpressionId)
                ,
                (int)asset.serial,
                UIAssetType.Asset);
        }

        public void SetLoadedAssetBundle(AssetBundle assetBundle)
        {
            LoadedAssetBundle = assetBundle;
            LoadedAssetType = LoadedAssetType.AssetBundle;
        }

        // Method to set the loaded GLB data
        public void SetLoadedGLBData(byte[] glbData)
        {
            LoadedGLBData = glbData;
            LoadedAssetType = LoadedAssetType.GLB;
        }
    }
}

