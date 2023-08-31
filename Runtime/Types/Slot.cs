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
        [Preserve][DataMember]
        public string slotId { get; set; }
        // [JsonPropertyName("slotName")]
        [Preserve][DataMember]
        public string slotName { get; set; }
        // [JsonPropertyName("slotImage")]
        [Preserve][DataMember]
        public string slotImage { get; set; }
        // [JsonPropertyName("description")]
        [Preserve][DataMember]
        public string description { get; set; }
        // [JsonPropertyName("appId")]
        [Preserve][DataMember]
        public string appId { get; set; }
        // [JsonPropertyName("acceptingCollections")]
        [Preserve][DataMember]
        public bool acceptingCollections { get; set; }
        // [JsonPropertyName("isPublic")]
        [Preserve][DataMember]
        public bool isPublic { get; set; }
        // [JsonPropertyName("collectionTypes")]
        [Preserve][DataMember]
        public string collectionTypes { get; set; }
        // [JsonPropertyName("createdAt")]
        [Preserve][DataMember]
        public long createdAt { get; set; }
        // [JsonPropertyName("updatedAt")]
        [Preserve][DataMember]
        public long updatedAt { get; set; }
        // [JsonPropertyName("collections")]
        [Preserve][DataMember]
        public List<string> collections { get; set; }
        // [JsonPropertyName("expressions")]
        [Preserve][DataMember]
        public List<string> expressions { get; set; }
    }

    [DataContract]
    public class SlotWithExpressions : Slot { 
        public SlotWithExpressions() : base() { }
        [Preserve][DataMember]
        public new Expression[] expressions { get; set; } 
    }
}
