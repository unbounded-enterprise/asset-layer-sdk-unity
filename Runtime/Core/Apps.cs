using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AssetLayer.SDK;
using AssetLayer.SDK.Apps;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Core.Base;
using AssetLayer.SDK.Slots;
using AssetLayer.SDK.Utils;
using UnityEngine;

namespace AssetLayer.SDK.Core.Apps
{
    public class AppsHandler : BaseHandler
    {
        private static AppsHandler _this;
        public AppsHandler(AssetLayerConfig config = null) : base(config) { _this = this; }

        public async Task<(App, List<App>)> Info(AppInfoProps props, Dictionary<string, string> headers = null) { 
            if (props.appIds != null) return (null, (await this.Raw.Info(props, headers)).Item2.body.app);
            else return ((await this.Raw.Info(props, headers)).Item1.body.app, null); }
        public async Task<App> GetApp(GetAppProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetApp(props, headers)).body.app; }
        public async Task<List<App>> GetApps(GetAppsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetApps(props, headers)).body.app; }
        public async Task<(List<SlotWithExpressions>, List<string>)> Slots(AppSlotsProps props, Dictionary<string, string> headers = null) {
            if (props.idOnly == true) return (null, (await this.Raw.Slots(props, headers)).Item2.body.app.slots);
            else return ((await this.Raw.Slots(props, headers)).Item1.body.app.slots, null); }
        public async Task<List<SlotWithExpressions>> GetAppSlots(GetAppSlotsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetAppSlots(props, headers)).body.app.slots; }
        public async Task<List<string>> GetAppSlotIds(GetAppSlotsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetAppSlotIds(props, headers)).body.app.slots; }
        public async Task<(List<AppWithListingsCount>, List<AppIdOnly>)> Listings(AppListingsProps props, Dictionary<string, string> headers = null) {
            if (props.idOnly == true) return (null, (await this.Raw.Listings(props, headers)).Item2.body.apps);
            else return ((await this.Raw.Listings(props, headers)).Item1.body.apps, null); }
        public async Task<List<AppWithListingsCount>> GetAppsWithListings(Dictionary<string, string> headers = null) {
            return (await this.Raw.GetAppsWithListings(headers)).body.apps; }
        public async Task<List<AppIdOnly>> GetAppIdsWithListings(Dictionary<string, string> headers = null) {
            return (await this.Raw.GetAppIdsWithListings(headers)).body.apps; }

        public AppsRawHandlers Raw = new AppsRawHandlers {
            Info = async (props, headers) => {
                if (props.appIds != null) return (null, await _this.Request<GetAppsResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else return (await _this.Request<GetAppResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
            },
            GetApp = async (props, headers) => await _this.Request<GetAppResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetApps = async (props, headers) => await _this.Request<GetAppsResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            Slots = async (props, headers) => {
                if (props.idOnly == true) return (null, await _this.Request<GetAppSlotIdsResponse>("/app/slots" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else return (await _this.Request<GetAppSlotsResponse>("/app/slots" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
            },
            GetAppSlots = async (props, headers) => await _this.Request<GetAppSlotsResponse>("/app/slots" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetAppSlotIds = async (props, headers) => await _this.Request<GetAppSlotIdsResponse>("/app/slots" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            Listings = async (props, headers) => {
                if (props.idOnly == true) return (null, await _this.Request<GetAppIdsWithListingsResponse>("/app/listings" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else return (await _this.Request<GetAppsWithListingsResponse>("/app/listings" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
            },
            GetAppsWithListings = async (headers) => await _this.Request<GetAppsWithListingsResponse>("/app/listings", "GET", null, headers),
            GetAppIdsWithListings = async (headers) => await _this.Request<GetAppIdsWithListingsResponse>("/app/listings?idOnly=true", "GET", null, headers),
        };

        public AppsSafeHandlers Safe = new AppsSafeHandlers {
            Info = async (props, headers) => {
                try { return new BasicResult<(App, List<App>)> { Result = await _this.Info(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(App, List<App>)> { Error = e }; } },
            GetApp = async (props, headers) => {
                try { return new BasicResult<App> { Result = await _this.GetApp(props, headers) }; }
                catch (BasicError e) { return new BasicResult<App> { Error = e }; } },
            GetApps = async (props, headers) => {
                try { return new BasicResult<List<App>> { Result = await _this.GetApps(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<App>> { Error = e }; } },
            Slots = async (props, headers) => {
                try { return new BasicResult<(List<SlotWithExpressions>, List<string>)> { Result = await _this.Slots(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(List<SlotWithExpressions>, List<string>)> { Error = e }; } },
            GetAppSlots = async (props, headers) => {
                try { return new BasicResult<List<SlotWithExpressions>> { Result = await _this.GetAppSlots(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<SlotWithExpressions>> { Error = e }; } },
            GetAppSlotIds = async (props, headers) => {
                try { return new BasicResult<List<string>> { Result = await _this.GetAppSlotIds(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<string>> { Error = e }; } },
            Listings = async (props, headers) => {
                try { return new BasicResult<(List<AppWithListingsCount>, List<AppIdOnly>)> { Result = await _this.Listings(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(List<AppWithListingsCount>, List<AppIdOnly>)> { Error = e }; } },
            GetAppsWithListings = async (headers) => {
                try { return new BasicResult<List<AppWithListingsCount>> { Result = await _this.GetAppsWithListings(headers) }; }
                catch (BasicError e) { return new BasicResult<List<AppWithListingsCount>> { Error = e }; } },
            GetAppIdsWithListings = async (headers) => {
                try { return new BasicResult<List<AppIdOnly>> { Result = await _this.GetAppIdsWithListings(headers) }; }
                catch (BasicError e) { return new BasicResult<List<AppIdOnly>> { Error = e }; } }
        };
    }
}
