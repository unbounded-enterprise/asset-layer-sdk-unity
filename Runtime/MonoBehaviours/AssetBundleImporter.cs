using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using GLTFast;

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

        private static Dictionary<string, TaskCompletionSource<bool>> loadingOperations = new Dictionary<string, TaskCompletionSource<bool>>();



        private ApiManager manager;
        public string AssetId { get; private set; }
        public string defaultAssetId;
        public string bundleExpressionId;
        public string onlyLoadCollectionId;
        private string currentBundleUrl;

        TaskCompletionSource<bool> loadOperation;

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

                currentBundleUrl = bundleUrl;

                if (!loadingOperations.TryGetValue(bundleUrl, out var loadOperation))
                {
                    loadOperation = new TaskCompletionSource<bool>();
                    loadingOperations[bundleUrl] = loadOperation;

                    // Directly proceed to load
                    PerformLoadingOperation(bundleUrl);
                }
                else
                {
                    // Wait for the existing operation to complete
                    await loadOperation.Task;
                    // Re-check if it's now cached after waiting, to decide if loading needs to be initiated again
                    if (!AssetBundleCacheManager.Instance.IsAssetCached(bundleUrl))
                    {
                        // If not cached, it means this GameObject needs to initiate loading
                        PerformLoadingOperation(bundleUrl);
                    }
                    else
                    {
                        // Handle the cached asset without initiating a new load
                        HandleCachedAsset(bundleUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error encountered: {ex.Message}");
                ClearCacheAndRestartProcess();
            }
        }

        private void HandleCachedAsset(string bundleUrl)
        {
            if (bundleUrl.EndsWith(".glb", StringComparison.OrdinalIgnoreCase))
            {
                    byte[] glbData = AssetBundleCacheManager.Instance.GetCachedGLB(bundleUrl);
                    HandleLoadedBundle(glbData);
            }
            else
            {
                    HandleLoadedBundle(AssetBundleCacheManager.Instance.CachedBundles[bundleUrl]);
            }
        }


        private void PerformLoadingOperation(string bundleUrl)
        {
            bundleDownloader.DownloadAndLoadBundle(bundleUrl, HandleLoadedBundle);
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
                    byte[] glbData = www.downloadHandler.data;
                    InstantiateGLBAsync(glbData).ConfigureAwait(false);
                }
            }
        }

        private async Task InstantiateGLBAsync(byte[] glbData)
        {
            if (glbData != null)
            {
                // Destroy existing children before loading the new GLB object
                while (transform.childCount > 0)
                {
                    DestroyImmediate(transform.GetChild(0).gameObject);
                }

                var gltf = new GltfImport();
                bool success = await gltf.LoadGltfBinary(glbData);
                if (success)
                {
                    success = await gltf.InstantiateMainSceneAsync(transform);
                    if (!success)
                    {
                        Debug.LogError("Failed to instantiate GLB main scene");
                    }
                }
                else
                {
                    Debug.LogError("Failed to load GLB from bytes");
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
                AssetBundleCacheManager.Instance.CacheAssetBundle(bundleUrl, bundle);

                ProcessAssetBundle(bundle);
                yield break;
            }
        }

        private async void HandleLoadedBundle(object loadedData)
        {
            
            if (loadedData is AssetBundle loadedBundle)
            {
                // Process the loaded AssetBundle
                ProcessAssetBundle(loadedBundle);
            }
            else if (loadedData is byte[] glbData)
            {
                // Process the GLB data
                await InstantiateGLBAsync(glbData);
            }
            else
            {
                Debug.LogError("Failed to load data as AssetBundle or GLB.");
            }

            if (loadingOperations.TryGetValue(currentBundleUrl, out var loadOperation))
            {
                if (loadOperation != null)
                {
                    try
                    {
                        // Correctly signals the operation as completed.
                        if (!loadOperation.Task.IsCompleted)
                        {
                            loadOperation.SetResult(true);
                        }
                    } catch(Exception ex)
                    {
                        Debug.Log("cant set result: " + ex.Message);
                    }
                    loadingOperations.Remove(currentBundleUrl);
                }
            }
        }


        private async void ProcessAssetBundle(AssetBundle bundle)
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
                /* try
                {
                    bundle.Unload(false);
                }
                catch (Exception ex)
                {
                    Debug.Log("Bundle already unloaded");
                } */ 
                // unloading now handled by AssetBUndleCacheManager
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