using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetLayerSDK.Core.Apps;

namespace AssetLayerSDK
{
    public class AssetLayerConfig
    {
        public string baseUrl { get; set; } = AssetLayer.ApiURL;
        public string appSecret { get; set; }
        public string didToken { get; set; }
    }

    public class AssetLayer
    {
        public static string ApiURL = "https://api-v2.assetlayer.com/api/v1";
        public static bool Initialized { get; set; }
        public static string didToken { get; set; }
        public static AppsHandler apps { get; set; }

        public AssetLayer(AssetLayerConfig config = null)
        {
            config ??= new AssetLayerConfig();
            apps = new AppsHandler(config);
        }

        public static void Initialize(AssetLayerConfig config = null)
        {
            config ??= new AssetLayerConfig();
            Debug.Log("AssetLayerSDK Init: " + Initialized);
            apps = new AppsHandler(config);
            Initialized = true;
            Debug.Log("AssetLayerSDK Init2: " + Initialized);
        }
    }
}
