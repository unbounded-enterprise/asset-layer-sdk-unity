#if UNITY_WEBGL
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading.Tasks;
    using AssetLayer.SDK;
    using UnityEngine;
    using UnityEngine.Networking;
#else
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading.Tasks;
    using AssetLayer.SDK;
    using UnityEngine;
#endif


namespace AssetLayer.SDK.Core.Networking
{
    #if UNITY_WEBGL
        public class UnityNetworking {
            public async Task<T> Request<T>(string url, string method = null, Dictionary<string, string> headers = null) {
                UnityWebRequest www = new UnityWebRequest(url, method);
        
                if (headers != null) {
                    foreach (var header in headers) {
                        www.SetRequestHeader(header.Key, header.Value);
                    }
                }
                
                www.downloadHandler = new DownloadHandlerBuffer();

                // Create a TaskCompletionSource
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

                // Start the request
                UnityWebRequestAsyncOperation op = www.SendWebRequest();

                // Set the task to complete when the operation completes
                op.completed += (o) => tcs.SetResult(true);

                // Wait for the task to complete
                await tcs.Task;

                if (www.result == UnityWebRequest.Result.Success) {
                    Debug.Log("GetResponseUnity: " + www.downloadHandler.text);
                    // Parse www.downloadHandler.text as T and return
                } else {
                    Debug.Log("GetResponse Error: " + www.error);
                    // Handle error
                }

                throw new Exception("A general exception has occurred.");
            }
        }
    #else
        public static class NetworkingUtils {
            public static readonly Dictionary<string, HttpMethod> HttpMethodMap = new Dictionary<string, HttpMethod>
            {
                { "GET", HttpMethod.Get },
                { "POST", HttpMethod.Post },
                { "PUT", HttpMethod.Put },
                { "DELETE", HttpMethod.Delete },
            };
        }
        public class BasicNetworking {
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

            public async Task<T> Request<T>(string url, string method = null, Dictionary<string, string> headers = null)
            {
                using (HttpClient client = new HttpClient())
                {
                    if (headers != null) foreach (var header in headers) client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    // if (!client.DefaultRequestHeaders.Contains("Content-Type")) 
                    //     client.DefaultRequestHeaders.Add("Content-Type", "application/json");

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                    if (method != null && NetworkingUtils.HttpMethodMap.TryGetValue(method, out HttpMethod httpMethod)) request.Method = httpMethod;

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
