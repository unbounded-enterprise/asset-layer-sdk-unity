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
