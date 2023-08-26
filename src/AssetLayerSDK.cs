using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using AssetLayerSDK.Core.Apps;

namespace AssetLayerSDK
{
    public class AssetLayerConfig
    {
        public string baseUrl = AssetLayer.ApiURL;
        public string appSecret;
        public string didToken;
    }

    public class AssetLayer
    {
        public static string ApiURL = "https://api-v2.assetlayer.com/api/v1";
        public static bool Initialized;
        public static AppsHandler apps;

        public AssetLayer(AssetLayerConfig config = null)
        {
            Initialize(config);
        }

        private static void SetDidToken(string didToken) {
            apps.setDidToken(didToken);
            // assets.setDidToken(didToken);
            // collections.setDidToken(didToken);
            // currencies.setDidToken(didToken);
            // equips.setDidToken(didToken);
            // listings.setDidToken(didToken);
            // slots.setDidToken(didToken);
            // users.setDidToken(didToken);
        }

        public static void Initialize(AssetLayerConfig config = null)
        {
            config ??= new AssetLayerConfig();
            Debug.Log("AssetLayerSDK Init: " + Initialized);
            apps = new AppsHandler(config);
            // assets = new AssetsHandler(config);
            // collections = new CollectionsHandler(config);
            // currencies = new CurrenciesHandler(config);
            // equips = new EquipsHandler(config);
            // listings = new ListingsHandler(config);
            // slots = new SlotsHandler(config);
            // users = new UsersHandler(config);
            Initialized = true;
            Debug.Log("AssetLayerSDK Init2: " + Initialized);
        }

        public static async Task<bool> InitializeUser(string didToken) {
            // BasicResult data = await AssetLayer.users.safe.RegisterUser(didToken);
            //if (data.result == null) return false;
            SetDidToken(didToken);
            
            //return data.result;
            return false;
        }
    }
}
