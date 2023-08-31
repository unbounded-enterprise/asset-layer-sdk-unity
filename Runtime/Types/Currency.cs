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
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; }

        // [JsonPropertyName("currencyCode")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string currencyCode { get; set; }

        // [JsonPropertyName("name")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string name { get; set; }

        // [JsonPropertyName("currencyIcon")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string currencyIcon { get; set; }
    }
}
