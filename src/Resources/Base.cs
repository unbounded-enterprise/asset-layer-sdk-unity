using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using AssetLayerSDK;
using UnityEngine;


namespace AssetLayerSDK.Core.Base
{
    public static class BaseUtils {
        public static readonly Dictionary<string, HttpMethod> HttpMethodMap = new Dictionary<string, HttpMethod>
        {
            { "GET", HttpMethod.Get },
            { "POST", HttpMethod.Post },
            { "PUT", HttpMethod.Put },
            { "DELETE", HttpMethod.Delete },
        };
    }

    public abstract class BaseHandler
    {
        // private AssetLayer parent;
        private string baseUrl;
        private string appSecret;
        private string didToken;

        public BaseHandler(AssetLayerConfig config)
        {
            // this.parent = parent;
            if (config.baseUrl != null) this.baseUrl = config.baseUrl;
            if (config.appSecret != null) this.appSecret = config.appSecret;
            if (config.didToken != null) this.appSecret = config.didToken;
            Debug.Log("Based!");
        }

        public void setDidToken(string didToken) { this.didToken = didToken; }
        
        public async Task<T> GetContentAsObjectAsync<T>(HttpResponseMessage response)
        {
            var contentString = await response.Content.ReadAsStringAsync();
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(contentString)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                var obj = (T)serializer.ReadObject(memoryStream);
                return obj;
            }
        }

        protected async Task<T> Request<T>(string endpoint, string method = null, Dictionary<string, string> headers = null)
        {
            string url = $"{this.baseUrl}{endpoint}";
            Debug.Log("GetRequest: " + url);
            
            using (HttpClient client = new HttpClient())
            {
                if (headers != null) foreach (var header in headers) client.DefaultRequestHeaders.Add(header.Key, header.Value);
                // if (!client.DefaultRequestHeaders.Contains("Content-Type")) 
                //     client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                if (this.appSecret != null && !client.DefaultRequestHeaders.Contains("appsecret")) 
                    client.DefaultRequestHeaders.Add("appsecret", this.appSecret);
                if (this.didToken != null && !client.DefaultRequestHeaders.Contains("didtoken")) 
                    client.DefaultRequestHeaders.Add("didtoken", this.didToken);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                if (method != null && BaseUtils.HttpMethodMap.TryGetValue(method, out HttpMethod httpMethod)) request.Method = httpMethod;

                HttpResponseMessage response = await client.SendAsync(request);
                var str = await response.Content.ReadAsStringAsync();
                Debug.Log("GetResponse: " + str);
                T data = await GetContentAsObjectAsync<T>(response);
                if (response.IsSuccessStatusCode) return data;
                // var error = parseBasicError(body);
                // Console.WriteLine($"[AssetLayer@{endpoint.Split('?')[0]}]: {response.ReasonPhrase} ({response.StatusCode}) // {error.message}");
                // throw new BasicError((error.message), response.StatusCode);
                throw new Exception("A general exception has occurred.");
            }
        }
    }
}
