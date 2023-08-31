using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Expressions;
using AssetLayer.SDK.Users;
#if UNITY_WEBGL
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Assets 
{
    [DataContract]
    public class Asset {
        public Asset() { }
        
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
        
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long serial { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionName { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public UserAlias user { get; set; }

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
        public List<ExpressionValue> expressionValues { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public Dictionary<string, object> properties { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string type { get; set; }
    }

    public class AssetIdOnly { 
        public AssetIdOnly() { }

        public string assetId { get; set; } 
        public long serial { get; set; }
    };
    
    [DataContract]
    public class AssetHistoryRecord {
        public AssetHistoryRecord() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string type { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long createdAt { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public UserAlias sender { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public UserAlias receiver { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public UserAlias user { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public object properties { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<ExpressionValue> expressionValues { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string expressionValueId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string expressionValue { get; set; }
    }
    
    // For GetAssetProps
    [DataContract]
    public class GetAssetProps {
        public GetAssetProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
    }

    // For GetAssetsProps
    [DataContract]
    public class GetAssetsProps {
        public GetAssetsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
    }

    // For GetAssetsAllProps
    [DataContract]
    public class AssetInfoProps {
        public AssetInfoProps() { }

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
    }

    // For GetUserAssetsBaseProps
    [DataContract]
    public class GetUserAssetsBaseProps {
        public GetUserAssetsBaseProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
    }

    // For GetUserAssetsAllProps
    [DataContract]
    public class AssetUserProps : GetUserAssetsBaseProps {
        public AssetUserProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; }
    }

    // For GetUserCollectionAssetsProps
    [DataContract]
    public class GetUserCollectionAssetsProps {
        public GetUserCollectionAssetsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string serials { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string range { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; }
    }

    // For GetUserCollectionsAssetsProps
    [DataContract]
    public class GetUserCollectionsAssetsProps {
        public GetUserCollectionsAssetsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> collectionIds { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; }
    }

    // For GetUserSlotAssetsProps
    [DataContract]
    public class GetUserSlotAssetsProps {
        public GetUserSlotAssetsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; }
    }

    // For GetUserSlotsAssetsProps
    [DataContract]
    public class GetUserSlotsAssetsProps {
        public GetUserSlotsAssetsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> slotIds { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? includeDeactivated { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; }
    }

    // For GetAssetHistoryProps
    [DataContract]
    public class GetAssetHistoryProps {
        public GetAssetHistoryProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public int? limit { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public int? start { get; set; }
    }

    // For GetAssetOwnershipHistoryProps
    [DataContract]
    public class GetAssetOwnershipHistoryProps : GetAssetHistoryProps {
        public GetAssetOwnershipHistoryProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? ownersOnly { get; set; }
    }

    // For MintAssetsProps
    [DataContract]
    public class MintAssetsProps {
        public MintAssetsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public int number { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string mintTo { get; set; }
    }

    // For SendAssetBase
    [DataContract]
    public class SendAssetBase {
        public SendAssetBase() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string receiver { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
    }

    // For SendAssetProps
    [DataContract]
    public class SendAssetProps : SendAssetBase {
        public SendAssetProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
    }

    // For SendAssetsProps
    [DataContract]
    public class SendAssetsProps : SendAssetBase {
        public SendAssetsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
    }

    // For SendCollectionAssetsProps
    [DataContract]
    public class SendCollectionAssetsProps : SendAssetBase {
        public SendCollectionAssetsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
    }

    // For SendAssetAllProps
    [DataContract]
    public class AssetSendProps : SendAssetBase {
        public AssetSendProps() { }

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

    // For SendLowestAssetProps
    [DataContract]
    public class SendLowestAssetProps {
        public SendLowestAssetProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string receiver { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
    }

    // For SendRandomAssetProps
    [DataContract]
    public class SendRandomAssetProps {
        public SendRandomAssetProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string receiver { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
    }

    // For UpdateAssetProps
    [DataContract]
    public class UpdateAssetProps {
        public UpdateAssetProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public object properties { get; set; }
    }

    // For UpdateAssetsProps
    [DataContract]
    public class UpdateAssetsProps {
        public UpdateAssetsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public object properties { get; set; }
    }

    // For UpdateCollectionAssetsProps
    [DataContract]
    public class UpdateCollectionAssetsProps {
        public UpdateCollectionAssetsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public object properties { get; set; }
    }

    // For UpdateAssetsAllProps
    [DataContract]
    public class AssetUpdateProps {
        public AssetUpdateProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public object properties { get; set; }

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
    public class GetAssetsResponse : BasicResponse<GetAssetsResponseBody> { 
        public GetAssetsResponse() : base() { } 
    }

    [DataContract]
    public class GetAssetsResponseBody {
        public GetAssetsResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<Asset> assets { get; set; } 
    }

    // For GetAssetIdsResponse
    [DataContract]
    public class GetAssetIdsResponse : BasicResponse<GetAssetIdsResponseBody> {
        public GetAssetIdsResponse() : base() { }
    }

    [DataContract]
    public class GetAssetIdsResponseBody {
        public GetAssetIdsResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<AssetIdOnly> assets { get; set; }
    }

    // For GetAssetCountsResponse
    [DataContract]
    public class GetAssetCountsResponse : BasicResponse<GetAssetCountsResponseBody> {
        public GetAssetCountsResponse() : base() { }
    }

    [DataContract]
    public class GetAssetCountsResponseBody {
        public GetAssetCountsResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public object assets { get; set; }
    }

    // For GetCollectionsAssetsResponse
    [DataContract]
    public class GetCollectionsAssetsResponse : BasicResponse<GetCollectionsAssetsResponseBody> {
        public GetCollectionsAssetsResponse() : base() { }
    }

    [DataContract]
    public class GetCollectionsAssetsResponseBody {
        public GetCollectionsAssetsResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<Asset> collections { get; set; }
    }

    // For GetCollectionsAssetIdsResponse
    [DataContract]
    public class GetCollectionsAssetIdsResponse : BasicResponse<GetCollectionsAssetIdsResponseBody> {
        public GetCollectionsAssetIdsResponse() : base() { }
    }

    [DataContract]
    public class GetCollectionsAssetIdsResponseBody {
        public GetCollectionsAssetIdsResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<AssetIdOnly> collections { get; set; }
    }

    // For GetCollectionsAssetCountsResponse
    [DataContract]
    public class GetCollectionsAssetCountsResponse : BasicResponse<GetCollectionsAssetCountsResponseBody> {
        public GetCollectionsAssetCountsResponse() : base() { }
    }

    [DataContract]
    public class GetCollectionsAssetCountsResponseBody {
        public GetCollectionsAssetCountsResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public object collections { get; set; }
    }

    // For GetAssetHistoryResponse
    [DataContract]
    public class GetAssetHistoryResponse : BasicResponse<GetAssetHistoryResponseBody> {
        public GetAssetHistoryResponse() : base() { }
    }

    [DataContract]
    public class GetAssetHistoryResponseBody {
        public GetAssetHistoryResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<AssetHistoryRecord> history { get; set; }
    }

    // For GetAssetMarketHistoryResponse
    [DataContract]
    public class GetAssetMarketHistoryResponse : BasicResponse<GetAssetMarketHistoryResponseBody> {
        public GetAssetMarketHistoryResponse() : base() { }
    }

    [DataContract]
    public class GetAssetMarketHistoryResponseBody {
        public GetAssetMarketHistoryResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<AssetHistoryRecord> history { get; set; }
    }

    // For GetAssetOwnershipHistoryResponse
    [DataContract]
    public class GetAssetOwnershipHistoryResponse : BasicResponse<GetAssetOwnershipHistoryResponseBody> {
        public GetAssetOwnershipHistoryResponse() : base() { }
    }

    [DataContract]
    public class GetAssetOwnershipHistoryResponseBody {
        public GetAssetOwnershipHistoryResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<UserAlias> history { get; set; }
    }

    // For SendAssetResponse
    [DataContract]
    public class SendAssetResponse : BasicResponse<SendAssetResponseBody> {
        public SendAssetResponse() : base() { }
    }

    [DataContract]
    public class SendAssetResponseBody {
        public SendAssetResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string to { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long serial { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
    }

    // For SendAssetsResponse
    [DataContract]
    public class SendAssetsResponse : BasicResponse<SendAssetsResponseBody> {
        public SendAssetsResponse() : base() { }
    }

    [DataContract]
    public class SendAssetsResponseBody {
        public SendAssetsResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string to { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
    }

    // For UpdateAssetResponse
    [DataContract]
    public class UpdateAssetResponse : BasicResponse<UpdateAssetResponseBody> {
        public UpdateAssetResponse() : base() { }
    }

    [DataContract]
    public class UpdateAssetResponseBody {
        public UpdateAssetResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public int serial { get; set; }
    }

    // For UpdateAssetsResponse
    [DataContract]
    public class UpdateAssetsResponse : BasicResponse<UpdateAssetsResponseBody> {
        public UpdateAssetsResponse() : base() { }
    }

    [DataContract]
    public class UpdateAssetsResponseBody {
        public UpdateAssetsResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
    }

    // For UpdateCollectionAssetsResponse
    [DataContract]
    public class UpdateCollectionAssetsResponse : BasicResponse<UpdateCollectionAssetsResponseBody> {
        public UpdateCollectionAssetsResponse() : base() { }
    }

    [DataContract]
    public class UpdateCollectionAssetsResponseBody {
        public UpdateCollectionAssetsResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
    }


    public class AssetsRawHandlers {
        public Func<AssetInfoProps, Dictionary<string, string>, Task<GetAssetsResponse>> Info;
        public Func<GetAssetProps, Dictionary<string, string>, Task<GetAssetsResponse>> GetAsset;
        public Func<GetAssetsProps, Dictionary<string, string>, Task<GetAssetsResponse>> GetAssets;
        public Func<AssetUserProps, Dictionary<string, string>, Task<(GetAssetsResponse, GetAssetIdsResponse, GetAssetCountsResponse)>> User;
        public Func<GetUserAssetsBaseProps, Dictionary<string, string>, Task<GetAssetsResponse>> GetUserAssets;
        public Func<GetUserAssetsBaseProps, Dictionary<string, string>, Task<GetAssetIdsResponse>> GetUserAssetIds;
        public Func<GetUserAssetsBaseProps, Dictionary<string, string>, Task<GetAssetCountsResponse>> GetUserAssetCounts;
        public Func<GetUserCollectionAssetsProps, Dictionary<string, string>, Task<(GetAssetsResponse, GetAssetIdsResponse, GetAssetCountsResponse)>> GetUserCollectionAssets;
        public Func<GetUserCollectionsAssetsProps, Dictionary<string, string>, Task<(GetCollectionsAssetsResponse, GetCollectionsAssetIdsResponse, GetCollectionsAssetCountsResponse)>> GetUserCollectionsAssets;
        public Func<GetUserSlotAssetsProps, Dictionary<string, string>, Task<(GetAssetsResponse, GetAssetIdsResponse, GetAssetCountsResponse)>> GetUserSlotAssets;
        public Func<GetUserSlotsAssetsProps, Dictionary<string, string>, Task<(GetAssetsResponse, GetAssetIdsResponse, GetAssetCountsResponse)>> GetUserSlotsAssets;
        public Func<GetAssetHistoryProps, Dictionary<string, string>, Task<GetAssetHistoryResponse>> GetAssetHistory;
        public Func<GetAssetHistoryProps, Dictionary<string, string>, Task<GetAssetMarketHistoryResponse>> GetAssetMarketHistory;
        public Func<GetAssetOwnershipHistoryProps, Dictionary<string, string>, Task<(GetAssetMarketHistoryResponse, GetAssetOwnershipHistoryResponse)>> GetAssetOwnershipHistory;
        public Func<MintAssetsProps, Dictionary<string, string>, Task<GetAssetsResponse>> MintAssets;
        public Func<AssetSendProps, Dictionary<string, string>, Task<(SendAssetResponse, SendAssetsResponse)>> Send;
        public Func<SendAssetProps, Dictionary<string, string>, Task<SendAssetResponse>> SendAsset;
        public Func<SendAssetsProps, Dictionary<string, string>, Task<SendAssetsResponse>> SendAssets;
        public Func<SendCollectionAssetsProps, Dictionary<string, string>, Task<SendAssetsResponse>> SendCollectionAssets;
        public Func<SendLowestAssetProps, Dictionary<string, string>, Task<SendAssetResponse>> SendLowestAsset;
        public Func<SendRandomAssetProps, Dictionary<string, string>, Task<SendAssetResponse>> SendRandomAsset;
        public Func<AssetUpdateProps, Dictionary<string, string>, Task<(UpdateAssetResponse, UpdateAssetsResponse, UpdateCollectionAssetsResponse)>> Update;
        public Func<UpdateAssetProps, Dictionary<string, string>, Task<UpdateAssetResponse>> UpdateAsset;
        public Func<UpdateAssetsProps, Dictionary<string, string>, Task<UpdateAssetsResponse>> UpdateAssets;
        public Func<UpdateCollectionAssetsProps, Dictionary<string, string>, Task<UpdateCollectionAssetsResponse>> UpdateCollectionAssets;
    }
    public class AssetsSafeHandlers
    {
        // public Func<AppInfoProps, Dictionary<string, string>, Task<BasicResult<(App, List<App>)>>> Info;
        /*
        public Func<GetAppProps, Dictionary<string, string>, Task<BasicResult<App>>> GetApp;
        public Func<GetAppsProps, Dictionary<string, string>, Task<BasicResult<App[]>>> GetApps;
        public Func<AppSlotsProps, Dictionary<string, string>, Task<BasicResult<(SlotWithExpressions[], string[])>>> Slots;
        public Func<GetAppSlotsProps, Dictionary<string, string>, Task<BasicResult<SlotWithExpressions[]>>> GetAppSlots;
        public Func<GetAppSlotsProps, Dictionary<string, string>, Task<BasicResult<string[]>>> GetAppSlotIds;
        public Func<AppsWithListingsProps, Dictionary<string, string>, Task<BasicResult<(AppWithListingsCount[], AppIdOnly[])>>> Listings;
        public Func<Dictionary<string, string>, Task<BasicResult<AppWithListingsCount[]>>> GetAppsWithListings;
        public Func<Dictionary<string, string>, Task<BasicResult<AppIdOnly[]>>> GetAppIdsWithListings;
        */
    }
}
