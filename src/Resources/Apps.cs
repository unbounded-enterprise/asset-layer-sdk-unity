using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using AssetLayerSDK;
using AssetLayerSDK.Apps;
using AssetLayerSDK.Core.Base;
using AssetLayerSDK.Utils;
using UnityEngine;

namespace AssetLayerSDK.Core.Apps
{
    public class AppsHandler : BaseHandler
    {
        private static AppsHandler _this;
        public AppsHandler(AssetLayerConfig config = null) : base(config) { _this = this; }

        public async Task<AppInfoResponse> info(AppInfoProps props, Dictionary<string, string> headers = null) { 
            return await this.raw.info(props, headers); }
        /*
        public async Task<GetAppResponse> getApp(AppInfoProps props, Dictionary<string, string> headers = null) {
            return await this.raw.getApp(props, headers); }
        public async Task<GetAppsResponse> getApps(AppInfoProps props, Dictionary<string, string> headers = null) {
            return await this.raw.getApps(props, headers); }
        public async Task<AppSlotsResponse> slots(AppSlotsProps props, Dictionary<string, string> headers = null) {
            return await this.raw.slots(props, headers); }
        public async Task<GetAppSlotsResponse> getAppSlots(AppSlotsProps props, Dictionary<string, string> headers = null) {
            return await this.raw.getSlots(props, headers); }
        public async Task<GetAppSlotIdsResponse> getAppSlotIds(AppSlotsProps props, Dictionary<string, string> headers = null) {
            return await this.raw.getSlotIds(props, headers); }
        public async Task<AppListingsResponse> listings(AppListingsProps props, Dictionary<string, string> headers = null) {
            return await this.raw.listings(props, headers); }
        public async Task<GetAppsWithListingsResponse> getAppsWithListings(AppListingsProps props, Dictionary<string, string> headers = null) {
            return await this.raw.getAppsWithListings(props, headers); }
        public async Task<GetAppIdsWithListingsResponse> getAppIdsWithListings(AppListingsProps props, Dictionary<string, string> headers = null) {
            return await this.raw.getAppIdsWithListings(props, headers); }
        */

        public AppsRawHandlers raw = new AppsRawHandlers {
            info = async (props, headers) => await _this.Request<AppInfoResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props))
            // getApp = async (props, headers) => await _this.Request<GetAppResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props)),
            // getApps = async (props, headers) => await _this.Request<GetAppsResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props)),
            // slots = async (props, headers) => await _this.Request<AppSlotsResponse>("/app/slots" + AssetLayerUtils.PropsToQueryString(props)),
            // getAppSlots = async (props, headers) => await _this.Request<GetAppSlotsResponse>("/app/slots" + AssetLayerUtils.PropsToQueryString(props)),
            // getAppSlotIds = async (props, headers) => await _this.Request<GetAppSlotIdsResponse>("/app/slots" + AssetLayerUtils.PropsToQueryString(props)),
            // listings = async (props, headers) => await _this.Request<AppListingsResponse>("/app/listings" + AssetLayerUtils.PropsToQueryString(props)),
            // getAppsWithListings = async (props, headers) => await _this.Request<GetAppsWithListingsResponse>("/app/listings" + AssetLayerUtils.PropsToQueryString(props)),
            // getAppIdsWithListings = async (props, headers) => await _this.Request<GetAppIdsWithListingsResponse>("/app/listings" + AssetLayerUtils.PropsToQueryString(props)),
        };

        public object safe = new
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
