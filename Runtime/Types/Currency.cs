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

    [DataContract]
    public class CurrencySummary : Currency { 
        public CurrencySummary() : base() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public decimal totalIssued { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public int owners { get; set; } 
    }
    [DataContract]
    public class CurrencyBalance : Currency { 
        public CurrencyBalance() : base() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public decimal balance { get; set; } 
    }

    [DataContract]
    public class GetCurrencyProps { 
        public GetCurrencyProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; } 
    }
    [DataContract]
    public class GetCurrencyBalanceProps { 
        public GetCurrencyBalanceProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; } 
    }
    [DataContract]
    public class GetCurrencySummaryProps { 
        public GetCurrencySummaryProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; } 
    }
    [DataContract]
    public class IncreaseCurrencyBalanceProps { 
        public IncreaseCurrencyBalanceProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public decimal amount { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; } 
    }
    [DataContract]
    public class DecreaseCurrencyBalanceProps { 
        public DecreaseCurrencyBalanceProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public decimal amount { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; } 
    }
    [DataContract]
    public class TransferCurrencyProps { 
        public TransferCurrencyProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public decimal amount { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string receiver { get; set; } 
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; } 
    }

    public class CurrenciesRawHandlers
    {
        
    }

    public class CurrenciesSafeHandlers
    {
        
    }
}
