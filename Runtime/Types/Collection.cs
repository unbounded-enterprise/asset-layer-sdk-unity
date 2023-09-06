using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Assets;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Expressions;
using AssetLayer.SDK.Users;
#if UNITY_WEBGL
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Collections 
{
    [DataContract]
    public class Collection {
        public Collection() { }

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
        public string collectionImage { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionBanner { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string description { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public UserAlias creator { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long maximum { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long minted { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> tags { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public UserAlias royaltyRecipient { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
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
        public List<ExpressionValue> exampleExpressionValues { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string type { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public object properties { get; set; }
    }

    [DataContract]
    public class CollectionWithAssetIdOnlys : Collection {
        public CollectionWithAssetIdOnlys() : base() { }
        
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<AssetIdOnly> assets { get; set; } 
    }

    [DataContract]
    public class CollectionWithAssets : Collection {
        public CollectionWithAssets() : base() { }
        
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<Asset> assets { get; set; } 
    }



    [DataContract]
    public class GetCollectionProps 
    {
        public GetCollectionProps() { }
        
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
    }

    [DataContract]
    public class GetCollectionsProps
    {
        public GetCollectionsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> collectionIds { get; set; }
    }

    [DataContract]
    public class CollectionInfoProps { 
        public CollectionInfoProps() { }

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
    }

    [DataContract]
    public class GetCollectionAssetsProps { 
        public GetCollectionAssetsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<long> serials { get; set; }
    }

    [DataContract]
    public class CollectionAssetsProps : GetCollectionAssetsProps { 
        public CollectionAssetsProps() : base() { }
        
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; }
    }

    [DataContract]
    public class CreateCollectionProps {
        public CreateCollectionProps() { }
        
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionName { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string type { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long maximum { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string description { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> tags { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public UserAlias royaltyRecipient { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionImage { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionBanner { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public object properties { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; }
    }

    [DataContract]
    public class UpdateCollectionProps {
        public UpdateCollectionProps() { }
        
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string description { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> tags { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public UserAlias royaltyRecipient { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionImage { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionBanner { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public object properties { get; set; }
    }

    [DataContract]
    public class UpdateCollectionImageProps { 
        public UpdateCollectionImageProps() { }
        
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string value { get; set; }
    }

    [DataContract]
    public class ActivateCollectionProps { 
        public ActivateCollectionProps() { }
        
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
    }

    [DataContract]
    public class GetCollectionsResponse : BasicResponse<GetCollectionsResponseBody> { public GetCollectionsResponse() : base() { } }
    [DataContract]
    public class GetCollectionsResponseBody { 
        public GetCollectionsResponseBody() { }
        
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<Collection> collections { get; set; }
    }
    [DataContract]
    public class GetCollectionAssetsResponse : BasicResponse<GetCollectionAssetsResponseBody> { public GetCollectionAssetsResponse() : base() { } }
    [DataContract]
    public class GetCollectionAssetsResponseBody { 
        public GetCollectionAssetsResponseBody() { }
        
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public CollectionWithAssets collection { get; set; } 
    }
    [DataContract]
    public class GetCollectionAssetIdsResponse : BasicResponse<GetCollectionAssetIdsResponseBody> { public GetCollectionAssetIdsResponse() : base() { } }
    [DataContract]
    public class GetCollectionAssetIdsResponseBody { 
        public GetCollectionAssetIdsResponseBody() { }
        
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public CollectionWithAssetIdOnlys collection { get; set; }
    }
    [DataContract]
    public class CreateCollectionResponse : BasicResponse<CreateCollectionResponseBody> { public CreateCollectionResponse() : base() { } }
    [DataContract]
    public class CreateCollectionResponseBody { 
        public CreateCollectionResponseBody() { }
        
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
    }

    public class CollectionsRawDelegates {
        public delegate Task<GetCollectionsResponse> Info(CollectionInfoProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetCollectionsResponse> GetCollection(GetCollectionProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetCollectionsResponse> GetCollections(GetCollectionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<(GetCollectionAssetsResponse, GetCollectionAssetIdsResponse)> Assets(CollectionAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetCollectionAssetsResponse> GetCollectionAssets(GetCollectionAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetCollectionAssetIdsResponse> GetCollectionAssetIds(GetCollectionAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<CreateCollectionResponse> CreateCollection(CreateCollectionProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicUploadedResponse> UpdateCollectionImage(UpdateCollectionImageProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicUpdatedResponse> UpdateCollection(UpdateCollectionProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicUpdatedResponse> ActivateCollection(ActivateCollectionProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicUpdatedResponse> DeactivateCollection(ActivateCollectionProps props, Dictionary<string, string> headers = null);
    }

    public class CollectionsRawHandlers {
        public CollectionsRawDelegates.Info Info;
        public CollectionsRawDelegates.GetCollection GetCollection;
        public CollectionsRawDelegates.GetCollections GetCollections;
        public CollectionsRawDelegates.Assets Assets;
        public CollectionsRawDelegates.GetCollectionAssets GetCollectionAssets;
        public CollectionsRawDelegates.GetCollectionAssetIds GetCollectionAssetIds;
        public CollectionsRawDelegates.CreateCollection CreateCollection;
        public CollectionsRawDelegates.UpdateCollectionImage UpdateCollectionImage;
        public CollectionsRawDelegates.UpdateCollection UpdateCollection;
        public CollectionsRawDelegates.ActivateCollection ActivateCollection;
        public CollectionsRawDelegates.DeactivateCollection DeactivateCollection;
    }

    public class CollectionsSafeDelegates {
        public delegate Task<BasicResult<(Collection, List<Collection>)>> Info(CollectionInfoProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<Collection>> GetCollection(GetCollectionProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<Collection>>> GetCollections(GetCollectionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(List<Asset>, List<AssetIdOnly>)>> Assets(CollectionAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<Asset>>> GetCollectionAssets(GetCollectionAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<AssetIdOnly>>> GetCollectionAssetIds(GetCollectionAssetsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<string>> CreateCollection(CreateCollectionProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<bool>> UpdateCollectionImage(UpdateCollectionImageProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<bool>> UpdateCollection(UpdateCollectionProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<bool>> ActivateCollection(ActivateCollectionProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<bool>> DeactivateCollection(ActivateCollectionProps props, Dictionary<string, string> headers = null);
    }

    public class CollectionsSafeHandlers {
        public CollectionsSafeDelegates.Info Info;
        public CollectionsSafeDelegates.GetCollection GetCollection;
        public CollectionsSafeDelegates.GetCollections GetCollections;
        public CollectionsSafeDelegates.Assets Assets;
        public CollectionsSafeDelegates.GetCollectionAssets GetCollectionAssets;
        public CollectionsSafeDelegates.GetCollectionAssetIds GetCollectionAssetIds;
        public CollectionsSafeDelegates.CreateCollection CreateCollection;
        public CollectionsSafeDelegates.UpdateCollectionImage UpdateCollectionImage;
        public CollectionsSafeDelegates.UpdateCollection UpdateCollection;
        public CollectionsSafeDelegates.ActivateCollection ActivateCollection;
        public CollectionsSafeDelegates.DeactivateCollection DeactivateCollection;
    }
}
