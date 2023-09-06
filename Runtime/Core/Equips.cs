using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AssetLayer.SDK;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Core.Base;
using AssetLayer.SDK.Equips;
using AssetLayer.SDK.Utils;
using UnityEngine;

namespace AssetLayer.SDK.Core.Equips
{
    public class EquipsHandler : BaseHandler
    {
        private static EquipsHandler _this;
        public EquipsHandler(AssetLayerConfig config = null) : base(config) { _this = this; }
        
        public async Task<List<Equip>> GetEquips(GetEquipsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetEquips(props, headers)).body.equip; }
        public async Task<string> SetEquip(SetEquipProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.SetEquip(props, headers)).body.equipId; }
        public async Task<bool> RemoveEquip(RemoveEquipProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.RemoveEquip(props, headers)).success; }


        public EquipsRawHandlers Raw = new EquipsRawHandlers {
            GetEquips = async (props, headers) => await _this.Request<GetEquipsResponse>("/equip/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            SetEquip = async (props, headers) => await _this.Request<SetEquipResponse>("/equip/new", "POST", props, headers),
            RemoveEquip = async (props, headers) => await _this.Request<BasicSuccessResponse>("/equip", "DELETE", props, headers)
        };

        public EquipsSafeHandlers Safe = new EquipsSafeHandlers {
            GetEquips = async (props, headers) => {
                try { return new BasicResult<List<Equip>> { Result = await _this.GetEquips(props, headers) }; }
                catch (Exception e) { return new BasicResult<List<Equip>> { Error = new BasicError(e.Message, 500) }; }},
            SetEquip = async (props, headers) => {
                try { return new BasicResult<string> { Result = await _this.SetEquip(props, headers) }; }
                catch (Exception e) { return new BasicResult<string> { Error = new BasicError(e.Message, 500) }; }},
            RemoveEquip = async (props, headers) => {
                try { return new BasicResult<bool> { Result = await _this.RemoveEquip(props, headers) }; }
                catch (Exception e) { return new BasicResult<bool> { Error = new BasicError(e.Message, 500) }; }}
        };
    }
}
