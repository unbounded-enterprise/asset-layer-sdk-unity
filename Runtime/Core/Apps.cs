using System;
using System.Collections.Generic;
using System.Net.Http;
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
        public async Task<(List<AppWithListingsCount>, List<AppIdOnly>)> Listings(AppsWithListingsProps props, Dictionary<string, string> headers = null) {
            if (props.idOnly == true) return (null, (await this.Raw.Listings(props, headers)).Item2.body.apps);
            else return ((await this.Raw.Listings(props, headers)).Item1.body.apps, null); }
        public async Task<List<AppWithListingsCount>> GetAppsWithListings(Dictionary<string, string> headers = null) {
            return (await this.Raw.GetAppsWithListings(headers)).body.apps; }
        public async Task<List<AppIdOnly>> GetAppIdsWithListings(Dictionary<string, string> headers = null) {
            return (await this.Raw.GetAppIdsWithListings(headers)).body.apps; }

        public AppsRawHandlers Raw = new AppsRawHandlers {
            Info = async (props, headers) => {
                if (props.appIds != null) return (null, await _this.Request<GetAppsResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props)));
                else return (await _this.Request<GetAppResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props)), null);
            },
            GetApp = async (props, headers) => await _this.Request<GetAppResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props)),
            GetApps = async (props, headers) => await _this.Request<GetAppsResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props)),
            Slots = async (props, headers) => {
                if (props.idOnly == true) return (null, await _this.Request<GetAppSlotIdsResponse>("/app/slots" + AssetLayerUtils.PropsToQueryString(props)));
                else return (await _this.Request<GetAppSlotsResponse>("/app/slots" + AssetLayerUtils.PropsToQueryString(props)), null);
            },
            GetAppSlots = async (props, headers) => await _this.Request<GetAppSlotsResponse>("/app/slots" + AssetLayerUtils.PropsToQueryString(props)),
            GetAppSlotIds = async (props, headers) => await _this.Request<GetAppSlotIdsResponse>("/app/slots" + AssetLayerUtils.PropsToQueryString(props)),
            Listings = async (props, headers) => {
                if (props.idOnly == true) return (null, await _this.Request<GetAppIdsWithListingsResponse>("/app/listings" + AssetLayerUtils.PropsToQueryString(props)));
                else return (await _this.Request<GetAppsWithListingsResponse>("/app/listings" + AssetLayerUtils.PropsToQueryString(props)), null);
            },
            GetAppsWithListings = async (headers) => await _this.Request<GetAppsWithListingsResponse>("/app/listings"),
            GetAppIdsWithListings = async (headers) => await _this.Request<GetAppIdsWithListingsResponse>("/app/listings?idOnly=true"),
        };

        public AppsSafeHandlers Safe = new AppsSafeHandlers
        {
            Info = async (props, headers) => {
                try { return new BasicResult<(App, List<App>)> { result = await _this.Info(props, headers) }; }
                catch (Exception e) { return new BasicResult<(App, List<App>)> { error = new BasicError("", 400)/*parseBasicError(e)*/ }; } }
        };
    }
}
