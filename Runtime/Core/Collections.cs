using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AssetLayer.SDK;
using AssetLayer.SDK.Assets;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Collections;
using AssetLayer.SDK.Core.Base;
using AssetLayer.SDK.Utils;
using UnityEngine;

namespace AssetLayer.SDK.Core.Collections
{
    public class CollectionsHandler : BaseHandler
    {
        private static CollectionsHandler _this;
        public CollectionsHandler(AssetLayerConfig config = null) : base(config) { _this = this; }
        
        public async Task<(Collection, List<Collection>)> Info(CollectionInfoProps props, Dictionary<string, string> headers = null) { 
            if (props.collectionIds != null) return (null, (await this.Raw.Info(props, headers)).body.collections);
            else return ((await this.Raw.Info(props, headers)).body.collections[0], null); }
        public async Task<Collection> GetCollection(GetCollectionProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetCollection(props, headers)).body.collections[0]; }
        public async Task<List<Collection>> GetCollections(GetCollectionsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetCollections(props, headers)).body.collections; }
        public async Task<(List<Asset>, List<AssetIdOnly>)> Assets(CollectionAssetsProps props, Dictionary<string, string> headers = null) {
            if (props.idOnly == true) return (null, (await this.Raw.Assets(props, headers)).Item2.body.collection.assets);
            else return ((await this.Raw.Assets(props, headers)).Item1.body.collection.assets, null); }
        public async Task<List<Asset>> GetCollectionAssets(GetCollectionAssetsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetCollectionAssets(props, headers)).body.collection.assets; }
        public async Task<List<AssetIdOnly>> GetCollectionAssetIds(GetCollectionAssetsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetCollectionAssetIds(props, headers)).body.collection.assets; }
        public async Task<string> CreateCollection(CreateCollectionProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.CreateCollection(props, headers)).body.collectionId; }
        public async Task<bool> UpdateCollectionImage(UpdateCollectionImageProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.UpdateCollectionImage(props, headers)).uploaded; }
        public async Task<bool> UpdateCollection(UpdateCollectionProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.UpdateCollection(props, headers)).updated; }
        public async Task<bool> ActivateCollection(ActivateCollectionProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.ActivateCollection(props, headers)).updated; }
        public async Task<bool> DeactivateCollection(ActivateCollectionProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.DeactivateCollection(props, headers)).updated; }

        public CollectionsRawHandlers Raw = new CollectionsRawHandlers {
            Info = async (props, headers) => await _this.Request<GetCollectionsResponse>("/collection/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetCollection = async (props, headers) => await _this.Request<GetCollectionsResponse>("/collection/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetCollections = async (props, headers) => await _this.Request<GetCollectionsResponse>("/collection/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            Assets = async (props, headers) => {
                if (props.idOnly == true) return (null, await _this.Request<GetCollectionAssetIdsResponse>("/collection/assets" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else return (await _this.Request<GetCollectionAssetsResponse>("/collection/assets" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
            },
            GetCollectionAssets = async (props, headers) => await _this.Request<GetCollectionAssetsResponse>("/collection/assets" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetCollectionAssetIds = async (props, headers) => await _this.Request<GetCollectionAssetIdsResponse>("/collection/assets" + AssetLayerUtils.PropsToQueryString(props, new { idOnly = true }), "GET", null, headers),
            CreateCollection = async (props, headers) => await _this.Request<CreateCollectionResponse>("/collection/new", "POST", props, headers),
            UpdateCollectionImage = async (props, headers) => await _this.Request<BasicUploadedResponse>("/collection/image", "POST", props, headers),
            UpdateCollection = async (props, headers) => await _this.Request<BasicUpdatedResponse>("/collection/update", "PUT", props, headers),
            ActivateCollection = async (props, headers) => await _this.Request<BasicUpdatedResponse>("/collection/activate", "PUT", props, headers),
            DeactivateCollection = async (props, headers) => await _this.Request<BasicUpdatedResponse>("/collection/deactivate", "PUT", props, headers),
        };

        public CollectionsSafeHandlers Safe = new CollectionsSafeHandlers {
            Info = async (props, headers) => {
                try { return new BasicResult<(Collection, List<Collection>)> { Result = await _this.Info(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(Collection, List<Collection>)> { Error = e }; } },
            GetCollection = async (props, headers) => {
                try { return new BasicResult<Collection> { Result = await _this.GetCollection(props, headers) }; }
                catch (BasicError e) { return new BasicResult<Collection> { Error = e }; } },
            GetCollections = async (props, headers) => {
                try { return new BasicResult<List<Collection>> { Result = await _this.GetCollections(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<Collection>> { Error = e }; } },
            Assets = async (props, headers) => {
                try { return new BasicResult<(List<Asset>, List<AssetIdOnly>)> { Result = await _this.Assets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(List<Asset>, List<AssetIdOnly>)> { Error = e }; } },
            GetCollectionAssets = async (props, headers) => {
                try { return new BasicResult<List<Asset>> { Result = await _this.GetCollectionAssets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<Asset>> { Error = e }; } },
            GetCollectionAssetIds = async (props, headers) => {
                try { return new BasicResult<List<AssetIdOnly>> { Result = await _this.GetCollectionAssetIds(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<AssetIdOnly>> { Error = e }; } },
            CreateCollection = async (props, headers) => {
                try { return new BasicResult<string> { Result = await _this.CreateCollection(props, headers) }; }
                catch (BasicError e) { return new BasicResult<string> { Error = e }; } },
            UpdateCollectionImage = async (props, headers) => {
                try { return new BasicResult<bool> { Result = await _this.UpdateCollectionImage(props, headers) }; }
                catch (BasicError e) { return new BasicResult<bool> { Error = e }; } },
            UpdateCollection = async (props, headers) => {
                try { return new BasicResult<bool> { Result = await _this.UpdateCollection(props, headers) }; }
                catch (BasicError e) { return new BasicResult<bool> { Error = e }; } },
            ActivateCollection = async (props, headers) => {
                try { return new BasicResult<bool> { Result = await _this.ActivateCollection(props, headers) }; }
                catch (BasicError e) { return new BasicResult<bool> { Error = e }; } },
            DeactivateCollection = async (props, headers) => {
                try { return new BasicResult<bool> { Result = await _this.DeactivateCollection(props, headers) }; }
                catch (BasicError e) { return new BasicResult<bool> { Error = e }; } }
        };
    }
}
