using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web;
using UnityEngine;

namespace AssetLayer.SDK.Utils
{
    public static class AssetLayerUtils
    {
        public static string PropsToQueryString(object props)
        {
            if (props == null) return "";
            var parameters = new List<string>();
            var properties = props.GetType().GetProperties();
            foreach (PropertyInfo info in properties)
            {
                var key = info.Name;
                var value = info.GetValue(props, null);
                if (value == null) continue;
                else if (value is string[]) {
                    foreach (var v in (string[])value) {
                        if (!string.IsNullOrEmpty(v)) parameters.Add($"{key}[]={HttpUtility.UrlEncode(v)}");
                    }
                }
                else parameters.Add($"{key}={HttpUtility.UrlEncode(value.ToString())}");
            }
            return "?" + string.Join("&", parameters);
        }

        public static string PropsToQueryStringDict(Dictionary<string, object> props)
        {
            return "";
            /*
            if (props == null) return "";
            var parameters = new List<string>();
            foreach (var key in props.Keys)
            {
                if (props[key] == null) continue;
                else if (props[key] is string[])
                {
                    foreach (var value in (string[])props[key])
                    {
                        if (!string.IsNullOrEmpty(value))
                        {
                            parameters.Add($"{key}[]={HttpUtility.UrlEncode(value)}");
                        }
                    }
                }
                else
                {
                    parameters.Add($"{key}={HttpUtility.UrlEncode(props[key].ToString())}");
                }
            }
            Console.WriteLine("qs: " + string.Join("&", parameters));
            return "?" + string.Join("&", parameters);
            */
        }
    }
}
