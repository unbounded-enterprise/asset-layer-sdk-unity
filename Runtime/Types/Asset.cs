using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Expressions;
using AssetLayer.SDK.Users;
#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Assets 
{
    [DataContract]
    public class Asset {
        public Asset() { }
        
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
        
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long serial { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionName { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public UserAlias user { get; set; }

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
        public List<ExpressionValue> expressionValues { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public Dictionary<string, object> properties { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
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

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string type { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long createdAt { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public UserAlias sender { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public UserAlias receiver { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public UserAlias user { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public object properties { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<ExpressionValue> expressionValues { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionValueId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionValue { get; set; }
    }
    
    // For GetAssetProps
    [DataContract]
    public class GetAssetProps {
        public GetAssetProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
    }

    // For GetAssetsProps
    [DataContract]
    public class GetAssetsProps {
        public GetAssetsProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
    }

    // For GetAssetsAllProps
    [DataContract]
    public class AssetInfoProps {
        public AssetInfoProps() { }

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
    }

    // For GetUserAssetsBaseProps
    [DataContract]
    public class GetUserAssetsBaseProps {
        public GetUserAssetsBaseProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
    }

    // For GetUserAssetsAllProps
    [DataContract]
    public class AssetUserProps : GetUserAssetsBaseProps {
        public AssetUserProps() : base() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; }
    }

    // For GetUserCollectionAssetsProps
    [DataContract]
    public class GetUserCollectionAssetsProps {
        public GetUserCollectionAssetsProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string serials { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string range { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; }
    }

    // For GetUserCollectionsAssetsProps
    [DataContract]
    public class GetUserCollectionsAssetsProps {
        public GetUserCollectionsAssetsProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> collectionIds { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; }
    }

    // For GetUserSlotAssetsProps
    [DataContract]
    public class GetUserSlotAssetsProps {
        public GetUserSlotAssetsProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; }
    }

    // For GetUserSlotsAssetsProps
    [DataContract]
    public class GetUserSlotsAssetsProps {
        public GetUserSlotsAssetsProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> slotIds { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? includeDeactivated { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? countsOnly { get; set; }
    }

    // For GetAssetHistoryProps
    [DataContract]
    public class GetAssetHistoryProps {
        public GetAssetHistoryProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public int? limit { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public int? start { get; set; }
    }

    // For GetAssetOwnershipHistoryProps
    [DataContract]
    public class GetAssetOwnershipHistoryProps : GetAssetHistoryProps {
        public GetAssetOwnershipHistoryProps() : base() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? ownersOnly { get; set; }
    }

    // For MintAssetsProps
    [DataContract]
    public class MintAssetsProps {
        public MintAssetsProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public int number { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string mintTo { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
    }

    // For SendAssetBase
    [DataContract]
    public class SendAssetBase {
        public SendAssetBase() : base() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string receiver { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
    }

    // For SendAssetProps
    [DataContract]
    public class SendAssetProps : SendAssetBase {
        public SendAssetProps() : base() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
    }

    // For SendAssetsProps
    [DataContract]
    public class SendAssetsProps : SendAssetBase {
        public SendAssetsProps() : base() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
    }

    // For SendCollectionAssetsProps
    [DataContract]
    public class SendCollectionAssetsProps : SendAssetBase {
        public SendCollectionAssetsProps() : base() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
    }

    // For SendAssetAllProps
    [DataContract]
    public class AssetSendProps : SendAssetBase {
        public AssetSendProps() : base() { }

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

    // For SendLowestAssetProps
    [DataContract]
    public class SendLowestAssetProps {
        public SendLowestAssetProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string receiver { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
    }

    // For SendRandomAssetProps
    [DataContract]
    public class SendRandomAssetProps {
        public SendRandomAssetProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string receiver { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
    }

    // For UpdateAssetProps
    [DataContract]
    public class UpdateAssetProps {
        public UpdateAssetProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public object properties { get; set; }
    }

    // For UpdateAssetsProps
    [DataContract]
    public class UpdateAssetsProps {
        public UpdateAssetsProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public object properties { get; set; }
    }

    // For UpdateCollectionAssetsProps
    [DataContract]
    public class UpdateCollectionAssetsProps {
        public UpdateCollectionAssetsProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public object properties { get; set; }
    }

    // For UpdateAssetsAllProps
    [DataContract]
    public class AssetUpdateProps {
        public AssetUpdateProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public object properties { get; set; }

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
    public class UpdateExpressionValueBase {
        public UpdateExpressionValueBase() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionAttributeName { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string value { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionName { get; set; }
    }
    [DataContract]
    public class UpdateExpressionValuesProps : UpdateExpressionValueBase {
        public UpdateExpressionValuesProps() : base() { }

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
    public class UpdateAssetExpressionValueProps : UpdateExpressionValueBase {
        public UpdateAssetExpressionValueProps() : base() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
    }
    [DataContract]
    public class UpdateAssetsExpressionValueProps : UpdateExpressionValueBase {
        public UpdateAssetsExpressionValueProps() : base() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
    }
    [DataContract]
    public class UpdateCollectionAssetsExpressionValueProps : UpdateExpressionValueBase {
        public UpdateCollectionAssetsExpressionValueProps() : base() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
    }
    [DataContract]
    public class UpdateBulkExpressionValuesProps {
        public UpdateBulkExpressionValuesProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string value { get; set; }
    }



    [DataContract]
    public class GetAssetsResponse : BasicResponse<GetAssetsResponseBody> { 
        public GetAssetsResponse() : base() { } 
    }

    [DataContract]
    public class GetAssetsResponseBody {
        public GetAssetsResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
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

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
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

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public Dictionary<string, long> assets { get; set; }
    }

    // For GetCollectionsAssetsResponse
    [DataContract]
    public class GetCollectionsAssetsResponse : BasicResponse<GetCollectionsAssetsResponseBody> {
        public GetCollectionsAssetsResponse() : base() { }
    }

    [DataContract]
    public class GetCollectionsAssetsResponseBody {
        public GetCollectionsAssetsResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
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

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
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

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public Dictionary<string, long> collections { get; set; }
    }

    // For GetAssetHistoryResponse
    [DataContract]
    public class GetAssetHistoryResponse : BasicResponse<GetAssetHistoryResponseBody> {
        public GetAssetHistoryResponse() : base() { }
    }

    [DataContract]
    public class GetAssetHistoryResponseBody {
        public GetAssetHistoryResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
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

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
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

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
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

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string to { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long serial { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
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

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string to { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
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

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
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

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
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

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
    }
    [DataContract]
    public class UpdateAssetExpressionValueResponse : BasicResponse<UpdateAssetExpressionValueResponseBody> {
        public UpdateAssetExpressionValueResponse() : base() { }
    }
    [DataContract]
    public class UpdateAssetExpressionValueResponseBody {
        public UpdateAssetExpressionValueResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionValueId { get; set; }
    }
    [DataContract]
    public class UpdateAssetsExpressionValueResponse : BasicResponse<UpdateAssetsExpressionValueResponseBody> {
        public UpdateAssetsExpressionValueResponse() : base() { }
    }
    [DataContract]
    public class UpdateAssetsExpressionValueResponseBody {
        public UpdateAssetsExpressionValueResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> assetIds { get; set; }
    }
    [DataContract]
    public class UpdateBulkExpressionValuesResponse : BasicResponse<UpdateBulkExpressionValuesResponseBody> {
        public UpdateBulkExpressionValuesResponse() : base() { }
    }
    [DataContract]
    public class UpdateBulkExpressionValuesResponseBody {
        public UpdateBulkExpressionValuesResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<BulkExpressionValueLog> log { get; set; } // WARN! CAN ALSO BE FALSE
    }
    [DataContract]
    public class BulkExpressionValueLog {
        public BulkExpressionValueLog() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string filename { get; set; }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool success { get; set; }
    }

    public class AssetsRawDelegates {
        public delegate Task<GetAssetsResponse> Info(AssetInfoProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetAssetsResponse> GetAsset(GetAssetProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetAssetsResponse> GetAssets(GetAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<(GetAssetsResponse, GetAssetIdsResponse, GetAssetCountsResponse)> User(AssetUserProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetAssetsResponse> GetUserAssets(GetUserAssetsBaseProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetAssetIdsResponse> GetUserAssetIds(GetUserAssetsBaseProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetAssetCountsResponse> GetUserAssetCounts(GetUserAssetsBaseProps props, Dictionary<string, string> headers = null);
        public delegate Task<(GetAssetsResponse, GetAssetIdsResponse, GetAssetCountsResponse)> GetUserCollectionAssets(GetUserCollectionAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<(GetCollectionsAssetsResponse, GetCollectionsAssetIdsResponse, GetCollectionsAssetCountsResponse)> GetUserCollectionsAssets(GetUserCollectionsAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<(GetAssetsResponse, GetAssetIdsResponse, GetAssetCountsResponse)> GetUserSlotAssets(GetUserSlotAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<(GetAssetsResponse, GetAssetIdsResponse, GetAssetCountsResponse)> GetUserSlotsAssets(GetUserSlotsAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetAssetHistoryResponse> GetAssetHistory(GetAssetHistoryProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetAssetMarketHistoryResponse> GetAssetMarketHistory(GetAssetHistoryProps props, Dictionary<string, string> headers = null);
        public delegate Task<(GetAssetMarketHistoryResponse, GetAssetOwnershipHistoryResponse)> GetAssetOwnershipHistory(GetAssetOwnershipHistoryProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicSuccessResponse> MintAssets(MintAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<(SendAssetResponse, SendAssetsResponse)> Send(AssetSendProps props, Dictionary<string, string> headers = null);
        public delegate Task<SendAssetResponse> SendAsset(SendAssetProps props, Dictionary<string, string> headers = null);
        public delegate Task<SendAssetsResponse> SendAssets(SendAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<SendAssetsResponse> SendCollectionAssets(SendCollectionAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<SendAssetResponse> SendLowestAsset(SendLowestAssetProps props, Dictionary<string, string> headers = null);
        public delegate Task<SendAssetResponse> SendRandomAsset(SendRandomAssetProps props, Dictionary<string, string> headers = null);
        public delegate Task<(UpdateAssetResponse, UpdateAssetsResponse, UpdateCollectionAssetsResponse)> Update(AssetUpdateProps props, Dictionary<string, string> headers = null);
        public delegate Task<UpdateAssetResponse> UpdateAsset(UpdateAssetProps props, Dictionary<string, string> headers = null);
        public delegate Task<UpdateAssetsResponse> UpdateAssets(UpdateAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<UpdateCollectionAssetsResponse> UpdateCollectionAssets(UpdateCollectionAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<(UpdateAssetExpressionValueResponse, UpdateAssetsExpressionValueResponse, BasicSuccessResponse)> ExpressionValues (UpdateExpressionValuesProps props, Dictionary<string, string> headers = null);
        public delegate Task<UpdateAssetExpressionValueResponse> UpdateAssetExpressionValue (UpdateAssetExpressionValueProps props, Dictionary<string, string> headers = null);
        public delegate Task<UpdateAssetsExpressionValueResponse> UpdateAssetsExpressionValue (UpdateAssetsExpressionValueProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicSuccessResponse> UpdateCollectionAssetsExpressionValue (UpdateCollectionAssetsExpressionValueProps props, Dictionary<string, string> headers = null);
        public delegate Task<UpdateBulkExpressionValuesResponse> UpdateBulkExpressionValues (UpdateBulkExpressionValuesProps props, Dictionary<string, string> headers = null);
    }

    public class AssetsRawHandlers {
        public AssetsRawDelegates.Info Info;
        public AssetsRawDelegates.GetAsset GetAsset;
        public AssetsRawDelegates.GetAssets GetAssets;
        public AssetsRawDelegates.User User;
        public AssetsRawDelegates.GetUserAssets GetUserAssets;
        public AssetsRawDelegates.GetUserAssetIds GetUserAssetIds;
        public AssetsRawDelegates.GetUserAssetCounts GetUserAssetCounts;
        public AssetsRawDelegates.GetUserCollectionAssets GetUserCollectionAssets;
        public AssetsRawDelegates.GetUserCollectionsAssets GetUserCollectionsAssets;
        public AssetsRawDelegates.GetUserSlotAssets GetUserSlotAssets;
        public AssetsRawDelegates.GetUserSlotsAssets GetUserSlotsAssets;
        public AssetsRawDelegates.GetAssetHistory GetAssetHistory;
        public AssetsRawDelegates.GetAssetMarketHistory GetAssetMarketHistory;
        public AssetsRawDelegates.GetAssetOwnershipHistory GetAssetOwnershipHistory;
        public AssetsRawDelegates.MintAssets MintAssets;
        public AssetsRawDelegates.Send Send;
        public AssetsRawDelegates.SendAsset SendAsset;
        public AssetsRawDelegates.SendAssets SendAssets;
        public AssetsRawDelegates.SendCollectionAssets SendCollectionAssets;
        public AssetsRawDelegates.SendLowestAsset SendLowestAsset;
        public AssetsRawDelegates.SendRandomAsset SendRandomAsset;
        public AssetsRawDelegates.Update Update;
        public AssetsRawDelegates.UpdateAsset UpdateAsset;
        public AssetsRawDelegates.UpdateAssets UpdateAssets;
        public AssetsRawDelegates.UpdateCollectionAssets UpdateCollectionAssets;
        public AssetsRawDelegates.ExpressionValues ExpressionValues;
        public AssetsRawDelegates.UpdateAssetExpressionValue UpdateAssetExpressionValue;
        public AssetsRawDelegates.UpdateAssetsExpressionValue UpdateAssetsExpressionValue;
        public AssetsRawDelegates.UpdateCollectionAssetsExpressionValue UpdateCollectionAssetsExpressionValue;
        public AssetsRawDelegates.UpdateBulkExpressionValues UpdateBulkExpressionValues;
    }

    public class AssetsSafeDelegates {
        public delegate Task<BasicResult<(Asset, List<Asset>)>> Info(AssetInfoProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<Asset>> GetAsset(GetAssetProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<Asset>>> GetAssets(GetAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(List<Asset>, List<AssetIdOnly>, Dictionary<string, long>)>> User(AssetUserProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<Asset>>> GetUserAssets(GetUserAssetsBaseProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<AssetIdOnly>>> GetUserAssetIds(GetUserAssetsBaseProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<Dictionary<string, long>>> GetUserAssetCounts(GetUserAssetsBaseProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(List<Asset>, List<AssetIdOnly>, Dictionary<string, long>)>> GetUserCollectionAssets(GetUserCollectionAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(List<Asset>, List<AssetIdOnly>, Dictionary<string, long>)>> GetUserCollectionsAssets(GetUserCollectionsAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(List<Asset>, List<AssetIdOnly>, Dictionary<string, long>)>> GetUserSlotAssets(GetUserSlotAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(List<Asset>, List<AssetIdOnly>, Dictionary<string, long>)>> GetUserSlotsAssets(GetUserSlotsAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<AssetHistoryRecord>>> GetAssetHistory(GetAssetHistoryProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<AssetHistoryRecord>>> GetAssetMarketHistory(GetAssetHistoryProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(List<AssetHistoryRecord>, List<UserAlias>)>> GetAssetOwnershipHistory(GetAssetOwnershipHistoryProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<bool>> MintAssets(MintAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(SendAssetResponseBody, SendAssetsResponseBody)>> Send(AssetSendProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<SendAssetResponseBody>> SendAsset(SendAssetProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<SendAssetsResponseBody>> SendAssets(SendAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<SendAssetsResponseBody>> SendCollectionAssets(SendCollectionAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<SendAssetResponseBody>> SendLowestAsset(SendLowestAssetProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<SendAssetResponseBody>> SendRandomAsset(SendRandomAssetProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(UpdateAssetResponseBody, List<string>, string)>> Update(AssetUpdateProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<UpdateAssetResponseBody>> UpdateAsset(UpdateAssetProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<string>>> UpdateAssets(UpdateAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<string>> UpdateCollectionAssets(UpdateCollectionAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(string, List<string>, bool?)>> ExpressionValues (UpdateExpressionValuesProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<string>> UpdateAssetExpressionValue (UpdateAssetExpressionValueProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<string>>> UpdateAssetsExpressionValue (UpdateAssetsExpressionValueProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<bool>> UpdateCollectionAssetsExpressionValue (UpdateCollectionAssetsExpressionValueProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<BulkExpressionValueLog>>> UpdateBulkExpressionValues (UpdateBulkExpressionValuesProps props, Dictionary<string, string> headers = null);

    }

    public class AssetsSafeHandlers {
        public AssetsSafeDelegates.Info Info;
        public AssetsSafeDelegates.GetAsset GetAsset;
        public AssetsSafeDelegates.GetAssets GetAssets;
        public AssetsSafeDelegates.User User;
        public AssetsSafeDelegates.GetUserAssets GetUserAssets;
        public AssetsSafeDelegates.GetUserAssetIds GetUserAssetIds;
        public AssetsSafeDelegates.GetUserAssetCounts GetUserAssetCounts;
        public AssetsSafeDelegates.GetUserCollectionAssets GetUserCollectionAssets;
        public AssetsSafeDelegates.GetUserCollectionsAssets GetUserCollectionsAssets;
        public AssetsSafeDelegates.GetUserSlotAssets GetUserSlotAssets;
        public AssetsSafeDelegates.GetUserSlotsAssets GetUserSlotsAssets;
        public AssetsSafeDelegates.GetAssetHistory GetAssetHistory;
        public AssetsSafeDelegates.GetAssetMarketHistory GetAssetMarketHistory;
        public AssetsSafeDelegates.GetAssetOwnershipHistory GetAssetOwnershipHistory;
        public AssetsSafeDelegates.MintAssets MintAssets;
        public AssetsSafeDelegates.Send Send;
        public AssetsSafeDelegates.SendAsset SendAsset;
        public AssetsSafeDelegates.SendAssets SendAssets;
        public AssetsSafeDelegates.SendCollectionAssets SendCollectionAssets;
        public AssetsSafeDelegates.SendLowestAsset SendLowestAsset;
        public AssetsSafeDelegates.SendRandomAsset SendRandomAsset;
        public AssetsSafeDelegates.Update Update;
        public AssetsSafeDelegates.UpdateAsset UpdateAsset;
        public AssetsSafeDelegates.UpdateAssets UpdateAssets;
        public AssetsSafeDelegates.UpdateCollectionAssets UpdateCollectionAssets;
        public AssetsSafeDelegates.ExpressionValues ExpressionValues;
        public AssetsSafeDelegates.UpdateAssetExpressionValue UpdateAssetExpressionValue;
        public AssetsSafeDelegates.UpdateAssetsExpressionValue UpdateAssetsExpressionValue;
        public AssetsSafeDelegates.UpdateCollectionAssetsExpressionValue UpdateCollectionAssetsExpressionValue;
        public AssetsSafeDelegates.UpdateBulkExpressionValues UpdateBulkExpressionValues;
    }
}
