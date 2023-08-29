using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Currencies;
using AssetLayer.SDK.Users;

namespace AssetLayer.SDK.Apps 
{
    public class App { 
        public string appId { get; set; }
        public string appName { get; set; }
        public string appImage { get; set; }
        public string appBanner { get; set; }
        public string teamId { get; set; }
        public string status { get; set; }
        public long createdAt { get; set; }
        public long updatedAt { get; set; }
        public List<string> slots { get; set; }
        public List<UserAlias> appWallets { get; set; }
        public List<Currency> appCurrencies { get; set; }
        public bool? autoGrantRead { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string handcashAppId { get; set; }
        public List<string> marketCurrencies { get; set; }
    }
    public class AppInfoProps { 
        public string appId { get; set; } 
        public string[] appIds { get; set; }
    }
    public class GetAppResponse : BasicResponse<GetAppResponseBody> { }
    public class GetAppResponseBody { public App app { get; set; } }

    public class GetAppsResponse : BasicResponse<GetAppsResponseBody> { }


    public class GetAppsResponseBody { public App[] app { get; set; } }

    public class AppsRawHandlers
    {
        public Func<AppInfoProps, object, Task<(GetAppResponse, GetAppsResponse)>> Info;
        public Func<AppInfoProps, object, Task<GetAppResponse>> GetApp;
        public Func<AppInfoProps, object, Task<GetAppsResponse>> GetApps;
    }
}
