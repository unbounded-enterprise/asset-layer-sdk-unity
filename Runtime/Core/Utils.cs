using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Core.Networking;

#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
    using UnityEngine;
#endif

namespace AssetLayer.SDK.Utils
{
    public static class AssetLayerUtils
    {
        public static BasicError ParseBasicError(BasicErrorResponse response, int fallbackCode = 500) {
            if (response == null) { return new BasicError("Unknown Error", fallbackCode); }

            string message = response.error ?? response.message ?? response.Error ?? response.Message ?? response.ErrorMessage ?? response.errorMessage ?? response.ReasonPhrase ?? "Unknown Error Message";
            int status = response.statusCode ?? response.status ?? response.StatusCode ?? response.Status ?? (response.StatusCode != null ? (int)response.StatusCode : fallbackCode);

            #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
                Debug.Log("Error: " + message + " (" + status + ")");
            #endif

            return new BasicError(message, status);
        }

        public static T MergeIntoClass<T>(object props, T target) where T : class
        {
            foreach (PropertyInfo prop in props.GetType().GetProperties())
            {
                if (prop.CanRead && target.GetType().GetProperty(prop.Name)?.CanWrite == true)
                {
                    var value = prop.GetValue(props);
                    target.GetType().GetProperty(prop.Name).SetValue(target, value);
                }
            }

            return target;
        }

        public static string PropsToQueryString(object props, object forced = null, object defaults = null) {
            var parameters = new Dictionary<string, string>();

            if (defaults != null) {
                foreach (PropertyInfo info in defaults.GetType().GetProperties()) {
                    AddPropertyToParameters(parameters, info, defaults); } }
            if (props != null) {
                foreach (PropertyInfo info in props.GetType().GetProperties()) {
                    AddPropertyToParameters(parameters, info, props); } }
            if (forced != null) {
                foreach (PropertyInfo info in forced.GetType().GetProperties()) {
                    AddPropertyToParameters(parameters, info, forced); } }

            return "?" + string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        }

        public static void AddPropertyToParameters(Dictionary<string, string> parameters, PropertyInfo info, object sourceObject) {
            var key = info.Name;
            var value = info.GetValue(sourceObject, null);

            if (value == null) return;
            else if (value is bool) {
                parameters[key] = value.ToString().ToLowerInvariant();
            } else if (value is List<string>) {
                foreach (var v in (List<string>)value) {
                    if (!string.IsNullOrEmpty(v))  {
                        if(parameters.ContainsKey($"{key}[]")) {
                            parameters[$"{key}[]"] += $"&{key}[]={Uri.EscapeDataString(v)}";
                        } else {
                            parameters.Add($"{key}[]", Uri.EscapeDataString(v));
                        }
                    }
                }
            } else if (value is string[]) {
                foreach (var v in (string[])value) {
                    if (!string.IsNullOrEmpty(v))  {
                        if(parameters.ContainsKey($"{key}[]")) {
                            parameters[$"{key}[]"] += $"&{key}[]={Uri.EscapeDataString(v)}";
                        } else {
                            parameters.Add($"{key}[]", Uri.EscapeDataString(v));
                        }
                    }
                }
            } else {
                parameters[key] = Uri.EscapeDataString(value.ToString());
            }
        }
    }
}
