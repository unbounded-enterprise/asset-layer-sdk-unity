using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Currencies;
using AssetLayer.SDK.Slots;
using AssetLayer.SDK.Users;

namespace AssetLayer.SDK.Apps 
{
    public class AppBase {
        public AppBase() { }
        public string appId { get; set; }
        public string appName { get; set; }
        public string appImage { get; set; }
        public string appBanner { get; set; }
        public string teamId { get; set; }
        public string status { get; set; }
        public long createdAt { get; set; }
        public long updatedAt { get; set; }
        public List<string> slots { get; set; }
        public string handcashAppId { get; set; }
    }
    public class App { 
        public App() { }
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
    public class AppIdOnly { 
        public AppIdOnly() { }
        public string appId { get; set; } 
    }
    public class AppWithSlotsWithExpressions : App { 
        public AppWithSlotsWithExpressions() : base() {}
        public new List<SlotWithExpressions> slots { get; set; } 
    }
    public class AppWithListingsCount : AppBase { 
        public AppWithListingsCount() : base() {}
        public int count { get; set; } 
    }


    public class AppInfoProps { 
        public string appId { get; set; } 
        public string[] appIds { get; set; }
    }
    public class GetAppProps { public string appId { get; set; } }
    public class GetAppsProps { public string[] appIds { get; set; } }
    public class AppSlotsProps { 
        public string appId { get; set; } 
        public bool? idOnly { get; set; }
    }
    public class GetAppSlotsProps { public string appId { get; set; } }
    public class AppsWithListingsProps { public bool? idOnly { get; set; } }


    public class GetAppResponse : BasicResponse<GetAppResponseBody> { public GetAppResponse() : base() { } }
    public class GetAppResponseBody { 
        public GetAppResponseBody() { } 
        public App app { get; set; } 
    }
    public class GetAppsResponse : BasicResponse<GetAppsResponseBody> { public GetAppsResponse() : base() { } }
    public class GetAppsResponseBody { 
        public GetAppsResponseBody() { }
        public List<App> app { get; set; } 
    }
    public class GetAppSlotsResponse : BasicResponse<GetAppSlotsResponseBody> { public GetAppSlotsResponse() : base() { } }
    public class GetAppSlotsResponseBody { 
        public GetAppSlotsResponseBody() { }
        public AppWithSlotsWithExpressions app { get; set; } 
    }
    public class GetAppSlotIdsResponse : BasicResponse<GetAppSlotIdsResponseBody> { public GetAppSlotIdsResponse() : base() { } }
    public class GetAppSlotIdsResponseBody { 
        public GetAppSlotIdsResponseBody() { }
        public App app { get; set; } 
    }
    public class GetAppsWithListingsResponse : BasicResponse<GetAppsWithListingsResponseBody> { public GetAppsWithListingsResponse() : base() { } }
    public class GetAppsWithListingsResponseBody { 
        public GetAppsWithListingsResponseBody() { }
        public List<AppWithListingsCount> apps { get; set; } 
    }
    public class GetAppIdsWithListingsResponse : BasicResponse<GetAppIdsWithListingsResponseBody> { public GetAppIdsWithListingsResponse() : base() { } }
    public class GetAppIdsWithListingsResponseBody { 
        public GetAppIdsWithListingsResponseBody() { }
        public List<AppIdOnly> apps { get; set; } 
    }


    public class AppsRawHandlers
    {
        public Func<AppInfoProps, object, Task<(GetAppResponse, GetAppsResponse)>> Info;
        public Func<GetAppProps, object, Task<GetAppResponse>> GetApp;
        public Func<GetAppsProps, object, Task<GetAppsResponse>> GetApps;
        public Func<AppSlotsProps, object, Task<(GetAppSlotsResponse, GetAppSlotIdsResponse)>> Slots;
        public Func<GetAppSlotsProps, object, Task<GetAppSlotsResponse>> GetAppSlots;
        public Func<GetAppSlotsProps, object, Task<GetAppSlotIdsResponse>> GetAppSlotIds;
        public Func<AppsWithListingsProps, object, Task<(GetAppsWithListingsResponse, GetAppIdsWithListingsResponse)>> Listings;
        public Func<object, Task<GetAppsWithListingsResponse>> GetAppsWithListings;
        public Func<object, Task<GetAppIdsWithListingsResponse>> GetAppIdsWithListings;
    }

    public class AppsSafeHandlers
    {
        public Func<AppInfoProps, Dictionary<string, string>, Task<BasicResult<(App, List<App>)>>> Info;
        /*
        public Func<GetAppProps, object, Task<BasicResult<App>>> GetApp;
        public Func<GetAppsProps, object, Task<BasicResult<App[]>>> GetApps;
        public Func<AppSlotsProps, object, Task<BasicResult<(SlotWithExpressions[], string[])>>> Slots;
        public Func<GetAppSlotsProps, object, Task<BasicResult<SlotWithExpressions[]>>> GetAppSlots;
        public Func<GetAppSlotsProps, object, Task<BasicResult<string[]>>> GetAppSlotIds;
        public Func<AppsWithListingsProps, object, Task<BasicResult<(AppWithListingsCount[], AppIdOnly[])>>> Listings;
        public Func<object, Task<BasicResult<AppWithListingsCount[]>>> GetAppsWithListings;
        public Func<object, Task<BasicResult<AppIdOnly[]>>> GetAppIdsWithListings;
        */
    }
}
