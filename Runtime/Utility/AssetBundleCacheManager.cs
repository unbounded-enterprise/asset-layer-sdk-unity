using System.Collections.Generic;
using UnityEngine;

namespace AssetLayer.Unity
{

    public class AssetBundleCacheManager
    {
        // The instance for the Singleton pattern
        private static AssetBundleCacheManager _instance;



        public static AssetBundleCacheManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AssetBundleCacheManager();
                return _instance;
            }
        }

        // Dictionary to cache downloaded AssetBundles.
        public Dictionary<string, AssetBundle> CachedBundles { get; private set; } = new Dictionary<string, AssetBundle>();
        private Dictionary<string, byte[]> CachedGLBs = new Dictionary<string, byte[]>();

        private LinkedList<string> usageOrder = new LinkedList<string>();
        private int maxCacheSize = 10;  // Default max size of the cache

        public void CacheAssetBundle(string url, AssetBundle bundle)
        {
            if (CachedBundles.ContainsKey(url))
            {
                // Move the item to the end of usageOrder if it is re-cached
                usageOrder.Remove(url);
                usageOrder.AddLast(url);
                CachedBundles[url] = bundle;
            }
            else
            {
                if (CachedBundles.Count >= maxCacheSize)
                {
                    // Evict the least recently used item
                    var oldestUrl = usageOrder.First.Value;
                    UnloadAndRemoveBundle(oldestUrl);
                }
                // Add new bundle to the cache
                CachedBundles[url] = bundle;
                usageOrder.AddLast(url);
            }
        }

        private void UnloadAndRemoveBundle(string url)
        {
            if (CachedBundles.ContainsKey(url))
            {
                CachedBundles[url].Unload(true);
                CachedBundles.Remove(url);
                usageOrder.Remove(url);
            }
        }

        public void CacheGLB(string url, byte[] glbData)
        {
            CachedGLBs[url] = glbData;
        }

        public void SetMaxCacheSize(int size)
        {
            maxCacheSize = size;
        }

        private AssetBundleCacheManager() { }  // Make the constructor private to prevent additional instantiations

        public void CacheGLB(string url, byte[] glbData)
    {
        CachedGLBs[url] = glbData;
    }

        public bool IsAssetCached(string url)
        {
            if (url.EndsWith(".glb"))
            {
                return IsGLBCached(url);
            }
            else
            {
                return CachedBundles.ContainsKey(url);
            }
        }

        // Method to check if a GLB is cached
        public bool IsGLBCached(string url)
    {
        return CachedGLBs.ContainsKey(url);
    }

    // Method to get cached GLB data
    public byte[] GetCachedGLB(string url)
    {
        if (IsGLBCached(url))
        {
            return CachedGLBs[url];
        }
        return null;
    }
    }
}
