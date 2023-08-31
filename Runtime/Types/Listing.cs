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
        public double price { get; set; }
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
        public double lowest { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public double highest { get; set; }
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
    public class GetUserListingsAllProps : GetUserListingsProps { 
        public GetUserListingsAllProps() : base() { }
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
    public class GetCollectionsListingsAllProps : GetCollectionListingsBaseProps { 
        public GetCollectionsListingsAllProps() : base() { }
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
    public class GetAppListingsAllProps : GetAppListingsProps { 
        public GetAppListingsAllProps() : base() { }
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
    public class CreateListingBase {
        public CreateListingBase() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public double price { get; set; }
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
    public class ListAssetProps : CreateListingBase { 
        public ListAssetProps() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; } 
    }
    [DataContract]
    public class ListAssetsProps : CreateListingBase { 
        public ListAssetsProps() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
    }
    [DataContract]
    public class ListCollectionAssetsProps : CreateListingBase { 
        public ListCollectionAssetsProps() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; } 
    }
    [DataContract]
    public class CreateListingAllProps : CreateListingBase { 
        public CreateListingAllProps() : base() { }
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
        public double price { get; set; }
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
        public double price { get; set; }
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
    public class CreateListingResponseBodyListing {
        public CreateListingResponseBodyListing() { }
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
        public double price { get; set; }
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
    public class CreateListingResponse : BasicResponse<CreateListingResponseBody> { public CreateListingResponse() : base() { } }
    [DataContract]
    public class CreateListingResponseBody { 
        public CreateListingResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public CreateListingResponseBodyListing listing { get; set; }
    }
    [DataContract]
    public class CreateListingsResponse : BasicResponse<CreateListingsResponseBody> { public CreateListingsResponse() : base() { } }
    [DataContract]
    public class CreateListingsResponseBody { 
        public CreateListingsResponseBody() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
    }

    public class ListingsRawHandlers
    {
        
    }

    public class ListingsSafeHandlers
    {
        
    }
}
