using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

namespace AssetLayer.Unity
{

    public class AssetBundleDownloader : MonoBehaviour
    {
        public delegate void AssetBundleDownloadedCallback(object data);

        public void DownloadAndLoadBundle(string bundleUrl, AssetBundleDownloadedCallback callback)
        {
            try
            { 
                if (string.IsNullOrEmpty(bundleUrl))
                {
                    callback?.Invoke(null);
                    return; // Exit early as we don't handle .glb files here
                }

                if (bundleUrl.EndsWith(".glb", StringComparison.OrdinalIgnoreCase))
                {
                    StartCoroutine(DownloadAndCacheGLB(bundleUrl, callback));
                }
                else
                {
                    StartCoroutine(DownloadAndLoadBundleCoroutine(bundleUrl, callback));
                }
            }
            catch (Exception e) // This will catch any other exceptions
            {
                Debug.LogError("Caught Exception: " + e.Message + "\nStackTrace: " + e.StackTrace);
            }
        }


        private IEnumerator DownloadAndLoadBundleCoroutine(string bundleUrl, AssetBundleDownloadedCallback callback)
        {


            if (string.IsNullOrEmpty(bundleUrl))
            {
                Debug.LogError("Bundle URL is null or empty.");
                callback?.Invoke(null); // Invoke callback with null to indicate failure
                yield break;
            }

            if (AssetBundleCacheManager.Instance.CachedBundles.TryGetValue(bundleUrl, out AssetBundle cachedBundle))
            {
                Debug.Log("Bundle is already loaded. Using the cached bundle.");
                callback?.Invoke(cachedBundle); // Invoke callback with the cached bundle
                yield break;
            }

            using (UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(bundleUrl))
            {
                // Send request
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Failed to download AssetBundle" + request.result + request.error);
                    callback?.Invoke(null);  // Invoke callback with null to indicate failure
                    yield break;
                }

                // Load downloaded asset bundle
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
                if (bundle == null)
                {
                    Debug.LogError("Failed to load downloaded AssetBundle");
                    callback?.Invoke(null);  // Invoke callback with null to indicate failure
                    yield break;
                }

                Debug.Log("Successfully downloaded and loaded AssetBundle");

                // Cache bundle
                AssetBundleCacheManager.Instance.CacheAssetBundle(bundleUrl, bundle);

                callback?.Invoke(bundle);  // Invoke callback with the loaded bundle
            }
        }
        private IEnumerator DownloadAndCacheGLB(string glbUrl, AssetBundleDownloadedCallback callback)
        {
            if (AssetBundleCacheManager.Instance.IsGLBCached(glbUrl))
            {
                byte[] cachedGLB = AssetBundleCacheManager.Instance.GetCachedGLB(glbUrl);
                callback?.Invoke(cachedGLB); // Invoke callback with the cached GLB data
                yield break;
            }
            using (UnityWebRequest www = UnityWebRequest.Get(glbUrl))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    // Cache the downloaded GLB file
                    AssetBundleCacheManager.Instance.CacheGLB(glbUrl, www.downloadHandler.data);

                    callback?.Invoke(www.downloadHandler.data);
                }
                else
                {
                    Debug.LogError("Failed to download GLB: " + www.error);
                    callback?.Invoke(null);
                }
            }
        }
    }
}