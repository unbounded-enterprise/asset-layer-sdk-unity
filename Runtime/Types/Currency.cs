using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;

namespace AssetLayer.SDK.Currencies 
{
    [DataContract]
    public class Currency { 
        public Currency() { }
        // [JsonPropertyName("currencyId")]
        [DataMember]
        public string currencyId { get; set; }

        // [JsonPropertyName("currencyCode")]
        [DataMember]
        public string currencyCode { get; set; }

        // [JsonPropertyName("name")]
        [DataMember]
        public string name { get; set; }

        // [JsonPropertyName("currencyIcon")]
        [DataMember]
        public string currencyIcon { get; set; }
    }
}
