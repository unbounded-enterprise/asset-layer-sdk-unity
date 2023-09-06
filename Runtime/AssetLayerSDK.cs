using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using AssetLayer.SDK.Core.Apps;
using AssetLayer.SDK.Core.Assets;
using AssetLayer.SDK.Core.Collections;
using AssetLayer.SDK.Core.Currencies;
using AssetLayer.SDK.Core.Equips;
using AssetLayer.SDK.Core.Listings;
using AssetLayer.SDK.Core.Slots;
using AssetLayer.SDK.Core.Users;

namespace AssetLayer.SDK
{
    public class AssetLayerConfig {
        public string baseUrl { get; set; } = AssetLayerSDK.APIURL;
        public string appSecret { get; set; }
        public string didToken { get; set; }
    }

    public class AssetLayerSDK
    {
        public static AppsHandler Apps;
        public static AssetsHandler Assets;
        public static CollectionsHandler Collections;
        public static CurrenciesHandler Currencies;
        public static EquipsHandler Equips;
        public static ListingsHandler Listings;
        public static SlotsHandler Slots;
        public static UsersHandler Users;

        public static string APIURL = "https://api-v2.assetlayer.com/api/v1";
        public static bool Initialized { get; set; }

        public AssetLayerSDK(AssetLayerConfig config = null) { Initialize(config); }

        public static void Initialize(AssetLayerConfig config = null) {
            config ??= new AssetLayerConfig();

            Apps = new AppsHandler(config);
            Assets = new AssetsHandler(config);
            Collections = new CollectionsHandler(config);
            Currencies = new CurrenciesHandler(config);
            Equips = new EquipsHandler(config);
            Listings = new ListingsHandler(config);
            Slots = new SlotsHandler(config);
            Users = new UsersHandler(config);

            Initialized = true;
        }

        public static bool SetDidToken(string didToken) {
            if (!Initialized) return false;

            Apps.SetDidToken(didToken);
            Assets.SetDidToken(didToken);
            Collections.SetDidToken(didToken);
            Currencies.SetDidToken(didToken);
            Equips.SetDidToken(didToken);
            Listings.SetDidToken(didToken);
            Slots.SetDidToken(didToken);
            Users.SetDidToken(didToken);

            return true;
        }

        public static async Task<bool> InitializeUser(string registeredDidToken) {
            return SetDidToken(registeredDidToken);
        }
    }
}
