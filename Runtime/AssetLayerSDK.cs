using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using AssetLayer.SDK.Core.Apps;

namespace AssetLayer.SDK
{
    public class AssetLayerConfig
    {
        public string baseUrl { get; set; } = AssetLayerSDK.APIURL;
        public string appSecret { get; set; }
        public string didToken { get; set; }
    }

    public class AssetLayerSDK
    {
        public static AppsHandler Apps;
        public static string APIURL = "https://api-v2.assetlayer.com/api/v1";
        public static bool Initialized { get; set; }

        public AssetLayerSDK(AssetLayerConfig config = null)
        {
            Initialize(config);
        }

        private static void SetDidToken(string didToken) {
            Apps.SetDidToken(didToken);
            // Assets.SetDidToken(didToken);
            // Collections.SetDidToken(didToken);
            // Currencies.SetDidToken(didToken);
            // Equips.SetDidToken(didToken);
            // Listings.SetDidToken(didToken);
            // Slots.SetDidToken(didToken);
            // Users.SetDidToken(didToken);
        }

        public static void Initialize(AssetLayerConfig config = null)
        {
            config ??= new AssetLayerConfig();
            Debug.Log("AssetLayerSDK Init: " + Initialized);
            Apps = new AppsHandler(config);
            // Assets = new AssetsHandler(config);
            // Collections = new CollectionsHandler(config);
            // Currencies = new CurrenciesHandler(config);
            // Equips = new EquipsHandler(config);
            // Listings = new ListingsHandler(config);
            // Slots = new SlotsHandler(config);
            // Users = new UsersHandler(config);
            Initialized = true;
            Debug.Log("AssetLayerSDK Init2: " + Initialized);
        }

        public static async Task<bool> InitializeUser(string didToken) {
            // BasicResult data = await AssetLayer.Users.Safe.RegisterUser(didToken);
            //if (data.result == null) return false;
            SetDidToken(didToken);
            
            //return data.result;
            return false;
        }
    }
}
