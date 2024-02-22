using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

namespace AssetLayer.Unity
{

    public class AssetBundleDownloader : MonoBehaviour
    {
        public delegate void AssetBundleDownloadedCallback(AssetBundle bundle);

        public void DownloadAndLoadBundle(string bundleUrl, AssetBundleDownloadedCallback callback)
        {
            if (string.IsNullOrEmpty(bundleUrl) || bundleUrl.EndsWith(".glb", StringComparison.OrdinalIgnoreCase))
            {
                callback?.Invoke(null);
                return; // Exit early as we don't handle .glb files here
            }
            try
            { 
                StartCoroutine(DownloadAndLoadBundleCoroutine(bundleUrl, callback));
            }
            catch (NullReferenceException e)
            {
                Debug.LogError("Caught NullReferenceException: " + e.Message + "\nStackTrace: " + e.StackTrace);
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
                AssetBundleCacheManager.Instance.CachedBundles[bundleUrl] = bundle;

                callback?.Invoke(bundle);  // Invoke callback with the loaded bundle
            }
        }
    }
}