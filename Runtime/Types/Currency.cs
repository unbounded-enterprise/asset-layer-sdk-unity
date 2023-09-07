using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Currencies 
{
    [DataContract]
    public class Currency { 
        public Currency() { }
        
        // [JsonPropertyName("currencyId")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; }

        // [JsonPropertyName("currencyCode")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currencyCode { get; set; }

        // [JsonPropertyName("name")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string name { get; set; }

        // [JsonPropertyName("currencyIcon")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currencyIcon { get; set; }
    }

    [DataContract]
    public class CurrencySummary : Currency { 
        public CurrencySummary() : base() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public decimal totalIssued { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public int owners { get; set; } 
    }
    [DataContract]
    public class CurrencyWithBalance : Currency { 
        public CurrencyWithBalance() : base() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public decimal balance { get; set; } 
    }

    [DataContract]
    public class GetCurrencyProps { 
        public GetCurrencyProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; } 
    }
    [DataContract]
    public class GetCurrencyBalanceProps { 
        public GetCurrencyBalanceProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; } 
    }
    [DataContract]
    public class GetCurrencySummaryProps { 
        public GetCurrencySummaryProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; } 
    }
    [DataContract]
    public class IncreaseCurrencyBalanceProps { 
        public IncreaseCurrencyBalanceProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public decimal amount { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; } 
    }
    [DataContract]
    public class DecreaseCurrencyBalanceProps { 
        public DecreaseCurrencyBalanceProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public decimal amount { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string walletUserId { get; set; } 
    }
    [DataContract]
    public class TransferCurrencyProps { 
        public TransferCurrencyProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public decimal amount { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string receiver { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
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

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public Currency currency { get; set; } 
    }
    [DataContract]
    public class GetCurrencyBalanceResponse : BasicResponse<List<CurrencyWithBalance>> { 
        public GetCurrencyBalanceResponse() : base() { }
    }
    [DataContract]
    public class GetCurrencySummaryResponse : BasicResponse<GetCurrencySummaryResponseBody> { 
        public GetCurrencySummaryResponse() : base() { }
    }
    [DataContract]
    public class GetCurrencySummaryResponseBody { 
        public GetCurrencySummaryResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
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

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public decimal balance { get; set; } 
    }
    

    public class CurrenciesRawDelegates {
        public delegate Task<GetCurrencyResponse> Info(GetCurrencyProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetCurrencyResponse> GetCurrency(GetCurrencyProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetCurrencyBalanceResponse> Balance(GetCurrencyBalanceProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetCurrencyBalanceResponse> GetCurrencyBalance(GetCurrencyBalanceProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetCurrencySummaryResponse> GetCurrencySummary(GetCurrencySummaryProps props, Dictionary<string, string> headers = null);
        public delegate Task<IncreaseCurrencyBalanceResponse> IncreaseCurrencyBalance(IncreaseCurrencyBalanceProps props, Dictionary<string, string> headers = null);
        public delegate Task<DecreaseCurrencyBalanceResponse> DecreaseCurrencyBalance(DecreaseCurrencyBalanceProps props, Dictionary<string, string> headers = null);
        public delegate Task<TransferCurrencyResponse> TransferCurrency(TransferCurrencyProps props, Dictionary<string, string> headers = null);
    }

    public class CurrenciesRawHandlers {
        public CurrenciesRawDelegates.Info Info;
        public CurrenciesRawDelegates.GetCurrency GetCurrency;
        public CurrenciesRawDelegates.Balance Balance;
        public CurrenciesRawDelegates.GetCurrencyBalance GetCurrencyBalance;
        public CurrenciesRawDelegates.GetCurrencySummary GetCurrencySummary;
        public CurrenciesRawDelegates.IncreaseCurrencyBalance IncreaseCurrencyBalance;
        public CurrenciesRawDelegates.DecreaseCurrencyBalance DecreaseCurrencyBalance;
        public CurrenciesRawDelegates.TransferCurrency TransferCurrency;
    }

    public class CurrenciesSafeDelegates {
        public delegate Task<BasicResult<Currency>> Info(GetCurrencyProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<Currency>> GetCurrency(GetCurrencyProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<CurrencyWithBalance>>> Balance(GetCurrencyBalanceProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<CurrencyWithBalance>>> GetCurrencyBalance(GetCurrencyBalanceProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<CurrencySummary>>> GetCurrencySummary(GetCurrencySummaryProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<decimal>> IncreaseCurrencyBalance(IncreaseCurrencyBalanceProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<decimal>> DecreaseCurrencyBalance(DecreaseCurrencyBalanceProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<decimal>> TransferCurrency(TransferCurrencyProps props, Dictionary<string, string> headers = null);
    }

    public class CurrenciesSafeHandlers {
        public CurrenciesSafeDelegates.Info Info;
        public CurrenciesSafeDelegates.GetCurrency GetCurrency;
        public CurrenciesSafeDelegates.Balance Balance;
        public CurrenciesSafeDelegates.GetCurrencyBalance GetCurrencyBalance;
        public CurrenciesSafeDelegates.GetCurrencySummary GetCurrencySummary;
        public CurrenciesSafeDelegates.IncreaseCurrencyBalance IncreaseCurrencyBalance;
        public CurrenciesSafeDelegates.DecreaseCurrencyBalance DecreaseCurrencyBalance;
        public CurrenciesSafeDelegates.TransferCurrency TransferCurrency;
    }
}
