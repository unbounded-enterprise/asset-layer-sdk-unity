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
        [Preserve][DataMember]
        public string appId { get; set; }
        [Preserve][DataMember]
        public string appName { get; set; }
        [Preserve][DataMember]
        public string appImage { get; set; }
        [Preserve][DataMember]
        public string appBanner { get; set; }
        [Preserve][DataMember]
        public string teamId { get; set; }
        [Preserve][DataMember]
        public string status { get; set; }
        [Preserve][DataMember]
        public long createdAt { get; set; }
        [Preserve][DataMember]
        public long updatedAt { get; set; }
        [Preserve][DataMember]
        public List<string> slots { get; set; }
        [Preserve][DataMember]
        public string handcashAppId { get; set; }
    }
    [DataContract]
    public class App { 
        public App() { }
        [Preserve][DataMember]
        public string appId { get; set; }
        [Preserve][DataMember]
        public string appName { get; set; }
        [Preserve][DataMember]
        public string appImage { get; set; }
        [Preserve][DataMember]
        public string appBanner { get; set; }
        [Preserve][DataMember]
        public string teamId { get; set; }
        [Preserve][DataMember]
        public string status { get; set; }
        [Preserve][DataMember]
        public long createdAt { get; set; }
        [Preserve][DataMember]
        public long updatedAt { get; set; }
        [Preserve][DataMember]
        public List<string> slots { get; set; }
        [Preserve][DataMember]
        public List<UserAlias> appWallets { get; set; }
        [Preserve][DataMember]
        public List<Currency> appCurrencies { get; set; }
        [Preserve][DataMember]
        public bool? autoGrantRead { get; set; }
        [Preserve][DataMember]
        public string description { get; set; }
        [Preserve][DataMember]
        public string url { get; set; }
        [Preserve][DataMember]
        public string handcashAppId { get; set; }
        [Preserve][DataMember]
        public List<string> marketCurrencies { get; set; }
    }
    [DataContract]
    public class AppIdOnly { 
        public AppIdOnly() { }
        [Preserve][DataMember]
        public string appId { get; set; } 
    }
    [DataContract]
    public class AppWithSlotsWithExpressions : App { 
        public AppWithSlotsWithExpressions() : base() { }
        [Preserve][DataMember]
        public new List<SlotWithExpressions> slots { get; set; } 
    }
    [DataContract]
    public class AppWithListingsCount : AppBase { 
        public AppWithListingsCount() : base() { }
        [Preserve][DataMember]
        public int count { get; set; } 
    }


    public class AppInfoProps { 
        [Preserve] public string appId { get; set; } 
        [Preserve] public string[] appIds { get; set; }
    }
    public class GetAppProps { [Preserve] public string appId { get; set; } }
    public class GetAppsProps { [Preserve] public string[] appIds { get; set; } }
    public class AppSlotsProps { 
        [Preserve] public string appId { get; set; } 
        [Preserve] public bool? idOnly { get; set; }
    }
    public class GetAppSlotsProps { [Preserve] public string appId { get; set; } }
    public class AppsWithListingsProps { [Preserve] public bool? idOnly { get; set; } }


    [DataContract]
    public class GetAppResponse : BasicResponse<GetAppResponseBody> { public GetAppResponse() : base() { } }
    [DataContract]
    public class GetAppResponseBody { 
        public GetAppResponseBody() { }
        [Preserve][DataMember]
        public App app { get; set; } 
    }
    [DataContract]
    public class GetAppsResponse : BasicResponse<GetAppsResponseBody> { public GetAppsResponse() : base() { } }
    [DataContract]
    public class GetAppsResponseBody { 
        public GetAppsResponseBody() { }
        [Preserve][DataMember]
        public List<App> app { get; set; } 
    }
    [DataContract]
    public class GetAppSlotsResponse : BasicResponse<GetAppSlotsResponseBody> { public GetAppSlotsResponse() : base() { } }
    [DataContract]
    public class GetAppSlotsResponseBody { 
        public GetAppSlotsResponseBody() { }
        [Preserve][DataMember]
        public AppWithSlotsWithExpressions app { get; set; } 
    }
    [DataContract]
    public class GetAppSlotIdsResponse : BasicResponse<GetAppSlotIdsResponseBody> { public GetAppSlotIdsResponse() : base() { } }
    [DataContract]
    public class GetAppSlotIdsResponseBody { 
        public GetAppSlotIdsResponseBody() { }
        [Preserve][DataMember]
        public App app { get; set; } 
    }
    [DataContract]
    public class GetAppsWithListingsResponse : BasicResponse<GetAppsWithListingsResponseBody> { public GetAppsWithListingsResponse() : base() { } }
    [DataContract]
    public class GetAppsWithListingsResponseBody { 
        public GetAppsWithListingsResponseBody() { }
        [Preserve][DataMember]
        public List<AppWithListingsCount> apps { get; set; } 
    }
    [DataContract]
    public class GetAppIdsWithListingsResponse : BasicResponse<GetAppIdsWithListingsResponseBody> { public GetAppIdsWithListingsResponse() : base() { } }
    [DataContract]
    public class GetAppIdsWithListingsResponseBody { 
        public GetAppIdsWithListingsResponseBody() { }
        [Preserve][DataMember]
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
