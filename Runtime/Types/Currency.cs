using System;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;

namespace AssetLayer.SDK.Currencies 
{
    public class Currency { 
        public Currency() { }
        // [JsonPropertyName("currencyId")]
        public string currencyId { get; set; }

        // [JsonPropertyName("currencyCode")]
        public string currencyCode { get; set; }

        // [JsonPropertyName("name")]
        public string name { get; set; }

        // [JsonPropertyName("currencyIcon")]
        public string currencyIcon { get; set; }
    }
}
