using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Users;

#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Listings 
{
    [DataContract]
    public class ListingTXIDs {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public ListingTXIDs() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string initial { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string paid { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string payment { get; set; }
    }
    [DataContract]
    public class Listing {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public Listing() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string listingId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionName { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long serial { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long liveTime { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public decimal price { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public UserAlias seller { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long createdAt { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long updatedAt { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currency { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public ListingTXIDs txids { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public UserAlias buyer { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long soldTime { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long cancelledTime { get; set; }
    }

    // public class ListingsCounts { [collectionId: string]: number };
    [DataContract]
    public class CollectionListingsStats {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public CollectionListingsStats() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long count { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public decimal lowest { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public decimal highest { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long newest { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long newestDate { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long oldest { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long oldestDate { get; set; }
    }
    // public class AppListingsStats { [collectionId: string]: CollectionListingsStats; };



    [DataContract]
    public class GetListingProps { 
        public GetListingProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string listingId { get; set; } 
    }

    [DataContract]
    public class GetUserListingsMinProps { 
        public GetUserListingsMinProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; } 
    }
    [DataContract]
    public class GetUserListingsProps : GetUserListingsMinProps { 
        public GetUserListingsProps() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? sellerOnly { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? buyerOnly { get; set; } 
    }
    [DataContract]
    public class GetUserCollectionListingsProps : GetUserListingsMinProps { 
        public GetUserCollectionListingsProps() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; } 
    }
    [DataContract]
    public class ListingUserProps : GetUserListingsProps { 
        public ListingUserProps() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; } 
    }
    [DataContract]
    public class GetUserHistoryProps { 
        public GetUserHistoryProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; } 
    }

    [DataContract]
    public class GetCollectionListingsBaseProps {
        public GetCollectionListingsBaseProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long lastUpdatedAt { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? collectionStats { get; set; }
    }
    [DataContract]
    public class GetCollectionListingsProps : GetCollectionListingsBaseProps { 
        public GetCollectionListingsProps() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; } 
    }
    [DataContract]
    public class GetCollectionsListingsProps : GetCollectionListingsBaseProps { 
        public GetCollectionsListingsProps() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> collectionIds { get; set; }
    }
    [DataContract]
    public class ListingCollectionProps : GetCollectionListingsBaseProps { 
        public ListingCollectionProps() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> collectionIds { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; } 
    }

    [DataContract]
    public class GetAppListingsProps {
        public GetAppListingsProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long lastUpdatedAt { get; set; }
    }
    [DataContract]
    public class ListingAppProps : GetAppListingsProps { 
        public ListingAppProps() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? collectionStats { get; set; } 
    }

    [DataContract]
    public class ListAssetBase {
        public ListAssetBase() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public decimal price { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long liveTime { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currency { get; set; }
    }
    [DataContract]
    public class ListAssetProps : ListAssetBase { 
        public ListAssetProps() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; } 
    }
    [DataContract]
    public class ListAssetsProps : ListAssetBase { 
        public ListAssetsProps() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
    }
    [DataContract]
    public class ListCollectionAssetsProps : ListAssetBase { 
        public ListCollectionAssetsProps() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; } 
    }
    [DataContract]
    public class ListingNewProps : ListAssetBase { 
        public ListingNewProps() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; } 
    }

    [DataContract]
    public class UpdateListingProps {
        public UpdateListingProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string listingId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public decimal price { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long liveTime { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currency { get; set; }
    }

    [DataContract]
    public class BuyListingProps {
        public BuyListingProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string listingId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public decimal price { get; set; }
    }

    [DataContract]
    public class RemoveListingProps {
        public RemoveListingProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string listingId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
    }

    [DataContract]
    public class GetListingResponse : BasicResponse<GetListingResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetListingResponse() : base() { }
    }
    [DataContract]
    public class GetListingResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetListingResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public Listing listing { get; set; }
    }
    [DataContract]
    public class GetListingsResponse : BasicResponse<GetListingsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetListingsResponse() : base() { }
    }
    [DataContract]
    public class GetListingsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetListingsResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<Listing> listing { get; set; }
    }
    [DataContract]
    public class GetListingCountsResponse : BasicResponse<GetListingCountsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetListingCountsResponse() : base() { }
    }
    [DataContract]
    public class GetListingCountsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetListingCountsResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public Dictionary<string, long> listing { get; set; }
    }
    [DataContract]
    public class GetUserListingsResponse : BasicResponse<GetUserListingsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetUserListingsResponse() : base() { }
    }
    [DataContract]
    public class GetUserListingsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetUserListingsResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<Listing> listings { get; set; }
    }
    [DataContract]
    public class GetUserListingCountsResponse : BasicResponse<GetUserListingCountsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetUserListingCountsResponse() : base() { }
    }
    [DataContract]
    public class GetUserListingCountsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetUserListingCountsResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public Dictionary<string, long> listings { get; set; }
    }
    [DataContract]
    public class GetAppListingsStatsResponse : BasicResponse<GetAppListingsStatsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetAppListingsStatsResponse() : base() { }
    }
    [DataContract]
    public class GetAppListingsStatsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetAppListingsStatsResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public Dictionary<string, CollectionListingsStats> listing { get; set; }
    }
    [DataContract]
    public class ListAssetResponseBodyListing {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public ListAssetResponseBodyListing() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string listingId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public decimal price { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long liveTime { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public UserAlias seller { get; set; }
    }

    [DataContract]
    public class ListAssetResponse : BasicResponse<ListAssetResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public ListAssetResponse() : base() { }
    }
    [DataContract]
    public class ListAssetResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public ListAssetResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public ListAssetResponseBodyListing listing { get; set; }
    }
    [DataContract]
    public class ListAssetsResponse : BasicResponse<ListAssetsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public ListAssetsResponse() : base() { }
    }
    [DataContract]
    public class ListAssetsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public ListAssetsResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
    }
    [DataContract]
    public class BuyListingResponse : BasicResponse<BuyListingResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public BuyListingResponse() : base() { }
    }
    [DataContract]
    public class BuyListingResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public BuyListingResponseBody() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool buy { get; set; }
    }


    public class ListingsRawDelegates {
        public delegate Task<GetListingResponse> GetListing(GetListingProps props, Dictionary<string, string> headers = null);
        public delegate Task<(GetUserListingsResponse, GetUserListingCountsResponse)> User(ListingUserProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetUserListingsResponse> GetUserListings(GetUserListingsMinProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetUserListingCountsResponse> GetUserListingsCounts(GetUserListingsMinProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetUserListingsResponse> GetUserCollectionListings(GetUserCollectionListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetUserListingCountsResponse> GetUserCollectionListingsCounts(GetUserCollectionListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetUserListingsResponse> GetUserSales(GetUserHistoryProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetUserListingCountsResponse> GetUserSalesCounts(GetUserHistoryProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetUserListingsResponse> GetUserPurchases(GetUserHistoryProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetUserListingCountsResponse> GetUserPurchasesCounts(GetUserHistoryProps props, Dictionary<string, string> headers = null);
        public delegate Task<(GetListingsResponse, GetListingCountsResponse)> Collection(ListingCollectionProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetListingsResponse> GetCollectionListings(GetCollectionListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetListingsResponse> GetCollectionsListings(GetCollectionsListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetListingCountsResponse> GetCollectionListingsCounts(GetCollectionListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetListingCountsResponse> GetCollectionsListingsCounts(GetCollectionsListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<(GetListingsResponse, GetListingCountsResponse, GetAppListingsStatsResponse)> App(ListingAppProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetListingsResponse> GetAppListings(GetAppListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetListingCountsResponse> GetAppListingsCounts(GetAppListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetAppListingsStatsResponse> GetAppListingsStats(GetAppListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<(ListAssetResponse, ListAssetsResponse)> New(ListingNewProps props, Dictionary<string, string> headers = null);
        public delegate Task<ListAssetResponse> ListAsset(ListAssetProps props, Dictionary<string, string> headers = null);
        public delegate Task<ListAssetsResponse> ListAssets(ListAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<ListAssetsResponse> ListCollectionAssets(ListCollectionAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicSuccessResponse> UpdateListing(UpdateListingProps props, Dictionary<string, string> headers = null);
        public delegate Task<BuyListingResponse> BuyListing(BuyListingProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicSuccessResponse> RemoveListing(RemoveListingProps props, Dictionary<string, string> headers = null);
    }

    public class ListingsRawHandlers {
        public ListingsRawDelegates.GetListing GetListing;
        public ListingsRawDelegates.User User;
        public ListingsRawDelegates.GetUserListings GetUserListings;
        public ListingsRawDelegates.GetUserListingsCounts GetUserListingsCounts;
        public ListingsRawDelegates.GetUserCollectionListings GetUserCollectionListings;
        public ListingsRawDelegates.GetUserCollectionListingsCounts GetUserCollectionListingsCounts;
        public ListingsRawDelegates.GetUserSales GetUserSales;
        public ListingsRawDelegates.GetUserSalesCounts GetUserSalesCounts;
        public ListingsRawDelegates.GetUserPurchases GetUserPurchases;
        public ListingsRawDelegates.GetUserPurchasesCounts GetUserPurchasesCounts;
        public ListingsRawDelegates.Collection Collection;
        public ListingsRawDelegates.GetCollectionListings GetCollectionListings;
        public ListingsRawDelegates.GetCollectionsListings GetCollectionsListings;
        public ListingsRawDelegates.GetCollectionListingsCounts GetCollectionListingsCounts;
        public ListingsRawDelegates.GetCollectionsListingsCounts GetCollectionsListingsCounts;
        public ListingsRawDelegates.App App;
        public ListingsRawDelegates.GetAppListings GetAppListings;
        public ListingsRawDelegates.GetAppListingsCounts GetAppListingsCounts;
        public ListingsRawDelegates.GetAppListingsStats GetAppListingsStats;
        public ListingsRawDelegates.New New;
        public ListingsRawDelegates.ListAsset ListAsset;
        public ListingsRawDelegates.ListAssets ListAssets;
        public ListingsRawDelegates.ListCollectionAssets ListCollectionAssets;
        public ListingsRawDelegates.UpdateListing UpdateListing;
        public ListingsRawDelegates.BuyListing BuyListing;
        public ListingsRawDelegates.RemoveListing RemoveListing;
    }

    public class ListingsSafeDelegates {
        public delegate Task<BasicResult<Listing>> GetListing(GetListingProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(List<Listing>, Dictionary<string, long>)>> User(ListingUserProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<Listing>>> GetUserListings(GetUserListingsMinProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<Dictionary<string, long>>> GetUserListingsCounts(GetUserListingsMinProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<Listing>>> GetUserCollectionListings(GetUserCollectionListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<Dictionary<string, long>>> GetUserCollectionListingsCounts(GetUserCollectionListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<Listing>>> GetUserSales(GetUserHistoryProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<Dictionary<string, long>>> GetUserSalesCounts(GetUserHistoryProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<Listing>>> GetUserPurchases(GetUserHistoryProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<Dictionary<string, long>>> GetUserPurchasesCounts(GetUserHistoryProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(List<Listing>, Dictionary<string, long>)>> Collection(ListingCollectionProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<Listing>>> GetCollectionListings(GetCollectionListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<Listing>>> GetCollectionsListings(GetCollectionsListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<Dictionary<string, long>>> GetCollectionListingsCounts(GetCollectionListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<Dictionary<string, long>>> GetCollectionsListingsCounts(GetCollectionsListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(List<Listing>, Dictionary<string, long>, Dictionary<string, CollectionListingsStats>)>> App(ListingAppProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<Listing>>> GetAppListings(GetAppListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<Dictionary<string, long>>> GetAppListingsCounts(GetAppListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<Dictionary<string, CollectionListingsStats>>> GetAppListingsStats(GetAppListingsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(ListAssetResponseBodyListing,  List<string>)>> New(ListingNewProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<ListAssetResponseBodyListing>> ListAsset(ListAssetProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<string>>> ListAssets(ListAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<string>>> ListCollectionAssets(ListCollectionAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<bool>> UpdateListing(UpdateListingProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<bool>> BuyListing(BuyListingProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<bool>> RemoveListing(RemoveListingProps props, Dictionary<string, string> headers = null);
    }

    public class ListingsSafeHandlers {
        public ListingsSafeDelegates.GetListing GetListing;
        public ListingsSafeDelegates.User User;
        public ListingsSafeDelegates.GetUserListings GetUserListings;
        public ListingsSafeDelegates.GetUserListingsCounts GetUserListingsCounts;
        public ListingsSafeDelegates.GetUserCollectionListings GetUserCollectionListings;
        public ListingsSafeDelegates.GetUserCollectionListingsCounts GetUserCollectionListingsCounts;
        public ListingsSafeDelegates.GetUserSales GetUserSales;
        public ListingsSafeDelegates.GetUserSalesCounts GetUserSalesCounts;
        public ListingsSafeDelegates.GetUserPurchases GetUserPurchases;
        public ListingsSafeDelegates.GetUserPurchasesCounts GetUserPurchasesCounts;
        public ListingsSafeDelegates.Collection Collection;
        public ListingsSafeDelegates.GetCollectionListings GetCollectionListings;
        public ListingsSafeDelegates.GetCollectionsListings GetCollectionsListings;
        public ListingsSafeDelegates.GetCollectionListingsCounts GetCollectionListingsCounts;
        public ListingsSafeDelegates.GetCollectionsListingsCounts GetCollectionsListingsCounts;
        public ListingsSafeDelegates.App App;
        public ListingsSafeDelegates.GetAppListings GetAppListings;
        public ListingsSafeDelegates.GetAppListingsCounts GetAppListingsCounts;
        public ListingsSafeDelegates.GetAppListingsStats GetAppListingsStats;
        public ListingsSafeDelegates.New New;
        public ListingsSafeDelegates.ListAsset ListAsset;
        public ListingsSafeDelegates.ListAssets ListAssets;
        public ListingsSafeDelegates.ListCollectionAssets ListCollectionAssets;
        public ListingsSafeDelegates.UpdateListing UpdateListing;
        public ListingsSafeDelegates.BuyListing BuyListing;
        public ListingsSafeDelegates.RemoveListing RemoveListing;
    }
}
