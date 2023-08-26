using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using AssetLayerSDK;
using AssetLayerSDK.Apps;
using AssetLayerSDK.Base;
using AssetLayerSDK.Utils;
using UnityEngine;

namespace AssetLayerSDK.Core.Apps
{
    public class AppsHandler : BaseHandler
    {
        private static AppsHandler _this { get; set; }
        public AppsHandler(AssetLayerConfig config = null) : base(config) { _this = this; }

        public async Task<AppInfoResponse> info(AppInfoProps props/*, AnyHeaders headers = null*/) { 
            return await this.raw.info(props, null); }

        public AppsRawHandlers raw = new AppsRawHandlers {
            info = async (props, headers) => await _this.GetRequest<AppInfoResponse>("/app/info" + AssetLayerUtils.PropsToQueryString(props))
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
