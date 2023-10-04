using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Collections;
using AssetLayer.SDK.Expressions;
using AssetLayer.SDK.Slots;
#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Slots 
{
    [DataContract]
    public class SlotBase { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public SlotBase() { }
        // [JsonPropertyName("slotId")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; }
        // [JsonPropertyName("slotName")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string slotName { get; set; }
        // [JsonPropertyName("slotImage")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string slotImage { get; set; }
        // [JsonPropertyName("description")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string description { get; set; }
        // [JsonPropertyName("appId")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; }
        // [JsonPropertyName("acceptingCollections")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool acceptingCollections { get; set; }
        // [JsonPropertyName("isPublic")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool isPublic { get; set; }
        // [JsonPropertyName("collectionTypes")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionTypes { get; set; }
        // [JsonPropertyName("createdAt")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long createdAt { get; set; }
        // [JsonPropertyName("updatedAt")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long updatedAt { get; set; }
    }
    [DataContract]
    public class Slot : SlotBase { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public Slot() : base() { }
        // [JsonPropertyName("collections")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> collections { get; set; }
        // [JsonPropertyName("expressions")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> expressions { get; set; }
    }
    [DataContract]
    public class SlotWithExpressions : SlotBase { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public SlotWithExpressions() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> collections { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public Expression[] expressions { get; set; } 
    }

    [DataContract]
    public class SlotWithCollections : SlotBase {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public SlotWithCollections() : base() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<Collection> collections { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> expressions { get; set; }
    }

    [DataContract]
    public class SlotWithCollectionsAndExpressions : SlotBase {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public SlotWithCollectionsAndExpressions() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<Collection> collections { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<Expression> expressions { get; set; }
    }


    [DataContract]
    public class GetSlotProps { 
        public GetSlotProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; } 
    }


    [DataContract]
    public class GetSlotCollectionsProps { 
        public GetSlotCollectionsProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? includeDeactivated { get; set; } 
    }

    [DataContract]
    public class SlotCollectionsProps : GetSlotCollectionsProps { 
        public SlotCollectionsProps() : base() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; } 
    }
    [DataContract]
    public class GetSlotExpressionsProps { 
        public GetSlotExpressionsProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; } 
    }
    [DataContract]
    public class CreateExpressionProps { 
        public CreateExpressionProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionTypeId { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionName { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string description { get; set; } 
    }
    [DataContract]
    public class UpdateExpressionProps { 
        public UpdateExpressionProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionId { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionTypeId { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionName { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string description { get; set; } 
    }


    [DataContract]
    public class GetSlotResponse : BasicResponse<GetSlotResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetSlotResponse() : base() { }
    }

    [DataContract]
    public class GetSlotResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetSlotResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public Slot slot { get; set; } 
    }

    [DataContract]
    public class GetSlotCollectionsResponse : BasicResponse<GetSlotCollectionsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetSlotCollectionsResponse() : base() { }
    }

    [DataContract]
    public class GetSlotCollectionsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetSlotCollectionsResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public SlotWithCollections slot { get; set; }
    }

    [DataContract]
    public class GetSlotCollectionsIdsResponse : BasicResponse<GetSlotCollectionsIdsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetSlotCollectionsIdsResponse() : base() { }
    }

    [DataContract]
    public class GetSlotCollectionsIdsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetSlotCollectionsIdsResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public Slot slot { get; set; } 
    }
    [DataContract]
    public class GetExpressionTypesResponse : BasicResponse<GetExpressionTypesResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetExpressionTypesResponse() : base() { }
    }
    [DataContract]
    public class GetExpressionTypesResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetExpressionTypesResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<ExpressionType> expressionTypes { get; set; } 
    }
    [DataContract]
    public class GetSlotExpressionsResponse : BasicResponse<GetSlotExpressionsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetSlotExpressionsResponse() : base() { }
    }
    [DataContract]
    public class GetSlotExpressionsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetSlotExpressionsResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<Expression> expressions { get; set; } 
    }
    [DataContract]
    public class CreateExpressionResponse : BasicResponse<CreateExpressionResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public CreateExpressionResponse() : base() { }
    }
    [DataContract]
    public class CreateExpressionResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public CreateExpressionResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionId { get; set; } 
    }


    public class SlotsRawDelegates {
        public delegate Task<GetSlotResponse> GetSlot(GetSlotProps props, Dictionary<string, string> headers = null);
        public delegate Task<(GetSlotCollectionsResponse, GetSlotCollectionsIdsResponse)> Collections(SlotCollectionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetSlotCollectionsResponse> GetSlotCollections(GetSlotCollectionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetSlotCollectionsIdsResponse> GetSlotCollectionIds(GetSlotCollectionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetExpressionTypesResponse> GetExpressionTypes(Dictionary<string, string> headers = null);
        public delegate Task<GetSlotExpressionsResponse> GetSlotExpressions(GetSlotExpressionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<CreateExpressionResponse> CreateExpression(CreateExpressionProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicSuccessResponse> UpdateExpression(UpdateExpressionProps props, Dictionary<string, string> headers = null);
    }

    public class SlotsRawHandlers {
        public SlotsRawDelegates.GetSlot GetSlot;
        public SlotsRawDelegates.Collections Collections;
        public SlotsRawDelegates.GetSlotCollections GetSlotCollections;
        public SlotsRawDelegates.GetSlotCollectionIds GetSlotCollectionIds;
        public SlotsRawDelegates.GetExpressionTypes GetExpressionTypes;
        public SlotsRawDelegates.GetSlotExpressions GetSlotExpressions;
        public SlotsRawDelegates.CreateExpression CreateExpression;
        public SlotsRawDelegates.UpdateExpression UpdateExpression;
    }

    public class SlotsSafeDelegates {
        public delegate Task<BasicResult<Slot>> GetSlot(GetSlotProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(List<Collection>, List<string>)>> Collections(SlotCollectionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<Collection>>> GetSlotCollections(GetSlotCollectionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<string>>> GetSlotCollectionIds(GetSlotCollectionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<ExpressionType>>> GetExpressionTypes(Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<Expression>>> GetSlotExpressions(GetSlotExpressionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<string>> CreateExpression(CreateExpressionProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<bool>> UpdateExpression(UpdateExpressionProps props, Dictionary<string, string> headers = null);
    }

    public class SlotsSafeHandlers {
        public SlotsSafeDelegates.GetSlot GetSlot;
        public SlotsSafeDelegates.Collections Collections;
        public SlotsSafeDelegates.GetSlotCollections GetSlotCollections;
        public SlotsSafeDelegates.GetSlotCollectionIds GetSlotCollectionIds;
        public SlotsSafeDelegates.GetExpressionTypes GetExpressionTypes;
        public SlotsSafeDelegates.GetSlotExpressions GetSlotExpressions;
        public SlotsSafeDelegates.CreateExpression CreateExpression;
        public SlotsSafeDelegates.UpdateExpression UpdateExpression;
    }
}
