using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AssetLayer.SDK;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Core.Base;
using AssetLayer.SDK.Listings;
using AssetLayer.SDK.Utils;
using UnityEngine;

namespace AssetLayer.SDK.Core.Listings
{
    public class ListingsHandler : BaseHandler
    {
        private static ListingsHandler _this;
        public ListingsHandler(AssetLayerConfig config = null) : base(config) { _this = this; }
        
        public async Task<Listing> GetListing(GetListingProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetListing(props, headers)).body.listing; }
        public async Task<(List<Listing>, Dictionary<string, long>)> User(ListingUserProps props, Dictionary<string, string> headers = null) {
            if (props.countsOnly == true) return (null, (await this.Raw.User(props, headers)).Item2.body.listings); 
            else return ((await this.Raw.User(props, headers)).Item1.body.listings, null); }
        public async Task<List<Listing>> GetUserListings(GetUserListingsMinProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetUserListings(props, headers)).body.listings; }
        public async Task<Dictionary<string, long>> GetUserListingsCounts(GetUserListingsMinProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetUserListingsCounts(props, headers)).body.listings; }
        public async Task<List<Listing>> GetUserCollectionListings(GetUserCollectionListingsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetUserCollectionListings(props, headers)).body.listings; }
        public async Task<Dictionary<string, long>> GetUserCollectionListingsCounts(GetUserCollectionListingsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetUserCollectionListingsCounts(props, headers)).body.listings; }
        public async Task<List<Listing>> GetUserSales(GetUserHistoryProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetUserSales(props, headers)).body.listings; }
        public async Task<Dictionary<string, long>> GetUserSalesCounts(GetUserHistoryProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetUserSalesCounts(props, headers)).body.listings; }
        public async Task<List<Listing>> GetUserPurchases(GetUserHistoryProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetUserPurchases(props, headers)).body.listings; }
        public async Task<Dictionary<string, long>> GetUserPurchasesCounts(GetUserHistoryProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetUserPurchasesCounts(props, headers)).body.listings; }
        public async Task<(List<Listing>, Dictionary<string, long>)> Collection(ListingCollectionProps props, Dictionary<string, string> headers = null) {
            if (props.countsOnly == true) return (null, (await this.Raw.Collection(props, headers)).Item2.body.listing); 
            else return ((await this.Raw.Collection(props, headers)).Item1.body.listing, null); }
        public async Task<List<Listing>> GetCollectionListings(GetCollectionListingsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetCollectionListings(props, headers)).body.listing; }
        public async Task<List<Listing>> GetCollectionsListings(GetCollectionsListingsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetCollectionsListings(props, headers)).body.listing; }
        public async Task<Dictionary<string, long>> GetCollectionListingsCounts(GetCollectionListingsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetCollectionListingsCounts(props, headers)).body.listing; }
        public async Task<Dictionary<string, long>> GetCollectionsListingsCounts(GetCollectionsListingsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetCollectionsListingsCounts(props, headers)).body.listing; }
        public async Task<(List<Listing>, Dictionary<string, long>, Dictionary<string, CollectionListingsStats>)> App(ListingAppProps props, Dictionary<string, string> headers = null) {
            if (props.collectionStats == true && props.countsOnly == true) return (null, null, (await this.Raw.App(props, headers)).Item3.body.listing); 
            else if (props.countsOnly == true) return (null, (await this.Raw.App(props, headers)).Item2.body.listing, null); 
            else return ((await this.Raw.App(props, headers)).Item1.body.listing, null, null); }
        public async Task<List<Listing>> GetAppListings(GetAppListingsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetAppListings(props, headers)).body.listing; }
        public async Task<Dictionary<string, long>> GetAppListingsCounts(GetAppListingsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetAppListingsCounts(props, headers)).body.listing; }
        public async Task<Dictionary<string, CollectionListingsStats>> GetAppListingsStats(GetAppListingsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetAppListingsStats(props, headers)).body.listing; }
        public async Task<(ListAssetResponseBodyListing,  List<string>)> New(ListingNewProps props, Dictionary<string, string> headers = null) {
            if (props.collectionId != null || props.assetIds != null) return (null, (await this.Raw.New(props, headers)).Item2.body.assetIds); 
            else return ((await this.Raw.New(props, headers)).Item1.body.listing, null); }
        public async Task<ListAssetResponseBodyListing> ListAsset(ListAssetProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.ListAsset(props, headers)).body.listing; }
        public async Task<List<string>> ListAssets(ListAssetsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.ListAssets(props, headers)).body.assetIds; }
        public async Task<List<string>> ListCollectionAssets(ListCollectionAssetsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.ListCollectionAssets(props, headers)).body.assetIds; }
        public async Task<bool> UpdateListing(UpdateListingProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.UpdateListing(props, headers)).success; }
        public async Task<bool> BuyListing(BuyListingProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.BuyListing(props, headers)).body.buy; }
        public async Task<bool> RemoveListing(RemoveListingProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.RemoveListing(props, headers)).success; }


        public ListingsRawHandlers Raw = new ListingsRawHandlers {
            GetListing = async (props, headers) => await _this.Request<GetListingResponse>("/listing/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            User = async (props, headers) => {
                if (props.countsOnly == true) return (null, await _this.Request<GetUserListingCountsResponse>("/listing/user" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else return (await _this.Request<GetUserListingsResponse>("/listing/user" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
            },
            GetUserListings = async (props, headers) => await _this.Request<GetUserListingsResponse>("/listing/user" + AssetLayerUtils.PropsToQueryString(props, new { sellerOnly = true }, new { status = "active" }), "GET", null, headers),
            GetUserListingsCounts = async (props, headers) => await _this.Request<GetUserListingCountsResponse>("/listing/user" + AssetLayerUtils.PropsToQueryString(props, new { sellerOnly = true, countsOnly = true }, new { status = "active" }), "GET", null, headers),
            GetUserCollectionListings = async (props, headers) => await _this.Request<GetUserListingsResponse>("/listing/user" + AssetLayerUtils.PropsToQueryString(props, new { sellerOnly = true }, new { status = "active" }), "GET", null, headers),
            GetUserCollectionListingsCounts = async (props, headers) => await _this.Request<GetUserListingCountsResponse>("/listing/user" + AssetLayerUtils.PropsToQueryString(props, new { sellerOnly = true, countsOnly = true }, new { status = "active" }), "GET", null, headers),
            GetUserSales = async (props, headers) => await _this.Request<GetUserListingsResponse>("/listing/user" + AssetLayerUtils.PropsToQueryString(props, new { status = "sold", sellerOnly = true }), "GET", null, headers),
            GetUserSalesCounts = async (props, headers) => await _this.Request<GetUserListingCountsResponse>("/listing/user" + AssetLayerUtils.PropsToQueryString(props, new { status = "sold", sellerOnly = true, countsOnly = true }), "GET", null, headers),
            GetUserPurchases = async (props, headers) => await _this.Request<GetUserListingsResponse>("/listing/user" + AssetLayerUtils.PropsToQueryString(props, new { status = "sold", buyerOnly = true }), "GET", null, headers),
            GetUserPurchasesCounts = async (props, headers) => await _this.Request<GetUserListingCountsResponse>("/listing/user" + AssetLayerUtils.PropsToQueryString(props, new { status = "sold", buyerOnly = true, countsOnly = true }), "GET", null, headers),
            Collection = async (props, headers) => {
                if (props.countsOnly == true) return (null, await _this.Request<GetListingCountsResponse>("/listing/collection" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else return (await _this.Request<GetListingsResponse>("/listing/collection" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
            },
            GetCollectionListings = async (props, headers) => await _this.Request<GetListingsResponse>("/listing/collection" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetCollectionsListings = async (props, headers) => await _this.Request<GetListingsResponse>("/listing/collection" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetCollectionListingsCounts = async (props, headers) => await _this.Request<GetListingCountsResponse>("/listing/collection" + AssetLayerUtils.PropsToQueryString(props, new { countsOnly = true }), "GET", null, headers),
            GetCollectionsListingsCounts = async (props, headers) => await _this.Request<GetListingCountsResponse>("/listing/collection" + AssetLayerUtils.PropsToQueryString(props, new { countsOnly = true }), "GET", null, headers),
            App = async (props, headers) => {
                if (props.collectionStats == true && props.countsOnly == true) return (null, null, await _this.Request<GetAppListingsStatsResponse>("/listing/app" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else if (props.countsOnly == true) return (null, await _this.Request<GetListingCountsResponse>("/listing/app" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
                else return (await _this.Request<GetListingsResponse>("/listing/app" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null, null);
            },
            GetAppListings = async (props, headers) => await _this.Request<GetListingsResponse>("/listing/app" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetAppListingsCounts = async (props, headers) => await _this.Request<GetListingCountsResponse>("/listing/app" + AssetLayerUtils.PropsToQueryString(props, new { countsOnly = true }), "GET", null, headers),
            GetAppListingsStats = async (props, headers) => await _this.Request<GetAppListingsStatsResponse>("/listing/app" + AssetLayerUtils.PropsToQueryString(props, new { countsOnly = true, collectionStats = true }), "GET", null, headers),
            New = async (props, headers) => {
                if (props.collectionId != null || props.assetIds != null) return (null, await _this.Request<ListAssetsResponse>("/listing/new", "POST", props, headers));
                else return (await _this.Request<ListAssetResponse>("/listing/new", "POST", props, headers), null);
            },
            ListAsset = async (props, headers) => await _this.Request<ListAssetResponse>("/listing/new", "POST", props, headers),
            ListAssets = async (props, headers) => await _this.Request<ListAssetsResponse>("/listing/new", "POST", props, headers),
            ListCollectionAssets = async (props, headers) => await _this.Request<ListAssetsResponse>("/listing/new", "POST", props, headers),
            UpdateListing = async (props, headers) => await _this.Request<BasicSuccessResponse>("/listing/update", "PUT", props, headers),
            BuyListing = async (props, headers) => await _this.Request<BuyListingResponse>("/listing/buy", "POST", props, headers),
            RemoveListing = async (props, headers) => await _this.Request<BasicSuccessResponse>("/listing", "DELETE", props, headers),
        };

        public ListingsSafeHandlers Safe = new ListingsSafeHandlers {
            GetListing = async (props, headers) => {
                try { return new BasicResult<Listing> { Result = await _this.GetListing(props, headers) }; }
                catch (BasicError e) { return new BasicResult<Listing> { Error = e }; } },
            User = async (props, headers) => {
                try { return new BasicResult<(List<Listing>, Dictionary<string, long>)> { Result = await _this.User(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(List<Listing>, Dictionary<string, long>)> { Error = e }; } },
            GetUserListings = async (props, headers) => {
                try { return new BasicResult<List<Listing>> { Result = await _this.GetUserListings(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<Listing>> { Error = e }; } },
            GetUserListingsCounts = async (props, headers) => {
                try { return new BasicResult<Dictionary<string, long>> { Result = await _this.GetUserListingsCounts(props, headers) }; }
                catch (BasicError e) { return new BasicResult<Dictionary<string, long>> { Error = e }; } },
            GetUserCollectionListings = async (props, headers) => {
                try { return new BasicResult<List<Listing>> { Result = await _this.GetUserCollectionListings(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<Listing>> { Error = e }; } },
            GetUserCollectionListingsCounts = async (props, headers) => {
                try { return new BasicResult<Dictionary<string, long>> { Result = await _this.GetUserCollectionListingsCounts(props, headers) }; }
                catch (BasicError e) { return new BasicResult<Dictionary<string, long>> { Error = e }; } },
            GetUserSales = async (props, headers) => {
                try { return new BasicResult<List<Listing>> { Result = await _this.GetUserSales(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<Listing>> { Error = e }; } },
            GetUserSalesCounts = async (props, headers) => {
                try { return new BasicResult<Dictionary<string, long>> { Result = await _this.GetUserSalesCounts(props, headers) }; }
                catch (BasicError e) { return new BasicResult<Dictionary<string, long>> { Error = e }; } },
            GetUserPurchases = async (props, headers) => {
                try { return new BasicResult<List<Listing>> { Result = await _this.GetUserPurchases(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<Listing>> { Error = e }; } },
            GetUserPurchasesCounts = async (props, headers) => {
                try { return new BasicResult<Dictionary<string, long>> { Result = await _this.GetUserPurchasesCounts(props, headers) }; }
                catch (BasicError e) { return new BasicResult<Dictionary<string, long>> { Error = e }; } },
            Collection = async (props, headers) => {
                try { return new BasicResult<(List<Listing>, Dictionary<string, long>)> { Result = await _this.Collection(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(List<Listing>, Dictionary<string, long>)> { Error = e }; } },
            GetCollectionListings = async (props, headers) => {
                try { return new BasicResult<List<Listing>> { Result = await _this.GetCollectionListings(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<Listing>> { Error = e }; } },
            GetCollectionsListings = async (props, headers) => {
                try { return new BasicResult<List<Listing>> { Result = await _this.GetCollectionsListings(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<Listing>> { Error = e }; } },
            GetCollectionListingsCounts = async (props, headers) => {
                try { return new BasicResult<Dictionary<string, long>> { Result = await _this.GetCollectionListingsCounts(props, headers) }; }
                catch (BasicError e) { return new BasicResult<Dictionary<string, long>> { Error = e }; } },
            GetCollectionsListingsCounts = async (props, headers) => {
                try { return new BasicResult<Dictionary<string, long>> { Result = await _this.GetCollectionsListingsCounts(props, headers) }; }
                catch (BasicError e) { return new BasicResult<Dictionary<string, long>> { Error = e }; } },
            App = async (props, headers) => {
                try { return new BasicResult<(List<Listing>, Dictionary<string, long>, Dictionary<string, CollectionListingsStats>)> { Result = await _this.App(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(List<Listing>, Dictionary<string, long>, Dictionary<string, CollectionListingsStats>)> { Error = e }; } },
            GetAppListings = async (props, headers) => {
                try { return new BasicResult<List<Listing>> { Result = await _this.GetAppListings(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<Listing>> { Error = e }; } },
            GetAppListingsCounts = async (props, headers) => {
                try { return new BasicResult<Dictionary<string, long>> { Result = await _this.GetAppListingsCounts(props, headers) }; }
                catch (BasicError e) { return new BasicResult<Dictionary<string, long>> { Error = e }; } },
            GetAppListingsStats = async (props, headers) => {
                try { return new BasicResult<Dictionary<string, CollectionListingsStats>> { Result = await _this.GetAppListingsStats(props, headers) }; }
                catch (BasicError e) { return new BasicResult<Dictionary<string, CollectionListingsStats>> { Error = e }; } },
            New = async (props, headers) => {
                try { return new BasicResult<(ListAssetResponseBodyListing,  List<string>)> { Result = await _this.New(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(ListAssetResponseBodyListing,  List<string>)> { Error = e }; } },
            ListAsset = async (props, headers) => {
                try { return new BasicResult<ListAssetResponseBodyListing> { Result = await _this.ListAsset(props, headers) }; }
                catch (BasicError e) { return new BasicResult<ListAssetResponseBodyListing> { Error = e }; } },
            ListAssets = async (props, headers) => {
                try { return new BasicResult<List<string>> { Result = await _this.ListAssets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<string>> { Error = e }; } },
            ListCollectionAssets = async (props, headers) => {
                try { return new BasicResult<List<string>> { Result = await _this.ListCollectionAssets(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<string>> { Error = e }; } },
            UpdateListing = async (props, headers) => {
                try { return new BasicResult<bool> { Result = await _this.UpdateListing(props, headers) }; }
                catch (BasicError e) { return new BasicResult<bool> { Error = e }; } },
            BuyListing = async (props, headers) => {
                try { return new BasicResult<bool> { Result = await _this.BuyListing(props, headers) }; }
                catch (BasicError e) { return new BasicResult<bool> { Error = e }; } },
            RemoveListing = async (props, headers) => {
                try { return new BasicResult<bool> { Result = await _this.RemoveListing(props, headers) }; }
                catch (BasicError e) { return new BasicResult<bool> { Error = e }; } }
        };
    }
}
