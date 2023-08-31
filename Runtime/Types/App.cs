using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Currencies;
using AssetLayer.SDK.Slots;
using AssetLayer.SDK.Users;
#if UNITY_WEBGL
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Apps 
{
    public class AppBase {
        public AppBase() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string appName { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string appImage { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string appBanner { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string teamId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long createdAt { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long updatedAt { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> slots { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string handcashAppId { get; set; }
    }
    [DataContract]
    public class App { 
        public App() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string appName { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string appImage { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string appBanner { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string teamId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long createdAt { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long updatedAt { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> slots { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<UserAlias> appWallets { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<Currency> appCurrencies { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? autoGrantRead { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string description { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string url { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string handcashAppId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> marketCurrencies { get; set; }
    }
    [DataContract]
    public class AppIdOnly { 
        public AppIdOnly() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; } 
    }
    [DataContract]
    public class AppWithSlotsWithExpressions : App { 
        public AppWithSlotsWithExpressions() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public new List<SlotWithExpressions> slots { get; set; } 
    }
    [DataContract]
    public class AppWithListingsCount : AppBase { 
        public AppWithListingsCount() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public int count { get; set; } 
    }


    public class AppInfoProps { 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        public string appId { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        public string[] appIds { get; set; }
    }
    public class GetAppProps { 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        public string appId { get; set; } 
    }
    public class GetAppsProps { 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        public string[] appIds { get; set; } 
    }
    public class AppSlotsProps { 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        public string appId { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        public bool? idOnly { get; set; }
    }
    public class GetAppSlotsProps { 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        public string appId { get; set; } 
    }
    public class AppsWithListingsProps { 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        public bool? idOnly { get; set; } 
    }


    [DataContract]
    public class GetAppResponse : BasicResponse<GetAppResponseBody> { public GetAppResponse() : base() { } }
    [DataContract]
    public class GetAppResponseBody { 
        public GetAppResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public App app { get; set; } 
    }
    [DataContract]
    public class GetAppsResponse : BasicResponse<GetAppsResponseBody> { public GetAppsResponse() : base() { } }
    [DataContract]
    public class GetAppsResponseBody { 
        public GetAppsResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<App> app { get; set; } 
    }
    [DataContract]
    public class GetAppSlotsResponse : BasicResponse<GetAppSlotsResponseBody> { public GetAppSlotsResponse() : base() { } }
    [DataContract]
    public class GetAppSlotsResponseBody { 
        public GetAppSlotsResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public AppWithSlotsWithExpressions app { get; set; } 
    }
    [DataContract]
    public class GetAppSlotIdsResponse : BasicResponse<GetAppSlotIdsResponseBody> { public GetAppSlotIdsResponse() : base() { } }
    [DataContract]
    public class GetAppSlotIdsResponseBody { 
        public GetAppSlotIdsResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public App app { get; set; } 
    }
    [DataContract]
    public class GetAppsWithListingsResponse : BasicResponse<GetAppsWithListingsResponseBody> { public GetAppsWithListingsResponse() : base() { } }
    [DataContract]
    public class GetAppsWithListingsResponseBody { 
        public GetAppsWithListingsResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<AppWithListingsCount> apps { get; set; } 
    }
    [DataContract]
    public class GetAppIdsWithListingsResponse : BasicResponse<GetAppIdsWithListingsResponseBody> { public GetAppIdsWithListingsResponse() : base() { } }
    [DataContract]
    public class GetAppIdsWithListingsResponseBody { 
        public GetAppIdsWithListingsResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<AppIdOnly> apps { get; set; } 
    }


    public class AppsRawHandlers
    {
        public Func<AppInfoProps, Dictionary<string, string>, Task<(GetAppResponse, GetAppsResponse)>> Info;
        public Func<GetAppProps, Dictionary<string, string>, Task<GetAppResponse>> GetApp;
        public Func<GetAppsProps, Dictionary<string, string>, Task<GetAppsResponse>> GetApps;
        public Func<AppSlotsProps, Dictionary<string, string>, Task<(GetAppSlotsResponse, GetAppSlotIdsResponse)>> Slots;
        public Func<GetAppSlotsProps, Dictionary<string, string>, Task<GetAppSlotsResponse>> GetAppSlots;
        public Func<GetAppSlotsProps, Dictionary<string, string>, Task<GetAppSlotIdsResponse>> GetAppSlotIds;
        public Func<AppsWithListingsProps, Dictionary<string, string>, Task<(GetAppsWithListingsResponse, GetAppIdsWithListingsResponse)>> Listings;
        public Func<Dictionary<string, string>, Task<GetAppsWithListingsResponse>> GetAppsWithListings;
        public Func<Dictionary<string, string>, Task<GetAppIdsWithListingsResponse>> GetAppIdsWithListings;
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
