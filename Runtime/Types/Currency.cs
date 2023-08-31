using System;
using System.Collections.Generic;
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
    public class CurrencyWithBalance : Currency { 
        public CurrencyWithBalance() : base() { }

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

    [DataContract]
    public class GetCurrencyResponse : BasicResponse<GetCurrencyResponseBody> { 
        public GetCurrencyResponse() : base() { }
    }
    [DataContract]
    public class GetCurrencyResponseBody { 
        public GetCurrencyResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public Currency currency { get; set; } 
    }
    [DataContract]
    public class GetCurrencyBalanceResponse : BasicResponse<CurrencyWithBalance> { 
        public GetCurrencyBalanceResponse() : base() { }
    }
    [DataContract]
    public class GetCurrencySummaryResponse : BasicResponse<GetCurrencySummaryResponseBody> { 
        public GetCurrencySummaryResponse() : base() { }
    }
    [DataContract]
    public class GetCurrencySummaryResponseBody { 
        public GetCurrencySummaryResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<CurrencySummary> currencies { get; set; } 
    }
    [DataContract]
    public class IncreaseCurrencyBalanceResponse : BasicResponse<TransferCurrencyResponseBody> { 
        public IncreaseCurrencyBalanceResponse() : base() { }
    }
    [DataContract]
    public class DecreaseCurrencyBalanceResponse : BasicResponse<TransferCurrencyResponseBody> { 
        public DecreaseCurrencyBalanceResponse() : base() { }
    }
    [DataContract]
    public class TransferCurrencyResponse : BasicResponse<TransferCurrencyResponseBody> { 
        public TransferCurrencyResponse() : base() { }
    }
    [DataContract]
    public class TransferCurrencyResponseBody { 
        public TransferCurrencyResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public decimal balance { get; set; } 
    }
    

    public class CurrenciesRawHandlers {
        public Func<GetCurrencyProps, Dictionary<string, string>, Task<GetCurrencyResponse>> Info;
        public Func<GetCurrencyProps, Dictionary<string, string>, Task<GetCurrencyResponse>> GetCurrency;
        public Func<GetCurrencyBalanceProps, Dictionary<string, string>, Task<GetCurrencyBalanceResponse>> Balance;
        public Func<GetCurrencyBalanceProps, Dictionary<string, string>, Task<GetCurrencyBalanceResponse>> GetCurrencyBalance;
        public Func<GetCurrencySummaryProps, Dictionary<string, string>, Task<GetCurrencySummaryResponse>> GetCurrencySummary;
        public Func<IncreaseCurrencyBalanceProps, Dictionary<string, string>, Task<IncreaseCurrencyBalanceResponse>> IncreaseCurrencyBalance;
        public Func<DecreaseCurrencyBalanceProps, Dictionary<string, string>, Task<DecreaseCurrencyBalanceResponse>> DecreaseCurrencyBalance;
        public Func<TransferCurrencyProps, Dictionary<string, string>, Task<TransferCurrencyResponse>> TransferCurrency;
    }

    public class CurrenciesSafeHandlers
    {
        public Func<GetCurrencyProps, object, Task<BasicResult<Currency>>> Info;
        public Func<GetCurrencyProps, object, Task<BasicResult<Currency>>> GetCurrency;
        public Func<GetCurrencyBalanceProps, object, Task<BasicResult<CurrencyWithBalance>>> Balance;
        public Func<GetCurrencyBalanceProps, object, Task<BasicResult<CurrencyWithBalance>>> GetCurrencyBalance;
        public Func<GetCurrencySummaryProps, object, Task<BasicResult<List<CurrencySummary>>>> GetCurrencySummary;
        public Func<IncreaseCurrencyBalanceProps, object, Task<BasicResult<decimal>>> IncreaseCurrencyBalance;
        public Func<DecreaseCurrencyBalanceProps, object, Task<BasicResult<decimal>>> DecreaseCurrencyBalance;
        public Func<TransferCurrencyProps, object, Task<BasicResult<decimal>>> TransferCurrency;
    }
}
