using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Expressions;

namespace AssetLayer.SDK.Slots 
{
    public class Slot { 
        public Slot() { }
        // [JsonPropertyName("slotId")]
        public string slotId { get; set; }
        // [JsonPropertyName("slotName")]
        public string slotName { get; set; }
        // [JsonPropertyName("slotImage")]
        public string slotImage { get; set; }
        // [JsonPropertyName("description")]
        public string description { get; set; }
        // [JsonPropertyName("appId")]
        public string appId { get; set; }
        // [JsonPropertyName("acceptingCollections")]
        public bool acceptingCollections { get; set; }
        // [JsonPropertyName("isPublic")]
        public bool isPublic { get; set; }
        // [JsonPropertyName("collectionTypes")]
        public string collectionTypes { get; set; }
        // [JsonPropertyName("createdAt")]
        public long createdAt { get; set; }
        // [JsonPropertyName("updatedAt")]
        public long updatedAt { get; set; }
        // [JsonPropertyName("collections")]
        public List<string> collections { get; set; }
        // [JsonPropertyName("expressions")]
        public List<string> expressions { get; set; }
    }

    public class SlotWithExpressions : Slot { 
        public SlotWithExpressions() : base() { }
        public new Expression[] expressions { get; set; } 
    }
}
