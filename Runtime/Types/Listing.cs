using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Users;
#if UNITY_WEBGL
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Listings 
{
    [DataContract]
    public class ListingTXIDs {
        public ListingTXIDs() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string initial { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string paid { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string payment { get; set; }
    }
    [DataContract]
    public class Listing {
        public Listing() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string listingId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionName { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long serial { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long liveTime { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public decimal price { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string currency { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public UserAlias seller { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long createdAt { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long updatedAt { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public ListingTXIDs txids { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public UserAlias buyer { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long soldTime { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long cancelledTime { get; set; }
    }

    // public class ListingsCounts { [collectionId: string]: number };
    [DataContract]
    public class CollectionListingsStats {
        public CollectionListingsStats() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long count { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public decimal lowest { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public decimal highest { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long newest { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long newestDate { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long oldest { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long oldestDate { get; set; }
    }
    // public class AppListingsStats { [collectionId: string]: CollectionListingsStats; };



    [DataContract]
    public class GetListingProps { 
        public GetListingProps() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string listingId { get; set; } 
    }

    [DataContract]
    public class GetUserListingsMinProps { 
        public GetUserListingsMinProps() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; } 
    }
    [DataContract]
    public class GetUserListingsProps : GetUserListingsMinProps { 
        public GetUserListingsProps() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? sellerOnly { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? buyerOnly { get; set; } 
    }
    [DataContract]
    public class GetUserCollectionListingsProps : GetUserListingsMinProps { 
        public GetUserCollectionListingsProps() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; } 
    }
    [DataContract]
    public class ListingUserProps : GetUserListingsProps { 
        public ListingUserProps() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; } 
    }
    [DataContract]
    public class GetUserHistoryProps { 
        public GetUserHistoryProps() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; } 
    }

    [DataContract]
    public class GetCollectionListingsBaseProps {
        public GetCollectionListingsBaseProps() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long lastUpdatedAt { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? collectionStats { get; set; }
    }
    [DataContract]
    public class GetCollectionListingsProps : GetCollectionListingsBaseProps { 
        public GetCollectionListingsProps() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; } 
    }
    [DataContract]
    public class GetCollectionsListingsProps : GetCollectionListingsBaseProps { 
        public GetCollectionsListingsProps() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> collectionIds { get; set; }
    }
    [DataContract]
    public class ListingCollectionProps : GetCollectionListingsBaseProps { 
        public ListingCollectionProps() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> collectionIds { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; } 
    }

    [DataContract]
    public class GetAppListingsProps {
        public GetAppListingsProps() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long lastUpdatedAt { get; set; }
    }
    [DataContract]
    public class ListingAppProps : GetAppListingsProps { 
        public ListingAppProps() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? collectionStats { get; set; } 
    }

    [DataContract]
    public class ListAssetBase {
        public ListAssetBase() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public decimal price { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long liveTime { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
    }
    [DataContract]
    public class ListAssetProps : ListAssetBase { 
        public ListAssetProps() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; } 
    }
    [DataContract]
    public class ListAssetsProps : ListAssetBase { 
        public ListAssetsProps() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
    }
    [DataContract]
    public class ListCollectionAssetsProps : ListAssetBase { 
        public ListCollectionAssetsProps() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; } 
    }
    [DataContract]
    public class ListingNewProps : ListAssetBase { 
        public ListingNewProps() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; } 
    }

    [DataContract]
    public class UpdateListingProps {
        public UpdateListingProps() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string listingId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public decimal price { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long liveTime { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
    }

    [DataContract]
    public class BuyListingProps {
        public BuyListingProps() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string listingId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public decimal price { get; set; }
    }

    [DataContract]
    public class RemoveListingProps {
        public RemoveListingProps() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string listingId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
    }

    [DataContract]
    public class GetListingResponse : BasicResponse<GetListingResponseBody> { public GetListingResponse() : base() { } }
    [DataContract]
    public class GetListingResponseBody { 
        public GetListingResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public Listing listing { get; set; }
    }
    [DataContract]
    public class GetListingsResponse : BasicResponse<GetListingsResponseBody> { public GetListingsResponse() : base() { } }
    [DataContract]
    public class GetListingsResponseBody { 
        public GetListingsResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<Listing> listing { get; set; }
    }
    [DataContract]
    public class GetListingCountsResponse : BasicResponse<GetListingCountsResponseBody> { public GetListingCountsResponse() : base() { } }
    [DataContract]
    public class GetListingCountsResponseBody { 
        public GetListingCountsResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public Dictionary<string, long> listing { get; set; }
    }
    [DataContract]
    public class GetUserListingsResponse : BasicResponse<GetUserListingsResponseBody> { public GetUserListingsResponse() : base() { } }
    [DataContract]
    public class GetUserListingsResponseBody { 
        public GetUserListingsResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<Listing> listings { get; set; }
    }
    [DataContract]
    public class GetUserListingCountsResponse : BasicResponse<GetUserListingCountsResponseBody> { public GetUserListingCountsResponse() : base() { } }
    [DataContract]
    public class GetUserListingCountsResponseBody { 
        public GetUserListingCountsResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public Dictionary<string, long> listings { get; set; }
    }
    [DataContract]
    public class GetAppListingsStatsResponse : BasicResponse<GetAppListingsStatsResponseBody> { public GetAppListingsStatsResponse() : base() { } }
    [DataContract]
    public class GetAppListingsStatsResponseBody { 
        public GetAppListingsStatsResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public Dictionary<string, CollectionListingsStats> listing { get; set; }
    }
    [DataContract]
    public class ListAssetResponseBodyListing {
        public ListAssetResponseBodyListing() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string listingId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public decimal price { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long liveTime { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public UserAlias seller { get; set; }
    }

    [DataContract]
    public class ListAssetResponse : BasicResponse<ListAssetResponseBody> { public ListAssetResponse() : base() { } }
    [DataContract]
    public class ListAssetResponseBody { 
        public ListAssetResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public ListAssetResponseBodyListing listing { get; set; }
    }
    [DataContract]
    public class ListAssetsResponse : BasicResponse<ListAssetsResponseBody> { public ListAssetsResponse() : base() { } }
    [DataContract]
    public class ListAssetsResponseBody { 
        public ListAssetsResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
    }
    [DataContract]
    public class BuyListingResponse : BasicResponse<BuyListingResponseBody> { public BuyListingResponse() : base() { } }
    [DataContract]
    public class BuyListingResponseBody { 
        public BuyListingResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool buy { get; set; }
    }

    public class ListingsRawHandlers
    {
        public Func<GetListingProps, Dictionary<string, string>, Task<GetListingResponse>> GetListing;
        public Func<ListingUserProps, Dictionary<string, string>, Task<(GetListingsResponse, GetListingCountsResponse)>> User;
        public Func<GetUserListingsMinProps, Dictionary<string, string>, Task<GetUserListingsResponse>> GetUserListings;
        public Func<GetUserListingsMinProps, Dictionary<string, string>, Task<GetUserListingCountsResponse>> GetUserListingsCounts;
        public Func<GetUserCollectionListingsProps, Dictionary<string, string>, Task<GetUserListingsResponse>> GetUserCollectionListings;
        public Func<GetUserCollectionListingsProps, Dictionary<string, string>, Task<GetUserListingCountsResponse>> GetUserCollectionListingsCounts;
        public Func<GetUserHistoryProps, Dictionary<string, string>, Task<GetListingsResponse>> GetUserSales;
        public Func<GetUserHistoryProps, Dictionary<string, string>, Task<GetListingCountsResponse>> GetUserSalesCounts;
        public Func<GetUserHistoryProps, Dictionary<string, string>, Task<GetListingsResponse>> GetUserPurchases;
        public Func<GetUserHistoryProps, Dictionary<string, string>, Task<GetListingCountsResponse>> GetUserPurchasesCounts;
        public Func<ListingCollectionProps, Dictionary<string, string>, Task<(GetListingsResponse, GetListingCountsResponse)>> Collection;
        public Func<GetCollectionListingsProps, Dictionary<string, string>, Task<GetListingsResponse>> GetCollectionListings;
        public Func<GetCollectionsListingsProps, Dictionary<string, string>, Task<GetListingsResponse>> GetCollectionsListings;
        public Func<GetCollectionListingsProps, Dictionary<string, string>, Task<GetListingCountsResponse>> GetCollectionListingsCounts;
        public Func<GetCollectionsListingsProps, Dictionary<string, string>, Task<GetListingCountsResponse>> GetCollectionsListingsCounts;
        public Func<ListingAppProps, Dictionary<string, string>, Task<(GetListingsResponse, GetListingCountsResponse)>> App;
        public Func<GetAppListingsProps, Dictionary<string, string>, Task<GetListingsResponse>> GetAppListings;
        public Func<GetAppListingsProps, Dictionary<string, string>, Task<GetListingCountsResponse>> GetAppListingsCounts;
        public Func<GetAppListingsProps, Dictionary<string, string>, Task<GetAppListingsStatsResponse>> GetAppListingsStats;
        public Func<ListingNewProps, Dictionary<string, string>, Task<(ListAssetResponse, ListAssetsResponse)>> New;
        public Func<ListAssetProps, Dictionary<string, string>, Task<ListAssetResponse>> ListAsset;
        public Func<ListAssetsProps, Dictionary<string, string>, Task<ListAssetsResponse>> ListAssets;
        public Func<ListCollectionAssetsProps, Dictionary<string, string>, Task<ListAssetsResponse>> ListCollectionAssets;
        public Func<UpdateListingProps, Dictionary<string, string>, Task<BasicSuccessResponse>> UpdateListing;
        public Func<BuyListingProps, Dictionary<string, string>, Task<BuyListingResponse>> BuyListing;
        public Func<RemoveListingProps, Dictionary<string, string>, Task<BasicSuccessResponse>> RemoveListing;
    }

    public class ListingsSafeHandlers
    {
        public Func<GetListingProps, object, Task<BasicResult<Listing>>> GetListing;
        public Func<ListingUserProps, object, Task<BasicResult<(List<Listing>, Dictionary<string, long>)>>> User;
        public Func<GetUserListingsMinProps, object, Task<BasicResult<List<Listing>>>> GetUserListings;
        public Func<GetUserListingsMinProps, object, Task<BasicResult<Dictionary<string, long>>>> GetUserListingsCounts;
        public Func<GetUserCollectionListingsProps, object, Task<BasicResult<List<Listing>>>> GetUserCollectionListings;
        public Func<GetUserCollectionListingsProps, object, Task<BasicResult<Dictionary<string, long>>>> GetUserCollectionListingsCounts;
        public Func<GetUserHistoryProps, object, Task<BasicResult<List<Listing>>>> GetUserSales;
        public Func<GetUserHistoryProps, object, Task<BasicResult<Dictionary<string, long>>>> GetUserSalesCounts;
        public Func<GetUserHistoryProps, object, Task<BasicResult<List<Listing>>>> GetUserPurchases;
        public Func<GetUserHistoryProps, object, Task<BasicResult<Dictionary<string, long>>>> GetUserPurchasesCounts;
        public Func<ListingCollectionProps, object, Task<BasicResult<(List<Listing>, Dictionary<string, long>)>>> Collection;
        public Func<GetCollectionListingsProps, object, Task<BasicResult<List<Listing>>>> GetCollectionListings;
        public Func<GetCollectionsListingsProps, object, Task<BasicResult<List<Listing>>>> GetCollectionsListings;
        public Func<GetCollectionListingsProps, object, Task<BasicResult<Dictionary<string, long>>>> GetCollectionListingsCounts;
        public Func<GetCollectionsListingsProps, object, Task<BasicResult<Dictionary<string, long>>>> GetCollectionsListingsCounts;
        public Func<ListingAppProps, object, Task<BasicResult<(List<Listing>, Dictionary<string, long>)>>> App;
        public Func<GetAppListingsProps, object, Task<BasicResult<List<Listing>>>> GetAppListings;
        public Func<GetAppListingsProps, object, Task<BasicResult<Dictionary<string, long>>>> GetAppListingsCounts;
        public Func<GetAppListingsProps, object, Task<BasicResult<Dictionary<string, CollectionListingsStats>>>> GetAppListingsStats;
        public Func<ListingNewProps, object, Task<BasicResult<(ListAssetResponseBody,  List<string>)>>> New;
        public Func<ListAssetProps, object, Task<BasicResult<ListAssetResponseBody>>> ListAsset;
        public Func<ListAssetsProps, object, Task<BasicResult<List<string>>>> ListAssets;
        public Func<ListCollectionAssetsProps, object, Task<BasicResult<List<string>>>> ListCollectionAssets;
        public Func<UpdateListingProps, object, Task<BasicResult<bool>>> UpdateListing;
        public Func<BuyListingProps, object, Task<BasicResult<bool>>> BuyListing;
        public Func<RemoveListingProps, object, Task<BasicResult<bool>>> RemoveListing;
    }
}
