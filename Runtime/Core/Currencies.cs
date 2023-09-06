using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AssetLayer.SDK;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Core.Base;
using AssetLayer.SDK.Currencies;
using AssetLayer.SDK.Utils;
using UnityEngine;

namespace AssetLayer.SDK.Core.Currencies
{
    public class CurrenciesHandler : BaseHandler
    {
        private static CurrenciesHandler _this;
        public CurrenciesHandler(AssetLayerConfig config = null) : base(config) { _this = this; }
        
        public async Task<Currency> Info(GetCurrencyProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.Info(props, headers)).body.currency; }
        public async Task<Currency> GetCurrency(GetCurrencyProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetCurrency(props, headers)).body.currency; }
        public async Task<CurrencyWithBalance> Balance(GetCurrencyBalanceProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.Balance(props, headers)).body; }
        public async Task<CurrencyWithBalance> GetCurrencyBalance(GetCurrencyBalanceProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetCurrencyBalance(props, headers)).body; }
        public async Task<List<CurrencySummary>> GetCurrencySummary(GetCurrencySummaryProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetCurrencySummary(props, headers)).body.currencies; }
        public async Task<decimal> IncreaseCurrencyBalance(IncreaseCurrencyBalanceProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.IncreaseCurrencyBalance(props, headers)).body.balance; }
        public async Task<decimal> DecreaseCurrencyBalance(DecreaseCurrencyBalanceProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.DecreaseCurrencyBalance(props, headers)).body.balance; }
        public async Task<decimal> TransferCurrency(TransferCurrencyProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.TransferCurrency(props, headers)).body.balance; }


        public CurrenciesRawHandlers Raw = new CurrenciesRawHandlers {
            Info = async (props, headers) => await _this.Request<GetCurrencyResponse>("/currency/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetCurrency = async (props, headers) => await _this.Request<GetCurrencyResponse>("/currency/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            Balance = async (props, headers) => await _this.Request<GetCurrencyBalanceResponse>("/currency/balance" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetCurrencyBalance = async (props, headers) => await _this.Request<GetCurrencyBalanceResponse>("/currency/balance" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetCurrencySummary = async (props, headers) => await _this.Request<GetCurrencySummaryResponse>("/currency/summary" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            IncreaseCurrencyBalance = async (props, headers) => await _this.Request<IncreaseCurrencyBalanceResponse>("/currency/increaseBalance", "POST", props, headers),
            DecreaseCurrencyBalance = async (props, headers) => await _this.Request<DecreaseCurrencyBalanceResponse>("/currency/decreaseBalance", "POST", props, headers),
            TransferCurrency = async (props, headers) => await _this.Request<TransferCurrencyResponse>("/currency/transfer", "POST", props, headers),
        };

        public CurrenciesSafeHandlers Safe = new CurrenciesSafeHandlers {
            Info = async (props, headers) => {
                try { return new BasicResult<Currency> { Result = await _this.Info(props, headers) }; }
                catch (BasicError e) { return new BasicResult<Currency> { Error = e }; } },
            GetCurrency = async (props, headers) => {
                try { return new BasicResult<Currency> { Result = await _this.GetCurrency(props, headers) }; }
                catch (BasicError e) { return new BasicResult<Currency> { Error = e }; } },
            Balance = async (props, headers) => {
                try { return new BasicResult<CurrencyWithBalance> { Result = await _this.Balance(props, headers) }; }
                catch (BasicError e) { return new BasicResult<CurrencyWithBalance> { Error = e }; } },
            GetCurrencyBalance = async (props, headers) => {
                try { return new BasicResult<CurrencyWithBalance> { Result = await _this.GetCurrencyBalance(props, headers) }; }
                catch (BasicError e) { return new BasicResult<CurrencyWithBalance> { Error = e }; } },
            GetCurrencySummary = async (props, headers) => {
                try { return new BasicResult<List<CurrencySummary>> { Result = await _this.GetCurrencySummary(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<CurrencySummary>> { Error = e }; } },
            IncreaseCurrencyBalance = async (props, headers) => {
                try { return new BasicResult<decimal> { Result = await _this.IncreaseCurrencyBalance(props, headers) }; }
                catch (BasicError e) { return new BasicResult<decimal> { Error = e }; } },
            DecreaseCurrencyBalance = async (props, headers) => {
                try { return new BasicResult<decimal> { Result = await _this.DecreaseCurrencyBalance(props, headers) }; }
                catch (BasicError e) { return new BasicResult<decimal> { Error = e }; } },
            TransferCurrency = async (props, headers) => {
                try { return new BasicResult<decimal> { Result = await _this.TransferCurrency(props, headers) }; }
                catch (BasicError e) { return new BasicResult<decimal> { Error = e }; } },
        };
    }
}
