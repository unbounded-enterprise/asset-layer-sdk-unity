using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using Siccity.GLTFUtility;

namespace AssetLayer.Unity
{

    public static class AssetBundleRequestExtensions
    {
        public static TaskAwaiter<UnityEngine.Object[]> GetAwaiter(this AssetBundleRequest request)
        {
            var tcs = new TaskCompletionSource<UnityEngine.Object[]>();

            request.completed += _ => tcs.TrySetResult(request.allAssets);

            return ((Task<UnityEngine.Object[]>)tcs.Task).GetAwaiter();
        }
    }

    public class AssetBundleImporter : MonoBehaviour
    {
        private ApiManager manager;
        public string AssetId { get; private set; }
        public string defaultAssetId;
        public string bundleExpressionId;
        public string onlyLoadCollectionId;

        private AssetBundleDownloader bundleDownloader;

        private void Awake()
        {
            bundleDownloader = GetComponent<AssetBundleDownloader>();
        }

        private void Initialize()
        {
            manager = new ApiManager();
        }

        private void Start()
        {
            if (!string.IsNullOrEmpty(defaultAssetId))
            {
                SetNftId(defaultAssetId);
            }
        }

        public void SetNftId(string newNftId)
        {
            this.AssetId = newNftId;
            if (!string.IsNullOrEmpty(newNftId))
            {
                Initialize();
                StartProcess();
            }
        }

        public void SetNewAsset(Asset asset)
        {
            this.AssetId = asset.assetId;
            if (!string.IsNullOrEmpty(onlyLoadCollectionId))
            {
                if (asset.collectionId != onlyLoadCollectionId)
                {
                    return;
                }
            }
            if (!string.IsNullOrEmpty(this.AssetId))
            {
                string selectionKey = "AssetLayerSelectedAssetId";
                if (PlayerPrefs.HasKey("AssetLayerUserId"))
                {
                    string userId = PlayerPrefs.GetString("AssetLayerUserId");
                    if (!string.IsNullOrEmpty(userId))
                    {
                        selectionKey = "AssetLayerSelectedAssetId" + userId;
                    }
                }
                PlayerPrefs.SetString(selectionKey, asset.assetId);
                PlayerPrefs.Save();
                Initialize();
                StartProcess();
            }
        }

        private void StartProcess()
        {
            if (AssetCacheManager.Instance.IsInCache(AssetId))
            {
                Asset cachedAsset = AssetCacheManager.Instance.GetFromCache(AssetId);
                string bundleUrl = string.IsNullOrEmpty(bundleExpressionId) ?
                    UtilityFunctions.GetExpressionValueAssetBundle(cachedAsset.expressionValues)
                    :
                    UtilityFunctions.GetExpressionValueByExpressionIdAssetBundle(cachedAsset.expressionValues, bundleExpressionId);
                ApplyObj(bundleUrl);
            }
            else
            {
                StartCoroutine(manager.GetAssetExpressionValue(AssetId, ApplyObj)); // replace this later with sdk method to get an Asset, cache that, then load 
            }

        }
        private async void ApplyObj(string bundleUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(bundleUrl))
                {
                    ClearCacheAndRestartProcess();
                    return;
                }

                // Determine if the URL ends with .glb and handle accordingly
                if (bundleUrl.EndsWith(".glb", StringComparison.OrdinalIgnoreCase))
                {
                    if (AssetBundleCacheManager.Instance.IsGLBCached(bundleUrl))
                    {
                        InstantiateGLBFromCache(bundleUrl);
                    }
                    else
                    {
                        LoadGLBAsset(bundleUrl); // Handle GLB loading
                    }
                }
                else
                {
                    // Existing asset bundle handling logic...
                    if (AssetBundleCacheManager.Instance.CachedBundles.ContainsKey(bundleUrl) && AssetBundleCacheManager.Instance.CachedBundles[bundleUrl] != null)
                    {
                        HandleLoadedBundle(AssetBundleCacheManager.Instance.CachedBundles[bundleUrl]);
                    }
                    else
                    {
                        bundleDownloader.DownloadAndLoadBundle(bundleUrl, HandleLoadedBundle);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error encountered: {ex.Message}");
                ClearCacheAndRestartProcess();
            }
        }

