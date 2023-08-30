using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Currencies;
using AssetLayer.SDK.Slots;
using AssetLayer.SDK.Users;

namespace AssetLayer.SDK.Apps 
{
    public class AppBase {
        [DataMember]
        public string appId { get; set; }
        [DataMember]
        public string appName { get; set; }
        [DataMember]
        public string appImage { get; set; }
        [DataMember]
        public string appBanner { get; set; }
        [DataMember]
        public string teamId { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public long createdAt { get; set; }
        [DataMember]
        public long updatedAt { get; set; }
        [DataMember]
        public List<string> slots { get; set; }
        [DataMember]
        public string handcashAppId { get; set; }
    }
    [DataContract]
    public class App { 
        [DataMember]
        public string appId { get; set; }
        [DataMember]
        public string appName { get; set; }
        [DataMember]
        public string appImage { get; set; }
        [DataMember]
        public string appBanner { get; set; }
        [DataMember]
        public string teamId { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public long createdAt { get; set; }
        [DataMember]
        public long updatedAt { get; set; }
        [DataMember]
        public List<string> slots { get; set; }
        [DataMember]
        public List<UserAlias> appWallets { get; set; }
        [DataMember]
        public List<Currency> appCurrencies { get; set; }
        [DataMember]
        public bool? autoGrantRead { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string handcashAppId { get; set; }
        [DataMember]
        public List<string> marketCurrencies { get; set; }
    }
    [DataContract]
    public class AppIdOnly { 
        [DataMember]
        public string appId { get; set; } 
    }
    [DataContract]
    public class AppWithSlotsWithExpressions : App { 
        [DataMember]
        public new List<SlotWithExpressions> slots { get; set; } 
    }
    [DataContract]
    public class AppWithListingsCount : AppBase { 
        [DataMember]
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


    [DataContract]
    public class GetAppResponse : BasicResponse<GetAppResponseBody> { }
    [DataContract]
    public class GetAppResponseBody { 
        [DataMember]
        public App app { get; set; } 
    }
    [DataContract]
    public class GetAppsResponse : BasicResponse<GetAppsResponseBody> { }
    [DataContract]
    public class GetAppsResponseBody { 
        [DataMember]
        public List<App> app { get; set; } 
    }
    [DataContract]
    public class GetAppSlotsResponse : BasicResponse<GetAppSlotsResponseBody> { }
    [DataContract]
    public class GetAppSlotsResponseBody { 
        [DataMember]
        public AppWithSlotsWithExpressions app { get; set; } 
    }
    [DataContract]
    public class GetAppSlotIdsResponse : BasicResponse<GetAppSlotIdsResponseBody> { }
    [DataContract]
    public class GetAppSlotIdsResponseBody { 
        [DataMember]
        public App app { get; set; } 
    }
    [DataContract]
    public class GetAppsWithListingsResponse : BasicResponse<GetAppsWithListingsResponseBody> { }
    [DataContract]
    public class GetAppsWithListingsResponseBody { 
        [DataMember]
        public List<AppWithListingsCount> apps { get; set; } 
    }
    [DataContract]
    public class GetAppIdsWithListingsResponse : BasicResponse<GetAppIdsWithListingsResponseBody> { }
    [DataContract]
    public class GetAppIdsWithListingsResponseBody { 
        [DataMember]
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
