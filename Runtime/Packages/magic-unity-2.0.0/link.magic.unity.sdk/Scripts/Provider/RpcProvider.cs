using System;
using System.IO;
using System.Threading.Tasks;
using link.magic.unity.sdk.Relayer;
using Newtonsoft.Json;
using UnityEngine;

namespace link.magic.unity.sdk.Provider

{
    public class RpcProvider
    {

        private readonly WebviewController _relayer = new();

        protected internal RpcProvider(UrlBuilder urlBuilder)
        {
            var url = _generateBoxUrl(urlBuilder);

            // init relayer
            _relayer.Load(url);
        }

        private string _generateBoxUrl(UrlBuilder urlBuilder)
        {
            // encode options params to base 64
            var optionsJsonString = JsonUtility.ToJson(urlBuilder);
            Debug.Log(optionsJsonString);

            var url = $"{UrlBuilder.Host}/send/?params={urlBuilder.EncodedParams}";

            return url;
        }



        protected internal async Task<TResult> MagicSendAsync<TParams, TResult>(MagicRpcRequest<TParams> magicRequest)
        {
            // Wrap with Relayer params and send to relayer
            var msgType = $"{nameof(OutboundMessageType.MAGIC_HANDLE_REQUEST)}-{UrlBuilder.Instance.EncodedParams}";
            var relayerRequest = new RelayerRequest<TParams>(msgType, magicRequest);
            var msgStr = JsonUtility.ToJson(relayerRequest);

            var promise = new TaskCompletionSource<TResult>();

            // handle Response in the callback, so that webview is type free
            _relayer.Enqueue(msgStr, magicRequest.id, msg =>
            {
                var relayerResponse = JsonUtility.FromJson<RelayerResponse<TResult>>(msg);

                var error = relayerResponse.response.error;
                if ((error != null) & (error?.message != null))
                    return promise.TrySetException(new Exception(error.message));

                var result = relayerResponse.response.result;

                return promise.TrySetResult(result);
            });

            return await promise.Task;
        }
    }
}