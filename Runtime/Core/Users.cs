using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AssetLayer.SDK;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Core.Base;
using AssetLayer.SDK.Collections;
using AssetLayer.SDK.Users;
using AssetLayer.SDK.Utils;
using UnityEngine;

namespace AssetLayer.SDK.Core.Users
{
    public class UsersHandler : BaseHandler
    {
        private static UsersHandler _this;
        public UsersHandler(AssetLayerConfig config = null) : base(config) { _this = this; }
        
        public async Task<User> GetUser(Dictionary<string, string> headers = null) {
            return (await this.Raw.GetUser(headers)).body.user; }
        public async Task<(List<Collection>, List<string>)> Collections(UserCollectionsProps props, Dictionary<string, string> headers = null) {
            if (props.idOnly == true) return (null, (await this.Raw.Collections(props, headers)).Item2.body.collections);
            else return ((await this.Raw.Collections(props, headers)).Item1.body.collections, null); }
        public async Task<List<Collection>> GetUserCollections(GetUserCollectionsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetUserCollections(props, headers)).body.collections; }
        public async Task<List<string>> GetUserCollectionIds(GetUserCollectionsProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.GetUserCollectionIds(props, headers)).body.collections; }
        public async Task<(string, RegisterUserResponseBody)> Register(RegisterUserProps props, Dictionary<string, string> headers = null) {
            if (props.otp != null) return (null, (await this.Raw.Register(props, headers)).Item2.body);
            else return ((await this.Raw.Register(props, headers)).Item1.body.otp, null); }
        public async Task<string> GetOTP(Dictionary<string, string> headers = null) {
            return (await this.Raw.GetOTP(headers)).body.otp; }
        public async Task<RegisterUserResponseBody> RegisterDid(RegisterDidProps props, Dictionary<string, string> headers = null) {
            return (await this.Raw.RegisterDid(props, headers)).body; }
            


        public UsersRawHandlers Raw = new UsersRawHandlers {
            GetUser = async (headers) => await _this.Request<GetUserResponse>("/user/info", "GET", null, headers),
            Collections = async (props, headers) => {
                if (props.idOnly == true) return (null, await _this.Request<GetUserCollectionIdsResponse>("/user/collections" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers));
                else return (await _this.Request<GetUserCollectionsResponse>("/user/collections" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers), null);
            },
            GetUserCollections = async (props, headers) => await _this.Request<GetUserCollectionsResponse>("/user/collections" + AssetLayerUtils.PropsToQueryString(props), "GET", null, headers),
            GetUserCollectionIds = async (props, headers) => await _this.Request<GetUserCollectionIdsResponse>("/user/collections" + AssetLayerUtils.PropsToQueryString(props, new UserCollectionsProps { idOnly = true }), "GET", null, headers),
            Register = async (props, headers) => {
                if (props.otp != null) return (null, await _this.Request<RegisterUserResponse>("/user/register", "POST", props, headers));
                else return (await _this.Request<GetOTPResponse>("/user/register", "POST", props, headers), null);
            },
            GetOTP = async (headers) => await _this.Request<GetOTPResponse>("/user/register", "POST", null, headers),
            RegisterDid = async (props, headers) => await _this.Request<RegisterUserResponse>("/user/register", "POST", props, headers)
        };

        public UsersSafeHandlers Safe = new UsersSafeHandlers {
            GetUser = async (headers) => {
                try { return new BasicResult<User> { Result = await _this.GetUser(headers) }; }
                catch (BasicError e) { return new BasicResult<User> { Error = e }; }},
            Collections = async (props, headers) => {
                try { return new BasicResult<(List<Collection>, List<string>)> { Result = await _this.Collections(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(List<Collection>, List<string>)> { Error = e }; }},
            GetUserCollections = async (props, headers) => {
                try { return new BasicResult<List<Collection>> { Result = await _this.GetUserCollections(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<Collection>> { Error = e }; }},
            GetUserCollectionIds = async (props, headers) => {
                try { return new BasicResult<List<string>> { Result = await _this.GetUserCollectionIds(props, headers) }; }
                catch (BasicError e) { return new BasicResult<List<string>> { Error = e }; }},
            Register = async (props, headers) => {
                try { return new BasicResult<(string, RegisterUserResponseBody)> { Result = await _this.Register(props, headers) }; }
                catch (BasicError e) { return new BasicResult<(string, RegisterUserResponseBody)> { Error = e }; }},
            GetOTP = async (headers) => {
                try { return new BasicResult<string> { Result = await _this.GetOTP(headers) }; }
                catch (BasicError e) { return new BasicResult<string> { Error = e }; }},
            RegisterDid = async (props, headers) => {
                try { return new BasicResult<RegisterUserResponseBody> { Result = await _this.RegisterDid(props, headers) }; }
                catch (BasicError e) { return new BasicResult<RegisterUserResponseBody> { Error = e }; }}
        };
    }
}
