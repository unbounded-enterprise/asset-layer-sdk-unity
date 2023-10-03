using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using AssetLayer.SDK;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Utils;
using UnityEngine;

#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
    using UnityEngine.Networking;
#else
    using System.Net.Http;
#endif


namespace AssetLayer.SDK.Core.Networking
{
    public static class NetworkingUtils {
        public static T GetContentAsObject<T>(string jsonContent) {
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonContent))) {
                var serializer = new DataContractJsonSerializer(typeof(T), new DataContractJsonSerializerSettings() { UseSimpleDictionaryFormat = true });
                var obj = (T)serializer.ReadObject(memoryStream);
                return obj;
            }
        }
        public static string GetObjectAsJSON(object obj) {
            using (MemoryStream memoryStream = new MemoryStream()) {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                serializer.WriteObject(memoryStream, obj);
                byte[] jsonBytes = memoryStream.ToArray();
                return Encoding.UTF8.GetString(jsonBytes, 0, jsonBytes.Length);
            }
        }
    }
    #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
        public static class UnityNetworking {
            public static async Task<T> Request<T>(string url, string method = "GET", object body = null, Dictionary<string, string> headers = null) {
                UnityWebRequest www = new UnityWebRequest(url, method);

                if (headers != null) foreach (var header in headers) www.SetRequestHeader(header.Key, header.Value);
                if (body != null) {
                    www.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(NetworkingUtils.GetObjectAsJSON(body)));
                    www.SetRequestHeader("Content-Type", "application/json");
                }
                
                www.downloadHandler = new DownloadHandlerBuffer();
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                UnityWebRequestAsyncOperation op = www.SendWebRequest();

                op.completed += (o) => tcs.SetResult(true);

                await tcs.Task;

                if (www.result == UnityWebRequest.Result.Success) {
                    Debug.Log("GetResponseUnity: " + www.downloadHandler.text);
                    return NetworkingUtils.GetContentAsObject<T>(www.downloadHandler.text);
                } else {
                    Debug.Log("GetResponseUnity Error: " + www.error + " " + www.downloadHandler.text);
                    BasicErrorResponse err = NetworkingUtils.GetContentAsObject<BasicErrorResponse>(www.downloadHandler.text); 
                    BasicError error = AssetLayerUtils.ParseBasicError(err);
                    throw error;
                }
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

            public static async Task<T> Request<T>(string url, string method = "GET", object body = null, Dictionary<string, string> headers = null) {
                using (HttpClient client = new HttpClient()) {
                    if (headers != null) foreach (var header in headers) client.DefaultRequestHeaders.Add(header.Key, header.Value);

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                    if (method != "GET" && BasicNetworkingUtils.HttpMethodMap.TryGetValue(method, out HttpMethod httpMethod)) { request.Method = httpMethod; }
                    if (body != null) {
                        request.Content = new StringContent(NetworkingUtils.GetObjectAsJSON(body), Encoding.UTF8, "application/json");
                        if (!client.DefaultRequestHeaders.Contains("Content-Type")) 
                            client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                    }

                    HttpResponseMessage response = await client.SendAsync(request);
                    var str = await response.Content.ReadAsStringAsync();
                    Debug.Log("GetResponse: " + str);

                    if (response.IsSuccessStatusCode) {
                        T data = await GetContentAsObjectAsync<T>(response);
                        return data;
                    } else {
                        BasicErrorResponse err = await GetContentAsObjectAsync<BasicErrorResponse>(response); 
                        BasicError error = AssetLayerUtils.ParseBasicError(err);
                        // Console.WriteLine($"[AssetLayer@{endpoint.Split('?')[0]}]: {response.ReasonPhrase} ({response.StatusCode}) // {error.message}");
                        // throw new BasicError((error.message), response.StatusCode);
                        throw error;
                    }
                }
            }
        }
    #endif
}
