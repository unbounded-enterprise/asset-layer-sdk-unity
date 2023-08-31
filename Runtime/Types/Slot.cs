using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Collections;
using AssetLayer.SDK.Expressions;
using AssetLayer.SDK.Slots;
#if UNITY_WEBGL
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Slots 
{
    [DataContract]
    public class Slot { 
        public Slot() { }
        // [JsonPropertyName("slotId")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; }
        // [JsonPropertyName("slotName")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string slotName { get; set; }
        // [JsonPropertyName("slotImage")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string slotImage { get; set; }
        // [JsonPropertyName("description")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string description { get; set; }
        // [JsonPropertyName("appId")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; }
        // [JsonPropertyName("acceptingCollections")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool acceptingCollections { get; set; }
        // [JsonPropertyName("isPublic")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool isPublic { get; set; }
        // [JsonPropertyName("collectionTypes")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string collectionTypes { get; set; }
        // [JsonPropertyName("createdAt")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long createdAt { get; set; }
        // [JsonPropertyName("updatedAt")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long updatedAt { get; set; }
        // [JsonPropertyName("collections")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> collections { get; set; }
        // [JsonPropertyName("expressions")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<string> expressions { get; set; }
    }

    [DataContract]
    public class SlotWithExpressions : Slot { 
        public SlotWithExpressions() : base() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public new Expression[] expressions { get; set; } 
    }

    [DataContract]
    public class SlotWithCollections : Slot {
        public SlotWithCollections() : base() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public new List<Collection> collections { get; set; }
    }

    [DataContract]
    public class SlotWithExpressionsAndCollections : Slot {
        public SlotWithExpressionsAndCollections() : base() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public new List<Expression> expressions { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public new List<Collection> collections { get; set; }
    }


    [DataContract]
    public class GetSlotProps { 
        public GetSlotProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; } 
    }


    [DataContract]
    public class GetSlotCollectionsProps { 
        public GetSlotCollectionsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? includeDeactivated { get; set; } 
    }

    [DataContract]
    public class GetSlotCollectionsAllProps : GetSlotCollectionsProps { 
        public GetSlotCollectionsAllProps() : base() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; } 
    }
    [DataContract]
    public class GetSlotExpressionsProps { 
        public GetSlotExpressionsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; } 
    }
    [DataContract]
    public class CreateExpressionProps { 
        public CreateExpressionProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string expressionTypeId { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string expressionName { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string description { get; set; } 
    }
    [DataContract]
    public class UpdateExpressionProps { 
        public UpdateExpressionProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string expressionId { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string expressionTypeId { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string expressionName { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string description { get; set; } 
    }


    [DataContract]
    public class GetSlotResponse : BasicResponse<GetSlotResponseBody> { public GetSlotResponse() : base() { } }

    [DataContract]
    public class GetSlotResponseBody { 
        public GetSlotResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public Slot slot { get; set; } 
    }

    [DataContract]
    public class GetSlotCollectionsResponse : BasicResponse<GetSlotCollectionsResponseBody> { public GetSlotCollectionsResponse() : base() { } }

    [DataContract]
    public class GetSlotCollectionsResponseBody { 
        public GetSlotCollectionsResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public SlotWithCollections slot { get; set; }
    }

    [DataContract]
    public class GetSlotCollectionsIdsResponse : BasicResponse<GetSlotCollectionsIdsResponseBody> { public GetSlotCollectionsIdsResponse() : base() { } }

    [DataContract]
    public class GetSlotCollectionsIdsResponseBody { 
        public GetSlotCollectionsIdsResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public Slot slot { get; set; } 
    }
    [DataContract]
    public class GetExpressionTypesResponse : BasicResponse<GetExpressionTypesResponseBody> { public GetExpressionTypesResponse() : base() { } }
    [DataContract]
    public class GetExpressionTypesResponseBody { 
        public GetExpressionTypesResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<ExpressionType> expressionTypes { get; set; } 
    }
    [DataContract]
    public class GetSlotExpressionsResponse : BasicResponse<GetSlotExpressionsResponseBody> { public GetSlotExpressionsResponse() : base() { } }
    [DataContract]
    public class GetSlotExpressionsResponseBody { 
        public GetSlotExpressionsResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<Expression> expressions { get; set; } 
    }
    [DataContract]
    public class CreateExpressionResponse : BasicResponse<CreateExpressionResponseBody> { public CreateExpressionResponse() : base() { } }
    [DataContract]
    public class CreateExpressionResponseBody { 
        public CreateExpressionResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string expressionId { get; set; } 
    }


    public class SlotsRawHandlers
    {
        public Func<GetSlotProps, Dictionary<string, string>, Task<GetSlotResponse>> GetSlot;
        public Func<GetSlotCollectionsAllProps, Dictionary<string, string>, Task<(GetSlotCollectionsResponse, GetSlotCollectionsIdsResponse)>> Collections;
        public Func<GetSlotCollectionsProps, Dictionary<string, string>, Task<GetSlotCollectionsResponse>> GetSlotCollections;
        public Func<GetSlotCollectionsProps, Dictionary<string, string>, Task<GetSlotCollectionsIdsResponse>> GetSlotCollectionIds;
        public Func<Dictionary<string, string>, Task<GetExpressionTypesResponse>> GetExpressionTypes;
        public Func<GetSlotExpressionsProps, Dictionary<string, string>, Task<GetSlotExpressionsResponse>> GetSlotExpressions;
        public Func<CreateExpressionProps, Dictionary<string, string>, Task<CreateExpressionResponse>> CreateExpression;
        public Func<UpdateExpressionProps, Dictionary<string, string>, Task<BasicSuccessResponse>> UpdateExpression;
    }

    public class SlotsSafeHandlers
    {
        public Func<GetSlotProps, Dictionary<string, string>, Task<BasicResult<Slot>>> GetSlot;
        public Func<GetSlotCollectionsAllProps, Dictionary<string, string>, Task<BasicResult<(List<Collection>, List<string>)>>> Collections;
        public Func<GetSlotCollectionsProps, Dictionary<string, string>, Task<BasicResult<List<Collection>>>> GetSlotCollections;
        public Func<GetSlotCollectionsProps, Dictionary<string, string>, Task<BasicResult<List<string>>>> GetSlotCollectionIds;
        public Func<Dictionary<string, string>, Task<BasicResult<List<ExpressionType>>>> GetExpressionTypes;
        public Func<GetSlotExpressionsProps, Dictionary<string, string>, Task<BasicResult<List<Expression>>>> GetSlotExpressions;
        public Func<CreateExpressionProps, Dictionary<string, string>, Task<BasicResult<string>>> CreateExpression;
        public Func<UpdateExpressionProps, Dictionary<string, string>, Task<BasicResult<bool>>> UpdateExpression;
    }
}
