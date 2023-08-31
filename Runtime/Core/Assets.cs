using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using AssetLayer.SDK;
using AssetLayer.SDK.Assets;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Core.Base;
using AssetLayer.SDK.Utils;
using UnityEngine;

namespace AssetLayer.SDK.Core.Assets
{
    public class AssetsHandler : BaseHandler
    {
        private static AssetsHandler _this;
        public AssetsHandler(AssetLayerConfig config = null) : base(config) { _this = this; }

        public async Task<(Asset, List<Asset>)> Info(AssetInfoProps props, Dictionary<string, string> headers = null) {
            if (props.assetIds != null) return (null, (await this.Raw.Info(props, headers)).body.assets);
            else return ((await this.Raw.Info(props, headers)).body.assets[0], null); }
        public async Task<Asset> GetAsset(GetAssetProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetAsset(props, headers)).body.assets[0]; }
        public async Task<List<Asset>> GetAssets(GetAssetsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetAssets(props, headers)).body.assets; }

        public AssetsRawHandlers Raw = new AssetsRawHandlers {
            Info = async (props, headers) => await _this.Request<GetAssetsResponse>("/asset/info" + AssetLayerUtils.PropsToQueryString(props)),
            GetAsset = async (props, headers) => await _this.Request<GetAssetsResponse>("/asset/info" + AssetLayerUtils.PropsToQueryString(props)),
            GetAssets = async (props, headers) => await _this.Request<GetAssetsResponse>("/asset/info" + AssetLayerUtils.PropsToQueryString(props)),
        };

        public object Safe = new
        {
            
        };
    }
}
