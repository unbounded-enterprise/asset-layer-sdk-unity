using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AssetLayer.SDK;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Core.Base;
using AssetLayer.SDK.Shop;
using AssetLayer.SDK.Utils;
using UnityEngine;

namespace AssetLayer.SDK.Core.Shop
{
    public class ShopHandler : BaseHandler
    {
        private static ShopHandler _this;
        public ShopHandler(AssetLayerConfig config = null) : base(config) { _this = this; }
        
        // public async Task<NewItemResponseData> NewItem(NewItemProps props, Dictionary<string, string> headers = null) {
        //     return (await this.Raw.NewItem(props, headers)).body.newItem; }
        public async Task<bool> BuyItem(BuyItemProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.BuyItem(props, headers)).buy; }
        public async Task<ShopItemSummary> Summary(Dictionary<string, string> headers = null) {
            return (await this.Raw.Summary(headers)).body.summary; }
        // public async Task<bool> RemoveItem(RemoveItemProps props, Dictionary<string, string> headers = null) {
        //     return (await this.Raw.RemoveItem(props, headers)).success; }

        public ShopRawHandlers Raw = new ShopRawHandlers {
            // NewItem = async (props, headers) => await _this.Request<NewItemResponse>("/shop/newItem", "POST", props, headers),
            BuyItem = async (props, headers) => await _this.Request<BuyItemResponse>("/shop/buy", "POST", props, headers),
            Summary = async (headers) => await _this.Request<ShopSummaryResponse>("/shop/summary", "GET", null, headers),
            // RemoveItem = async (props, headers) => await _this.Request<BasicSuccessResponse>("/shop/removeItem", "PUT", props, headers)
        };

        public ShopSafeHandlers Safe = new ShopSafeHandlers {
            // NewItem = async (props, headers) => {
            //     try { return new BasicResult<NewItemResponseData> { Result = await _this.NewItem(props, headers) }; }
            //     catch (BasicError e) { return new BasicResult<NewItemResponseData> { Error = e }; }},
            BuyItem = async (props, headers) => {
                try { return new BasicResult<bool> { Result = await _this.BuyItem(props, headers) }; }
                catch (BasicError e) { return new BasicResult<bool> { Error = e }; }},
            Summary = async (headers) => {
                try { return new BasicResult<ShopItemSummary> { Result = await _this.Summary(headers) }; }
                catch (BasicError e) { return new BasicResult<ShopItemSummary> { Error = e }; }},
            // RemoveItem = async (props, headers) => {
            //     try { return new BasicResult<bool> { Result = await _this.RemoveItem(props, headers) }; }
            //     catch (BasicError e) { return new BasicResult<bool> { Error = e }; }}
        };
    }
}
