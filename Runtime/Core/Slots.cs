using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AssetLayer.SDK;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Collections;
using AssetLayer.SDK.Core.Base;
using AssetLayer.SDK.Expressions;
using AssetLayer.SDK.Slots;
using AssetLayer.SDK.Utils;

namespace AssetLayer.SDK.Core.Slots
{
    public class SlotsHandler : BaseHandler
    {
        private static SlotsHandler _this;
        public SlotsHandler(AssetLayerConfig config = null) : base(config) { _this = this; }
        
        public async Task<Slot> GetSlot(GetSlotProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetSlot(props, headers)).body.slot; }
        public async Task<(List<Collection>, List<string>)> Collections(SlotCollectionsProps props, Dictionary<string, string> headers = null) {
            if (props.idOnly == true) return (null, (await this.Raw.Collections(props, headers)).Item2.body.slot.collections);
            else return ((await this.Raw.Collections(props, headers)).Item1.body.slot.collections, null); }
        public async Task<List<Collection>> GetSlotCollections(GetSlotCollectionsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetSlotCollections(props, headers)).body.slot.collections; }
        public async Task<List<string>> GetSlotCollectionIds(GetSlotCollectionsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetSlotCollectionIds(props, headers)).body.slot.collections; }
        public async Task<List<ExpressionType>> GetExpressionTypes(Dictionary<string, string> headers = null) {
            return (await this.Raw.GetExpressionTypes(headers)).body.expressionTypes; }
        public async Task<List<Expression>> GetSlotExpressions(GetSlotExpressionsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetSlotExpressions(props, headers)).body.expressions; }
        public async Task<string> CreateExpression(CreateExpressionProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.CreateExpression(props, headers)).body.expressionId; }
        public async Task<bool> UpdateExpression(UpdateExpressionProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.UpdateExpression(props, headers)).success; }


        public SlotsRawHandlers Raw = new SlotsRawHandlers {
            GetSlot = async (props, headers) => await _this.Request<GetSlotResponse>("/slot/info" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            Collections = async (props, headers) => {
                if (props.idOnly == true) return (null, await _this.Request<GetSlotCollectionsIdsResponse>("/slot/collections" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else return (await _this.Request<GetSlotCollectionsResponse>("/slot/collections" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
            },
            GetSlotCollections = async (props, headers) => await _this.Request<GetSlotCollectionsResponse>("/slot/collections" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetSlotCollectionIds = async (props, headers) => await _this.Request<GetSlotCollectionsIdsResponse>("/slot/collections" + AssetLayerUtils.PropsToQueryString(props, new SlotCollectionsProps { idOnly = true }), "GET", null, headers),
            GetExpressionTypes = async (headers) => await _this.Request<GetExpressionTypesResponse>("/slot/expressions/types", "GET", null, headers),
            GetSlotExpressions = async (props, headers) => await _this.Request<GetSlotExpressionsResponse>("/slot/expressions" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            CreateExpression = async (props, headers) => await _this.Request<CreateExpressionResponse>("/slot/expressions/new", "POST", props, headers),
            UpdateExpression = async (props, headers) => await _this.Request<BasicSuccessResponse>("/slot/expressions/update", "PUT", props, headers)
        };

        public SlotsSafeHandlers Safe = new SlotsSafeHandlers {
            GetSlot = async (props, headers) => {
                try { return new BasicResult<Slot> { Result = await _this.GetSlot(props, headers) }; }
                catch (BasicError e) { return new BasicResult<Slot> { Error = e }; }},
            Collections = async (props, headers) => {
                try { return new BasicResult<(List<Collection>, List<string>)> { Result = await _this.Collections(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(List<Collection>, List<string>)> { Error = e }; }},
            GetSlotCollections = async (props, headers) => {
                try { return new BasicResult<List<Collection>> { Result = await _this.GetSlotCollections(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<Collection>> { Error = e }; }},
            GetSlotCollectionIds = async (props, headers) => {
                try { return new BasicResult<List<string>> { Result = await _this.GetSlotCollectionIds(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<string>> { Error = e }; }},
            GetExpressionTypes = async (headers) => {
                try { return new BasicResult<List<ExpressionType>> { Result = await _this.GetExpressionTypes(headers) }; }
                catch (BasicError e) { return new BasicResult<List<ExpressionType>> { Error = e }; }},
            GetSlotExpressions = async (props, headers) => {
                try { return new BasicResult<List<Expression>> { Result = await _this.GetSlotExpressions(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<Expression>> { Error = e }; }},
            CreateExpression = async (props, headers) => {
                try { return new BasicResult<string> { Result = await _this.CreateExpression(props, headers) }; }
                catch (BasicError e) { return new BasicResult<string> { Error = e }; }},
            UpdateExpression = async (props, headers) => {
                try { return new BasicResult<bool> { Result = await _this.UpdateExpression(props, headers) }; }
                catch (BasicError e) { return new BasicResult<bool> { Error = e }; }}
        };
    }
}
