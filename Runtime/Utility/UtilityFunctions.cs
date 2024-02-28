using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.Collections;
using System.Threading.Tasks;
using AssetLayer.SDK.Expressions;
using System.Reflection;
using System.Text;
using UnityEditor;
using System.IO;

namespace AssetLayer.Unity
{


    public static class UtilityFunctions
    {
        public static Transform FindDeepChild(Transform parent, string name)
        {
            foreach (Transform child in parent)
            {
                if (child.name == name)
                    return child;

                Transform result = FindDeepChild(child, name);

                if (result != null)
                    return result;
            }

            return null;
        }

        public static string GetCurrentPlatformExpressionAttribute()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                    return "AssetBundleStandaloneWindows";
                case RuntimePlatform.WindowsPlayer:
                    return "AssetBundleStandaloneWindows";
                case RuntimePlatform.OSXEditor:
                    return "AssetBundleStandaloneOSX";
                case RuntimePlatform.OSXPlayer:
                    return "AssetBundleStandaloneOSX";
                case RuntimePlatform.IPhonePlayer:
                    return "AssetBundleiOS";
                case RuntimePlatform.Android:
                    return "AssetBundleAndroid";
                case RuntimePlatform.WebGLPlayer:
                    return "AssetBundleWebGL";
                default:
                    return "AssetBundleStandaloneWindows";
            }
        }
        public static string GetExpressionValue(List<ExpressionValue> expressionValues, string expressionName)
        {
            var expressionValue = expressionValues
                                 .FirstOrDefault(ev => ev.expression.expressionName == expressionName);
            return expressionValue?.value;
        }


        public static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Note: This is a simple regex for validation. You might find various regex patterns online 
                // with varying levels of complexity based on what you consider a 'valid' email address.
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static void CopyProperties(object source, object destination)
        {
            if (source == null || destination == null)
                throw new ArgumentNullException("Source or/and Destination Objects are null");

            Type typeSource = source.GetType();
            Type typeDestination = destination.GetType();

            PropertyInfo[] sourceProperties = typeSource.GetProperties();
            PropertyInfo[] destinationProperties = typeDestination.GetProperties();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                foreach (PropertyInfo destinationProperty in destinationProperties)
                {
                    if (sourceProperty.Name == destinationProperty.Name &&
                        destinationProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    {
                        destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
                        break;
                    }
                }
            }
        }

        public static IEnumerator WaitForTask(Task task)
        {
            while (!task.IsCompleted)
            {
                yield return null;
            }

            if (task.IsFaulted)
            {
                Debug.LogError(task.Exception);
                // Handle the exception
            }
        }

        public static string Generate24CharHexID()
        {
            var random = new System.Random();
            var bytes = new byte[12];
            random.NextBytes(bytes);
            StringBuilder sb = new StringBuilder(24);
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static string GetExpressionValueAssetBundle(List<ExpressionValue> expressionValues, string expressionName = null)
        {
            string currentPlatformAttributeName = GetCurrentPlatformExpressionAttribute();
            // Attempt to find an expression that matches the specified expressionName (if provided)
            // and whose attribute name matches the current platform.
            var expressionValue = expressionValues
                .FirstOrDefault(ev => (string.IsNullOrEmpty(expressionName) || ev.expression.expressionName == expressionName) &&
                                      ev.expressionAttribute.expressionAttributeName == currentPlatformAttributeName);

            // If the first attempt fails, it is no asset bundle, search for the 3d Model type id 
            if (expressionValue == null)
            {
                expressionValue = expressionValues
                    .FirstOrDefault(ev => ev.expressionType.expressionTypeId == "65d6ade9b04907f41c26a002");
            }
            return expressionValue?.value;
        }

        public static string GetExpressionValueByAttributeId(List<ExpressionValue> expressionValues, string attributeId)
        {
            var expressionValue = expressionValues
                                 .FirstOrDefault(ev => ev.expressionAttribute.expressionAttributeId == attributeId);
            return expressionValue?.value;
        }
        public static string GetExpressionValueByExpressionId(List<ExpressionValue> expressionValues, string expressionId, string expressionTypeId = null)
        {
            var expressionValue = expressionValues
                                 .FirstOrDefault(ev => ev.expression.expressionId == expressionId && (string.IsNullOrEmpty(expressionTypeId) || ev.expressionType.expressionTypeId == expressionTypeId));
            return expressionValue?.value;
        }

        public static string GetExpressionValueByExpressionIdAssetBundle(List<ExpressionValue> expressionValues, string expressionId)
        {
            string currentPlatformAttributeName = GetCurrentPlatformExpressionAttribute();

            // First, find the expression by expressionId.
            var expressionValue = expressionValues.FirstOrDefault(ev => ev.expression.expressionId == expressionId);

            // Check if the expressionTypeId matches "64b1ce76716b83c3de7df84e". (It is an asset bundle expression
            if (expressionValue != null && expressionValue.expressionType.expressionTypeId == "64b1ce76716b83c3de7df84e")
            {
                // If it matches, further refine the search to match the current platform's attribute name.
                var refinedExpressionValue = expressionValues.FirstOrDefault(ev =>
                    ev.expression.expressionId == expressionId && ev.expressionAttribute.expressionAttributeName == currentPlatformAttributeName);

                // If a more specific match is found based on attribute name, use it. Otherwise, use the initially found expressionValue.
                return refinedExpressionValue?.value ?? expressionValue?.value;
            }
            else
            {
                // If the expressionTypeId does not match or no expression is found, return the value of the initially found expression.
                return expressionValue?.value;
            }
        }


        public static bool IsSceneBundle(AssetBundle bundle)
        {
            if (bundle == null) return false;

            string[] allAssetNames = bundle.GetAllAssetNames();

            foreach (string assetName in allAssetNames)
            {
                if (assetName.EndsWith(".unity"))
                {
                    return true;
                }
            }

            return false;
        }

#if UNITY_EDITOR
        public static string CalculatePrefabHash(GameObject prefab)
        {
            string path = AssetDatabase.GetAssetPath(prefab);
            if (File.Exists(path))
            {
                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    using (var stream = File.OpenRead(path))
                    {
                        byte[] hash = md5.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                }
            }
            return null;
        }

#endif

        private static string CalculateMD5Hash(string input)
        {
            // Use MD5 to calculate a hash from the input string
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}