        // Method to load a GLB file and instantiate it
        private void LoadGLBAsset(string glbUrl)
        {
            StartCoroutine(DownloadAndInstantiateGLB(glbUrl));
        }

        // Coroutine to download and instantiate GLB
        private IEnumerator DownloadAndInstantiateGLB(string glbUrl)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(glbUrl))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Failed to download GLB: " + www.error);
                }
                else
                {
                    // Destroy existing children before loading the new GLB object
                    while (transform.childCount > 0)
                    {
                        DestroyImmediate(transform.GetChild(0).gameObject);
                    }
                    // Load the GLB data and instantiate the object
                    var glbObject = Importer.LoadFromBytes(www.downloadHandler.data);
                    if (glbObject != null)
                    {
                        glbObject.transform.SetParent(this.transform, false);
                        Debug.Log("GLB downloaded and loaded successfully");
                    }
                    else
                    {
                        Debug.LogError("Failed to load GLB as GameObject");
                    }
                }
            }
        }

        private void ClearCacheAndRestartProcess()
        {
            ClearCacheEntry(AssetId); // Clear the problematic cache entry
            StartProcess(); // Restart the process
        }

        private void ClearCacheEntry(string assetId)
        {
            // Use the existing method to remove the asset from the cache
            AssetCacheManager.Instance.RemoveFromCache(assetId);
        }


        IEnumerator DownloadAndLoadBundleCoroutine(string bundleUrl)
        {
                if (string.IsNullOrEmpty(bundleUrl))
                {
                    HandleLoadedBundle(null);
                    yield break;
                }
            using (UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(bundleUrl))
            {
                // Send request
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Failed to download AssetBundle: " + request.error);
                    yield break;
                }

                // Load downloaded asset bundle
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
                if (bundle == null)
                {
                    Debug.LogError("Failed to load downloaded AssetBundle");
                    yield break;
                }

                Debug.Log("Successfully downloaded and loaded AssetBundle");

                // Cache bundle
                AssetBundleCacheManager.Instance.CachedBundles[bundleUrl] = bundle;

                HandleLoadedBundle(bundle);
                yield break;
            }
        }
        private async void HandleLoadedBundle(AssetBundle bundle)
        {
            if (bundle == null)
            {
                return;
            }
            if (bundle.isStreamedSceneAssetBundle)
            {
                Debug.Log("loaded bundle is a scene");
                return;
            }

            // Load assets asynchronously
            AssetBundleRequest request = bundle.LoadAllAssetsAsync();
            await request; // Wait until assets are loaded

            UnityEngine.Object[] allAssets = request.allAssets;
            if (allAssets != null && allAssets.Length > 0)
            {
                foreach (UnityEngine.Object asset in allAssets)
                {
                    // Handle each asset
                    if (asset is GameObject)
                    {
                        Debug.Log($"Processing GameObject asset: {asset.name}");

                        GameObject prefab = asset as GameObject;
                        // Instantiate a new gameobject from the imported prefab as a child of the gameobject, deletes the first child (previous character loaded)
                        SwitchOutGameObject(this.gameObject, prefab);
                    }
                    else
                    {
                        Debug.LogWarning($"Asset {asset.name} is not a GameObject");
                    }
                }
                bundle.Unload(false);
            }
            else
            {
                Debug.LogError($"Failed to load assets from asset bundle");
            }
        }

        public static void SwitchOutGameObject(GameObject AssetlayerGameObjectToSwitchOnChange, GameObject prefab)
        {
            // Destroy the first child if it exists
            if (AssetlayerGameObjectToSwitchOnChange.transform.childCount > 0)
            {
                Transform firstChild = AssetlayerGameObjectToSwitchOnChange.transform.GetChild(0);
                Destroy(firstChild.gameObject);
            }
            // Instantiate the new prefab as a child
            GameObject newObject = Instantiate(prefab, AssetlayerGameObjectToSwitchOnChange.transform.position, AssetlayerGameObjectToSwitchOnChange.transform.rotation, AssetlayerGameObjectToSwitchOnChange.transform);
            newObject.transform.localRotation = prefab.transform.rotation;
        }
    }
}