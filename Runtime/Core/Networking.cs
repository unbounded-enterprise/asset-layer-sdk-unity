using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using AssetLayer.SDK;
using UnityEngine;

#if UNITY_WEBGL
    using UnityEngine.Networking;
#else
    using System.Net.Http;
#endif


namespace AssetLayer.SDK.Core.Networking
{
    public static class NetworkingUtils {
        public static T GetContentAsObject<T>(string jsonContent) {
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonContent))) {
                var serializer = new DataContractJsonSerializer(typeof(T));
                var obj = (T)serializer.ReadObject(memoryStream);
                return obj;
            }
        }
    }
    #if UNITY_WEBGL
        public static class UnityNetworking {
            public static async Task<T> Request<T>(string url, string method = "GET", Dictionary<string, string> headers = null) {
                UnityWebRequest www = new UnityWebRequest(url, method);

                if (headers != null) foreach (var header in headers) www.SetRequestHeader(header.Key, header.Value);
                
                www.downloadHandler = new DownloadHandlerBuffer();
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                UnityWebRequestAsyncOperation op = www.SendWebRequest();

                op.completed += (o) => tcs.SetResult(true);

                await tcs.Task;

                if (www.result == UnityWebRequest.Result.Success) {
                    Debug.Log("GetResponseUnity: " + www.downloadHandler.text);
                    return NetworkingUtils.GetContentAsObject<T>(www.downloadHandler.text);
                } else {
                    Debug.Log("GetResponse Error: " + www.error);
                    // Handle error
                }

                throw new Exception("A general exception has occurred.");
            }
        }
    #else
        public static class BasicNetworkingUtils {
            public static readonly Dictionary<string, HttpMethod> HttpMethodMap = new Dictionary<string, HttpMethod> {
                { "GET", HttpMethod.Get },
                { "POST", HttpMethod.Post },
                { "PUT", HttpMethod.Put },
                { "DELETE", HttpMethod.Delete },
            };
        }
        public static class BasicNetworking {
            public static async Task<T> GetContentAsObjectAsync<T>(HttpResponseMessage response) {
                var contentString = await response.Content.ReadAsStringAsync();
                return NetworkingUtils.GetContentAsObject<T>(contentString);
            }

            public static async Task<T> Request<T>(string url, string method = "GET", Dictionary<string, string> headers = null) {
                using (HttpClient client = new HttpClient()) {
                    if (headers != null) foreach (var header in headers) client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    // if (!client.DefaultRequestHeaders.Contains("Content-Type")) 
                    //     client.DefaultRequestHeaders.Add("Content-Type", "application/json");

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                    if (method != "GET" && BasicNetworkingUtils.HttpMethodMap.TryGetValue(method, out HttpMethod httpMethod)) request.Method = httpMethod;

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
    #endif
}
