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

    public class CollectionsRawHandlers
    {
        public Func<CollectionInfoProps, Dictionary<string, string>, Task<GetCollectionsResponse>> Info;
        public Func<GetCollectionProps, Dictionary<string, string>, Task<GetCollectionsResponse>> GetCollection;
        public Func<GetCollectionsProps, Dictionary<string, string>, Task<GetCollectionsResponse>> GetCollections;
        public Func<CollectionAssetsProps, Dictionary<string, string>, Task<(GetCollectionAssetsResponse, GetCollectionAssetIdsResponse)>> Assets;
        public Func<GetCollectionAssetsProps, Dictionary<string, string>, Task<GetCollectionAssetsResponse>> GetCollectionAssets;
        public Func<GetCollectionAssetsProps, Dictionary<string, string>, Task<GetCollectionAssetIdsResponse>> GetCollectionAssetIds;
        public Func<CreateCollectionProps, Dictionary<string, string>, Task<CreateCollectionResponse>> CreateCollection;
        public Func<UpdateCollectionImageProps, Dictionary<string, string>, Task<BasicUploadedResponse>> UpdateCollectionImage;
        public Func<UpdateCollectionProps, Dictionary<string, string>, Task<BasicUpdatedResponse>> UpdateCollection;
        public Func<ActivateCollectionProps, Dictionary<string, string>, Task<BasicUpdatedResponse>> ActivateCollection;
        public Func<ActivateCollectionProps, Dictionary<string, string>, Task<BasicUpdatedResponse>> DeactivateCollection;
    }

    public class CollectionsSafeHandlers
    {
        public Func<CollectionInfoProps, object, Task<BasicResult<(Collection, List<Collection>)>>> Info;
        public Func<GetCollectionProps, object, Task<BasicResult<Collection>>> GetCollection;
        public Func<GetCollectionsProps, object, Task<BasicResult<List<Collection>>>> GetCollections;
        public Func<CollectionAssetsProps, object, Task<BasicResult<(List<Asset>, List<string>)>>> Assets;
        public Func<GetCollectionAssetsProps, object, Task<BasicResult<List<Asset>>>> GetCollectionAssets;
        public Func<GetCollectionAssetsProps, object, Task<BasicResult<List<AssetIdOnly>>>> GetCollectionAssetIds;
        public Func<CreateCollectionProps, object, Task<BasicResult<string>>> CreateCollection;
        public Func<UpdateCollectionImageProps, object, Task<BasicResult<bool>>> UpdateCollectionImage;
        public Func<UpdateCollectionProps, object, Task<BasicResult<bool>>> UpdateCollection;
        public Func<ActivateCollectionProps, object, Task<BasicResult<bool>>> ActivateCollection;
        public Func<ActivateCollectionProps, object, Task<BasicResult<bool>>> DeactivateCollection;
    }
}
