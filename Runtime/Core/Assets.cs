using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AssetLayer.SDK;
using AssetLayer.SDK.Assets;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Core.Base;
using AssetLayer.SDK.Users;
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
        public async Task<(List<Asset>, List<AssetIdOnly>, object)> User(AssetUserProps props, Dictionary<string, string> headers = null) {
            if (props.countsOnly == true) return (null, null, (await this.Raw.User(props, headers)).Item3.body);
            else if (props.idOnly == true) return (null, (await this.Raw.User(props, headers)).Item2.body.assets, null);
            else return ((await this.Raw.User(props, headers)).Item1.body.assets, null, null);
        }
        public async Task<List<Asset>> GetUserAssets(GetUserAssetsBaseProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetUserAssets(props, headers)).body.assets; }
        public async Task<List<AssetIdOnly>> GetUserAssetIds(GetUserAssetsBaseProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetUserAssetIds(props, headers)).body.assets; }
        public async Task<object> GetUserAssetCounts(GetUserAssetsBaseProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetUserAssetCounts(props, headers)).body; }
        public async Task<(List<Asset>, List<AssetIdOnly>, object)> GetUserCollectionAssets(GetUserCollectionAssetsProps props, Dictionary<string, string> headers = null) {
            if (props.countsOnly == true) return (null, null, (await this.Raw.GetUserCollectionAssets(props, headers)).Item3.body.assets);
            else if (props.idOnly == true) return (null, (await this.Raw.GetUserCollectionAssets(props, headers)).Item2.body.assets, null);
            else return ((await this.Raw.GetUserCollectionAssets(props, headers)).Item1.body.assets, null, null);
        }
        public async Task<(List<Asset>, List<AssetIdOnly>, object)> GetUserCollectionsAssets(GetUserCollectionsAssetsProps props, Dictionary<string, string> headers = null) {
            if (props.countsOnly == true) return (null, null, (await this.Raw.GetUserCollectionsAssets(props, headers)).Item3.body.collections);
            else if (props.idOnly == true) return (null, (await this.Raw.GetUserCollectionsAssets(props, headers)).Item2.body.collections, null);
            else return ((await this.Raw.GetUserCollectionsAssets(props, headers)).Item1.body.collections, null, null);
        }
        public async Task<(List<Asset>, List<AssetIdOnly>, object)> GetUserSlotAssets(GetUserSlotAssetsProps props, Dictionary<string, string> headers = null) {
            if (props.countsOnly == true) return (null, null, (await this.Raw.GetUserSlotAssets(props, headers)).Item3.body);
            else if (props.idOnly == true) return (null, (await this.Raw.GetUserSlotAssets(props, headers)).Item2.body.assets, null);
            else return ((await this.Raw.GetUserSlotAssets(props, headers)).Item1.body.assets, null, null);
        }
        public async Task<(List<Asset>, List<AssetIdOnly>, object)> GetUserSlotsAssets(GetUserSlotsAssetsProps props, Dictionary<string, string> headers = null) {
            if (props.countsOnly == true) return (null, null, (await this.Raw.GetUserSlotsAssets(props, headers)).Item3.body);
            else if (props.idOnly == true) return (null, (await this.Raw.GetUserSlotsAssets(props, headers)).Item2.body.assets, null);
            else return ((await this.Raw.GetUserSlotsAssets(props, headers)).Item1.body.assets, null, null);
        }
        public async Task<List<AssetHistoryRecord>> GetAssetHistory(GetAssetHistoryProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetAssetHistory(props, headers)).body.history; }
        public async Task<List<AssetHistoryRecord>> GetAssetMarketHistory(GetAssetHistoryProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetAssetMarketHistory(props, headers)).body.history; }
        public async Task<(List<AssetHistoryRecord>, List<UserAlias>)> GetAssetOwnershipHistory(GetAssetOwnershipHistoryProps props, Dictionary<string, string> headers = null) {
            if (props.ownersOnly == true) return (null, (await this.Raw.GetAssetOwnershipHistory(props, headers)).Item2.body.history);
            else return ((await this.Raw.GetAssetOwnershipHistory(props, headers)).Item1.body.history, null);
        }
        public async Task<bool> MintAssets(MintAssetsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.MintAssets(props, headers)).success; }
        public async Task<(SendAssetResponseBody, SendAssetsResponseBody)> Send(AssetSendProps props, Dictionary<string, string> headers = null) {
            if (props.collectionId != null || props.assetIds != null) return (null, (await this.Raw.Send(props, headers)).Item2.body);
            else return ((await this.Raw.Send(props, headers)).Item1.body, null);
        }
        public async Task<SendAssetResponseBody> SendAsset(SendAssetProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.SendAsset(props, headers)).body; }
        public async Task<SendAssetsResponseBody> SendAssets(SendAssetsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.SendAssets(props, headers)).body; }
        public async Task<SendAssetsResponseBody> SendCollectionAssets(SendCollectionAssetsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.SendCollectionAssets(props, headers)).body; }
        public async Task<SendAssetResponseBody> SendLowestAsset(SendLowestAssetProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.SendLowestAsset(props, headers)).body; }
        public async Task<SendAssetResponseBody> SendRandomAsset(SendRandomAssetProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.SendRandomAsset(props, headers)).body; }
        public async Task<(UpdateAssetResponseBody, List<string>, string)> Update(AssetUpdateProps props, Dictionary<string, string> headers = null) {
            if (props.collectionId != null) return (null, null, (await this.Raw.Update(props, headers)).Item3.body.collectionId);
            else if (props.assetId != null) return (null, (await this.Raw.Update(props, headers)).Item2.body.assetIds, null);
            else return ((await this.Raw.Update(props, headers)).Item1.body, null, null);   
        }
        public async Task<UpdateAssetResponseBody> UpdateAsset(UpdateAssetProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.UpdateAsset(props, headers)).body; }
        public async Task<List<string>> UpdateAssets(UpdateAssetsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.UpdateAssets(props, headers)).body.assetIds; }
        public async Task<string> UpdateCollectionAssets(UpdateCollectionAssetsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.UpdateCollectionAssets(props, headers)).body.collectionId; }
        public async Task<(string, List<string>, bool?)> ExpressionValues(UpdateExpressionValuesProps props, Dictionary<string, string> headers = null) {
            if (props.collectionId != null) return (null, null, (await this.Raw.ExpressionValues(props, headers)).Item3.success);
            else if (props.assetIds != null) return (null, (await this.Raw.ExpressionValues(props, headers)).Item2.body.assetIds, null);
            else return ((await this.Raw.ExpressionValues(props, headers)).Item1.body.expressionValueId, null, null);
        }
        public async Task<string> UpdateAssetExpressionValue(UpdateAssetExpressionValueProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.UpdateAssetExpressionValue(props, headers)).body.expressionValueId; }
        public async Task<List<string>> UpdateAssetsExpressionValue(UpdateAssetsExpressionValueProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.UpdateAssetsExpressionValue(props, headers)).body.assetIds; }
        public async Task<bool> UpdateCollectionAssetsExpressionValue(UpdateCollectionAssetsExpressionValueProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.UpdateCollectionAssetsExpressionValue(props, headers)).success; }
        public async Task<List<BulkExpressionValueLog>> UpdateBulkExpressionValues(UpdateBulkExpressionValuesProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.UpdateBulkExpressionValues(props, headers)).body.log; }
        
        public AssetsRawHandlers Raw = new AssetsRawHandlers {
            Info = async (props, headers) => await _this.Request<GetAssetsResponse>("/asset/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetAsset = async (props, headers) => await _this.Request<GetAssetsResponse>("/asset/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetAssets = async (props, headers) => await _this.Request<GetAssetsResponse>("/asset/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            User = async (props, headers) => {
                if (props.countsOnly == true) return (null, null, await _this.Request<GetAssetCountsResponse>("/asset/user" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else if (props.idOnly == true) return (null, await _this.Request<GetAssetIdsResponse>("/asset/user" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
                else return (await _this.Request<GetAssetsResponse>("/asset/user" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null, null);
            },
            GetUserAssets = async (props, headers) => await _this.Request<GetAssetsResponse>("/asset/user" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetUserAssetIds = async (props, headers) => await _this.Request<GetAssetIdsResponse>("/asset/user" + AssetLayerUtils.PropsToQueryString(props, new { idOnly = true }), "GET", null, headers),
            GetUserAssetCounts = async (props, headers) => await _this.Request<GetAssetCountsResponse>("/asset/user" + AssetLayerUtils.PropsToQueryString(props, new { countsOnly = true }), "GET", null, headers),
            GetUserCollectionAssets = async (props, headers) => {
                if (props.countsOnly == true) return (null, null, await _this.Request<GetAssetCountsResponse>("/asset/collection" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else if (props.idOnly == true) return (null, await _this.Request<GetAssetIdsResponse>("/asset/collection" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
                else return (await _this.Request<GetAssetsResponse>("/asset/collection" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null, null);
            },
            GetUserCollectionsAssets = async (props, headers) => {
                if (props.countsOnly == true) return (null, null, await _this.Request<GetCollectionsAssetCountsResponse>("/asset/collections" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else if (props.idOnly == true) return (null, await _this.Request<GetCollectionsAssetIdsResponse>("/asset/collections" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
                else return (await _this.Request<GetCollectionsAssetsResponse>("/asset/collections" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null, null);
            },
            GetUserSlotAssets = async (props, headers) => {
                if (props.countsOnly == true) return (null, null, await _this.Request<GetAssetCountsResponse>("/asset/slot" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else if (props.idOnly == true) return (null, await _this.Request<GetAssetIdsResponse>("/asset/slot" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
                else return (await _this.Request<GetAssetsResponse>("/asset/slot" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null, null);
            },
            GetUserSlotsAssets = async (props, headers) => {
                if (props.countsOnly == true) return (null, null, await _this.Request<GetAssetCountsResponse>("/asset/slots" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else if (props.idOnly == true) return (null, await _this.Request<GetAssetIdsResponse>("/asset/slots" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
                else return (await _this.Request<GetAssetsResponse>("/asset/slots" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null, null);
            },
            GetAssetHistory = async (props, headers) => await _this.Request<GetAssetHistoryResponse>("/asset/history" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetAssetMarketHistory = async (props, headers) => await _this.Request<GetAssetMarketHistoryResponse>("/asset/history" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetAssetOwnershipHistory = async (props, headers) => {
                if (props.ownersOnly == true) return (null, await _this.Request<GetAssetOwnershipHistoryResponse>("/asset/history" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else return (await _this.Request<GetAssetMarketHistoryResponse>("/asset/history" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
            },
            MintAssets = async (props, headers) => await _this.Request<BasicSuccessResponse>("/asset/mint", "POST", props, headers),
            Send = async (props, headers) => {
                if (props.collectionId != null || props.assetIds != null) return (null, await _this.Request<SendAssetsResponse>("/asset/send", "POST", props, headers));
                else return (await _this.Request<SendAssetResponse>("/asset/send", "POST", props, headers), null);
            },
            SendAsset = async (props, headers) => await _this.Request<SendAssetResponse>("/asset/send", "POST", props, headers),
            SendAssets = async (props, headers) => await _this.Request<SendAssetsResponse>("/asset/send", "POST", props, headers),
            SendCollectionAssets = async (props, headers) => await _this.Request<SendAssetsResponse>("/asset/send", "POST", props, headers),
            SendLowestAsset = async (props, headers) => await _this.Request<SendAssetResponse>("/asset/send", "POST", props, headers),
            SendRandomAsset = async (props, headers) => await _this.Request<SendAssetResponse>("/asset/send", "POST", props, headers),
            Update = async (props, headers) => {
                if (props.collectionId != null) return (null, null, await _this.Request<UpdateCollectionAssetsResponse>("/asset/update", "PUT", props, headers));
                else if (props.assetId != null) return (null, await _this.Request<UpdateAssetsResponse>("/asset/update", "PUT", props, headers), null);
                else return (await _this.Request<UpdateAssetResponse>("/asset/update", "PUT", props, headers), null, null);
            },
            UpdateAsset = async (props, headers) => await _this.Request<UpdateAssetResponse>("/asset/update", "PUT", props, headers),
            UpdateAssets = async (props, headers) => await _this.Request<UpdateAssetsResponse>("/asset/update", "PUT", props, headers),
            UpdateCollectionAssets = async (props, headers) => await _this.Request<UpdateCollectionAssetsResponse>("/asset/update", "PUT", props, headers),
            ExpressionValues = async (props, headers) => {
                if (props.collectionId != null) return (null, null, await _this.Request<BasicSuccessResponse>("/asset/expressionValues", "POST", props, headers));
                else if (props.assetIds != null) return (null, await _this.Request<UpdateAssetsExpressionValueResponse>("/asset/expressionValues", "POST", props, headers), null);
                else return (await _this.Request<UpdateAssetExpressionValueResponse>("/asset/expressionValues", "POST", props, headers), null, null);
            },
            UpdateAssetExpressionValue = async (props, headers) => await _this.Request<UpdateAssetExpressionValueResponse>("/asset/expressionValues", "POST", props, headers),
            UpdateAssetsExpressionValue = async (props, headers) => await _this.Request<UpdateAssetsExpressionValueResponse>("/asset/expressionValues", "POST", props, headers),
            UpdateCollectionAssetsExpressionValue = async (props, headers) => await _this.Request<BasicSuccessResponse>("/asset/expressionValues", "POST", props, headers),
            UpdateBulkExpressionValues = async (props, headers) => await _this.Request<UpdateBulkExpressionValuesResponse>("/asset/expressionValues", "POST", props, headers),
        };

        public AssetsSafeHandlers Safe = new AssetsSafeHandlers {
            Info = async (props, headers) => {
                try { return new BasicResult<(Asset, List<Asset>)> { Result = await _this.Info(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(Asset, List<Asset>)> { Error = e }; } },
            GetAsset = async (props, headers) => {
                try { return new BasicResult<Asset> { Result = await _this.GetAsset(props, headers) }; }
                catch (BasicError e) { return new BasicResult<Asset> { Error = e }; } },
            GetAssets = async (props, headers) => {
                try { return new BasicResult<List<Asset>> { Result = await _this.GetAssets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<Asset>> { Error = e }; } },
            User = async (props, headers) => {
                try { return new BasicResult<(List<Asset>, List<AssetIdOnly>, object)> { Result = await _this.User(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(List<Asset>, List<AssetIdOnly>, object)> { Error = e }; } },
            GetUserAssets = async (props, headers) => {
                try { return new BasicResult<List<Asset>> { Result = await _this.GetUserAssets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<Asset>> { Error = e }; } },
            GetUserAssetIds = async (props, headers) => {
                try { return new BasicResult<List<AssetIdOnly>> { Result = await _this.GetUserAssetIds(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<AssetIdOnly>> { Error = e }; } },
            GetUserAssetCounts = async (props, headers) => {
                try { return new BasicResult<object> { Result = await _this.GetUserAssetCounts(props, headers) }; }
                catch (BasicError e) { return new BasicResult<object> { Error = e }; } },
            GetUserCollectionAssets = async (props, headers) => {
                try { return new BasicResult<(List<Asset>, List<AssetIdOnly>, object)> { Result = await _this.GetUserCollectionAssets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(List<Asset>, List<AssetIdOnly>, object)> { Error = e }; } },
            GetUserCollectionsAssets = async (props, headers) => {
                try { return new BasicResult<(List<Asset>, List<AssetIdOnly>, object)> { Result = await _this.GetUserCollectionsAssets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(List<Asset>, List<AssetIdOnly>, object)> { Error = e }; } },
            GetUserSlotAssets = async (props, headers) => {
                try { return new BasicResult<(List<Asset>, List<AssetIdOnly>, object)> { Result = await _this.GetUserSlotAssets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(List<Asset>, List<AssetIdOnly>, object)> { Error = e }; } },
            GetUserSlotsAssets = async (props, headers) => {
                try { return new BasicResult<(List<Asset>, List<AssetIdOnly>, object)> { Result = await _this.GetUserSlotsAssets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(List<Asset>, List<AssetIdOnly>, object)> { Error = e }; } },
            GetAssetHistory = async (props, headers) => {
                try { return new BasicResult<List<AssetHistoryRecord>> { Result = await _this.GetAssetHistory(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<AssetHistoryRecord>> { Error = e }; } },
            GetAssetMarketHistory = async (props, headers) => {
                try { return new BasicResult<List<AssetHistoryRecord>> { Result = await _this.GetAssetMarketHistory(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<AssetHistoryRecord>> { Error = e }; } },
            GetAssetOwnershipHistory = async (props, headers) => {
                try { return new BasicResult<(List<AssetHistoryRecord>, List<UserAlias>)> { Result = await _this.GetAssetOwnershipHistory(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(List<AssetHistoryRecord>, List<UserAlias>)> { Error = e }; } },
            MintAssets = async (props, headers) => {
                try { return new BasicResult<bool> { Result = await _this.MintAssets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<bool> { Error = e }; } },
            Send = async (props, headers) => {
                try { return new BasicResult<(SendAssetResponseBody, SendAssetsResponseBody)> { Result = await _this.Send(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(SendAssetResponseBody, SendAssetsResponseBody)> { Error = e }; } },
            SendAsset = async (props, headers) => {
                try { return new BasicResult<SendAssetResponseBody> { Result = await _this.SendAsset(props, headers) }; }
                catch (BasicError e) { return new BasicResult<SendAssetResponseBody> { Error = e }; } },
            SendAssets = async (props, headers) => {
                try { return new BasicResult<SendAssetsResponseBody> { Result = await _this.SendAssets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<SendAssetsResponseBody> { Error = e }; } },
            SendCollectionAssets = async (props, headers) => {
                try { return new BasicResult<SendAssetsResponseBody> { Result = await _this.SendCollectionAssets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<SendAssetsResponseBody> { Error = e }; } },
            SendLowestAsset = async (props, headers) => {
                try { return new BasicResult<SendAssetResponseBody> { Result = await _this.SendLowestAsset(props, headers) }; }
                catch (BasicError e) { return new BasicResult<SendAssetResponseBody> { Error = e }; } },
            SendRandomAsset = async (props, headers) => {
                try { return new BasicResult<SendAssetResponseBody> { Result = await _this.SendRandomAsset(props, headers) }; }
                catch (BasicError e) { return new BasicResult<SendAssetResponseBody> { Error = e }; } },
            Update = async (props, headers) => {
                try { return new BasicResult<(UpdateAssetResponseBody, List<string>, string)> { Result = await _this.Update(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(UpdateAssetResponseBody, List<string>, string)> { Error = e }; } },
            UpdateAsset = async (props, headers) => {
                try { return new BasicResult<UpdateAssetResponseBody> { Result = await _this.UpdateAsset(props, headers) }; }
                catch (BasicError e) { return new BasicResult<UpdateAssetResponseBody> { Error = e }; } },
            UpdateAssets = async (props, headers) => {
                try { return new BasicResult<List<string>> { Result = await _this.UpdateAssets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<string>> { Error = e }; } },
            UpdateCollectionAssets = async (props, headers) => {
                try { return new BasicResult<string> { Result = await _this.UpdateCollectionAssets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<string> { Error = e }; } },
            ExpressionValues = async (props, headers) => {
                try { return new BasicResult<(string, List<string>, bool?)> { Result = await _this.ExpressionValues(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(string, List<string>, bool?)> { Error = e }; } },
            UpdateAssetExpressionValue = async (props, headers) => {
                try { return new BasicResult<string> { Result = await _this.UpdateAssetExpressionValue(props, headers) }; }
                catch (BasicError e) { return new BasicResult<string> { Error = e }; } },
            UpdateAssetsExpressionValue = async (props, headers) => {
                try { return new BasicResult<List<string>> { Result = await _this.UpdateAssetsExpressionValue(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<string>> { Error = e }; } },
            UpdateCollectionAssetsExpressionValue = async (props, headers) => {
                try { return new BasicResult<bool> { Result = await _this.UpdateCollectionAssetsExpressionValue(props, headers) }; }
                catch (BasicError e) { return new BasicResult<bool> { Error = e }; } },
            UpdateBulkExpressionValues = async (props, headers) => {
                try { return new BasicResult<List<BulkExpressionValueLog>> { Result = await _this.UpdateBulkExpressionValues(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<BulkExpressionValueLog>> { Error = e }; } }
        };
    }
}
