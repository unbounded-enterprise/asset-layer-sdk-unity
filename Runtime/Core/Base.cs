using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using AssetLayer.SDK;
using AssetLayer.SDK.Core.Networking;

#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX
    using UnityEngine;
#endif


namespace AssetLayer.SDK.Core.Base
{
    public abstract class BaseHandler
    {
        private string appSecret;
        private string baseUrl { get; set; }
        private string didToken { get; set; }
        private bool logs { get; set; } = true;

        public BaseHandler(AssetLayerConfig config)
        {
            if (config.baseUrl != null) this.baseUrl = config.baseUrl;
            if (config.appSecret != null) this.appSecret = config.appSecret;
            if (config.didToken != null) this.didToken = config.didToken;
            if (config.logs != null) this.logs = config.logs;
        }

        public void SetDidToken(string didToken) { this.didToken = didToken; }

        protected async Task<T> Request<T>(string endpoint, string method = "GET", object body = null, Dictionary<string, string> headers = null)
        {
            string url = $"{this.baseUrl}{endpoint}";
            #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX
                if (this.logs == true) Debug.Log("GetRequest: " + url);
            #endif
            Dictionary<string, string> head = new Dictionary<string, string>();
            if (headers != null) foreach (var header in headers) head.Add(header.Key, header.Value);
            if (this.appSecret != null && !head.ContainsKey("appsecret")) head.Add("appsecret", this.appSecret);
            if (this.didToken != null && !head.ContainsKey("didtoken")) head.Add("didtoken", this.didToken);
            
            #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
                return await UnityNetworking.Request<T>(url, method, body, head, this.logs);
            #else
                return await BasicNetworking.Request<T>(url, method, body, head, this.logs);
            #endif
        }
    }
}
