using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Expressions;

namespace AssetLayer.SDK.Slots 
{
    [DataContract]
    public class Slot { 
        // [JsonPropertyName("slotId")]
        [DataMember]
        public string slotId { get; set; }
        // [JsonPropertyName("slotName")]
        [DataMember]
        public string slotName { get; set; }
        // [JsonPropertyName("slotImage")]
        [DataMember]
        public string slotImage { get; set; }
        // [JsonPropertyName("description")]
        [DataMember]
        public string description { get; set; }
        // [JsonPropertyName("appId")]
        [DataMember]
        public string appId { get; set; }
        // [JsonPropertyName("acceptingCollections")]
        [DataMember]
        public bool acceptingCollections { get; set; }
        // [JsonPropertyName("isPublic")]
        [DataMember]
        public bool isPublic { get; set; }
        // [JsonPropertyName("collectionTypes")]
        [DataMember]
        public string collectionTypes { get; set; }
        // [JsonPropertyName("createdAt")]
        [DataMember]
        public long createdAt { get; set; }
        // [JsonPropertyName("updatedAt")]
        [DataMember]
        public long updatedAt { get; set; }
        // [JsonPropertyName("collections")]
        [DataMember]
        public List<string> collections { get; set; }
        // [JsonPropertyName("expressions")]
        [DataMember]
        public List<string> expressions { get; set; }
    }

    [DataContract]
    public class SlotWithExpressions : Slot { 
        [DataMember]
        public new Expression[] expressions { get; set; } 
    }
}
