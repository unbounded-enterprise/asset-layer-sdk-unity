using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Currencies;
using AssetLayer.SDK.Slots;
using AssetLayer.SDK.Users;

#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Apps 
{
    [DataContract]
    public class AppCore {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public AppCore() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appName { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appImage { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appBanner { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string teamId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long createdAt { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long updatedAt { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string handcashAppId { get; set; }
    }
    [DataContract]
    public class AppBase : AppCore {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public AppBase() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> slots { get; set; }
    }
    [DataContract]
    public class AppExtendedCore : AppCore { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public AppExtendedCore() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<UserAlias> appWallets { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<Currency> appCurrencies { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? autoGrantRead { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string description { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string url { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> marketCurrencies { get; set; }
    }
    [DataContract]
    public class App : AppExtendedCore {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public App() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> slots { get; set; }
    }
    [DataContract]
    public class AppIdOnly { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public AppIdOnly() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; } 
    }
    [DataContract]
    public class AppWithSlotsWithExpressions : AppExtendedCore { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public AppWithSlotsWithExpressions() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<SlotWithExpressions> slots { get; set; } 
    }
    [DataContract]
    public class AppWithListingsCount : AppBase { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public AppWithListingsCount() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public int count { get; set; } 
    }


    [DataContract]
    public class AppInfoProps { 
        public AppInfoProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string[] appIds { get; set; }
    }
    [DataContract]
    public class GetAppProps { 
        public GetAppProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; } 
    }
    [DataContract]
    public class GetAppsProps { 
        public GetAppsProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string[] appIds { get; set; } 
    }
    [DataContract]
    public class AppSlotsProps { 
        public AppSlotsProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; }
    }
    [DataContract]
    public class GetAppSlotsProps { 
        public GetAppSlotsProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; } 
    }
    [DataContract]
    public class AppListingsProps { 
        public AppListingsProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; } 
    }


    [DataContract]
    public class GetAppResponse : BasicResponse<GetAppResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetAppResponse() : base() { } 
    }
    [DataContract]
    public class GetAppResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetAppResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public App app { get; set; } 
    }
    [DataContract]
    public class GetAppsResponse : BasicResponse<GetAppsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetAppsResponse() : base() { }
    }
    [DataContract]
    public class GetAppsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetAppsResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<App> app { get; set; } 
    }
    [DataContract]
    public class GetAppSlotsResponse : BasicResponse<GetAppSlotsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetAppSlotsResponse() : base() { }
    }
    [DataContract]
    public class GetAppSlotsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetAppSlotsResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public AppWithSlotsWithExpressions app { get; set; } 
    }
    [DataContract]
    public class GetAppSlotIdsResponse : BasicResponse<GetAppSlotIdsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetAppSlotIdsResponse() : base() { }
    }
    [DataContract]
    public class GetAppSlotIdsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetAppSlotIdsResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public App app { get; set; } 
    }
    [DataContract]
    public class GetAppsWithListingsResponse : BasicResponse<GetAppsWithListingsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetAppsWithListingsResponse() : base() { }
    }
    [DataContract]
    public class GetAppsWithListingsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetAppsWithListingsResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<AppWithListingsCount> apps { get; set; } 
    }
    [DataContract]
    public class GetAppIdsWithListingsResponse : BasicResponse<GetAppIdsWithListingsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetAppIdsWithListingsResponse() : base() { }
    }
    [DataContract]
    public class GetAppIdsWithListingsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetAppIdsWithListingsResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<AppIdOnly> apps { get; set; } 
    }


    public class AppsRawDelegates {
        public delegate Task<(GetAppResponse, GetAppsResponse)> Info(AppInfoProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetAppResponse> GetApp(GetAppProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetAppsResponse> GetApps(GetAppsProps props, Dictionary<string, string> headers = null);
        public delegate Task<(GetAppSlotsResponse, GetAppSlotIdsResponse)> Slots(AppSlotsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetAppSlotsResponse> GetAppSlots(GetAppSlotsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetAppSlotIdsResponse> GetAppSlotIds(GetAppSlotsProps props, Dictionary<string, string> headers = null);
        public delegate Task<(GetAppsWithListingsResponse, GetAppIdsWithListingsResponse)> Listings(AppListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetAppsWithListingsResponse> GetAppsWithListings(Dictionary<string, string> headers = null);
        public delegate Task<GetAppIdsWithListingsResponse> GetAppIdsWithListings(Dictionary<string, string> headers = null);
    }

    public class AppsRawHandlers {
        public AppsRawDelegates.Info Info;
        public AppsRawDelegates.GetApp GetApp;
        public AppsRawDelegates.GetApps GetApps;
        public AppsRawDelegates.Slots Slots;
        public AppsRawDelegates.GetAppSlots GetAppSlots;
        public AppsRawDelegates.GetAppSlotIds GetAppSlotIds;
        public AppsRawDelegates.Listings Listings;
        public AppsRawDelegates.GetAppsWithListings GetAppsWithListings;
        public AppsRawDelegates.GetAppIdsWithListings GetAppIdsWithListings;
    }

    public class AppsSafeDelegates {
        public delegate Task<BasicResult<(App, List<App>)>> Info(AppInfoProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<App>> GetApp(GetAppProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<App>>> GetApps(GetAppsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(List<SlotWithExpressions>, List<string>)>> Slots(AppSlotsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<SlotWithExpressions>>> GetAppSlots(GetAppSlotsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<string>>> GetAppSlotIds(GetAppSlotsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(List<AppWithListingsCount>, List<AppIdOnly>)>> Listings(AppListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<AppWithListingsCount>>> GetAppsWithListings(Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<AppIdOnly>>> GetAppIdsWithListings(Dictionary<string, string> headers = null);
    }

    public class AppsSafeHandlers {
        public AppsSafeDelegates.Info Info;
        public AppsSafeDelegates.GetApp GetApp;
        public AppsSafeDelegates.GetApps GetApps;
        public AppsSafeDelegates.Slots Slots;
        public AppsSafeDelegates.GetAppSlots GetAppSlots;
        public AppsSafeDelegates.GetAppSlotIds GetAppSlotIds;
        public AppsSafeDelegates.Listings Listings;
        public AppsSafeDelegates.GetAppsWithListings GetAppsWithListings;
        public AppsSafeDelegates.GetAppIdsWithListings GetAppIdsWithListings;
    }
}
