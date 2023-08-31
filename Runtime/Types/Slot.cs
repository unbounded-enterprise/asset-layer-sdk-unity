using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Expressions;
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
}
