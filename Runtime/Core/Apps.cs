using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using AssetLayer.SDK;
using AssetLayer.SDK.Apps;
using AssetLayer.SDK.Core.Base;
using AssetLayer.SDK.Utils;
using UnityEngine;

namespace AssetLayer.SDK.Core.Apps
{
    public class AppsHandler : BaseHandler
    {
        private static AppsHandler _this;
        public AppsHandler(AssetLayerConfig config = null) : base(config) { _this = this; }

        public async Task<(App, App[])> Info(AppInfoProps props, Dictionary<string, string> headers = null) { 
            if (props.appIds != null) return (null, (await this.Raw.Info(props, headers)).Item2.body.app);
            else return ((await this.Raw.Info(props, headers)).Item1.body.app, null); }
        public async Task<GetAppResponse> GetApp(AppInfoProps props, Dictionary<string, string> headers = null) {
            return await this.Raw.GetApp(props, headers); }
        public async Task<GetAppsResponse> GetApps(AppInfoProps props, Dictionary<string, string> headers = null) {
            return await this.Raw.GetApps(props, headers); }
        /*
        public async Task<AppSlotsResponse> Slots(AppSlotsProps props, Dictionary<string, string> headers = null) {
            return await this.Raw.Slots(props, headers); }
        public async Task<GetAppSlotsResponse> GetAppSlots(AppSlotsProps props, Dictionary<string, string> headers = null) {
            return await this.Raw.GetSlots(props, headers); }
        public async Task<GetAppSlotIdsResponse> GetAppSlotIds(AppSlotsProps props, Dictionary<string, string> headers = null) {
            return await this.Raw.GetSlotIds(props, headers); }
        public async Task<AppListingsResponse> Listings(AppListingsProps props, Dictionary<string, string> headers = null) {
            return await this.Raw.Listings(props, headers); }
        public async Task<GetAppsWithListingsResponse> GetAppsWithListings(AppListingsProps props, Dictionary<string, string> headers = null) {
            return await this.Raw.GetAppsWithListings(props, headers); }
        public async Task<GetAppIdsWithListingsResponse> GetAppIdsWithListings(AppListingsProps props, Dictionary<string, string> headers = null) {
            return await this.Raw.GetAppIdsWithListings(props, headers); }
        */

        public AppsRawHandlers Raw = new AppsRawHandlers {
            Info = async (props, headers) => {
                if (props.appIds != null) return (null, await _this.Request<GetAppsResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props)));
                else return (await _this.Request<GetAppResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props)), null);
            },
            GetApp = async (props, headers) => await _this.Request<GetAppResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props)),
            GetApps = async (props, headers) => await _this.Request<GetAppsResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props)),
            // Slots = async (props, headers) => await _this.Request<AppSlotsResponse>("/app/slots" + AssetLayerUtils.PropsToQueryString(props)),
            // GetAppSlots = async (props, headers) => await _this.Request<GetAppSlotsResponse>("/app/slots" + AssetLayerUtils.PropsToQueryString(props)),
            // GetAppSlotIds = async (props, headers) => await _this.Request<GetAppSlotIdsResponse>("/app/slots" + AssetLayerUtils.PropsToQueryString(props)),
            // Listings = async (props, headers) => await _this.Request<AppListingsResponse>("/app/listings" + AssetLayerUtils.PropsToQueryString(props)),
            // GetAppsWithListings = async (props, headers) => await _this.Request<GetAppsWithListingsResponse>("/app/listings" + AssetLayerUtils.PropsToQueryString(props)),
            // GetAppIdsWithListings = async (props, headers) => await _this.Request<GetAppIdsWithListingsResponse>("/app/listings" + AssetLayerUtils.PropsToQueryString(props)),
        };

        public object Safe = new
        {
            /*
            Info = async (props, headers) =>
            {
                try
                {
                    return new { result = await this.info(props, headers) };
                }
                catch (Exception e)
                {
                    return new { error = parseBasicError(e) };
                }
            }
            */
        };
    }
}
