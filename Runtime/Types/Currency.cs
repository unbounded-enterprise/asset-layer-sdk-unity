using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
#if UNITY_WEBGL
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Currencies 
{
    [DataContract]
    public class Currency { 
        public Currency() { }
        // [JsonPropertyName("currencyId")]
        [Preserve][DataMember]
        public string currencyId { get; set; }

        // [JsonPropertyName("currencyCode")]
        [Preserve][DataMember]
        public string currencyCode { get; set; }

        // [JsonPropertyName("name")]
        [Preserve][DataMember]
        public string name { get; set; }

        // [JsonPropertyName("currencyIcon")]
        [Preserve][DataMember]
        public string currencyIcon { get; set; }
    }
}
