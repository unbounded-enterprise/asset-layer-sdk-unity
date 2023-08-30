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
using UnityEngine;


namespace AssetLayer.SDK.Core.Base
{
    public abstract class BaseHandler
    {
        private string appSecret;
        private string baseUrl { get; set; }
        private string didToken { get; set; }

        public BaseHandler(AssetLayerConfig config)
        {
            if (config.baseUrl != null) this.baseUrl = config.baseUrl;
            if (config.appSecret != null) this.appSecret = config.appSecret;
            if (config.didToken != null) this.didToken = config.didToken;
        }

        public void SetDidToken(string didToken) { this.didToken = didToken; }

        protected async Task<T> Request<T>(string endpoint, string method = null, Dictionary<string, string> headers = null)
        {
            string url = $"{this.baseUrl}{endpoint}";
            Debug.Log("GetRequest: " + url);
            Dictionary<string, string> head = new Dictionary<string, string>();
            if (headers != null) foreach (var header in headers) head.Add(header.Key, header.Value);
            if (this.appSecret && !head.ContainsKey("appsecret")) head.Add("appsecret", this.appSecret);
            if (this.didToken && !head.ContainsKey("didtoken")) head.Add("didtoken", this.didToken);
            
            #if UNITY_WEBGL
                return await UnityNetworking.Request<T>(url, method, head);
            #else
                return await BasicNetworking.Request<T>(url, method, head);
            #endif
        }
    }
}
