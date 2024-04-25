using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Windows;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AssetLayer.Unity
{
    [CreateAssetMenu(fileName = "AppSettings", menuName = "AssetLayer/AppSettings")]
    public class AppConfig : ScriptableObject
    {
        public string AssetLayerAppId;
        public string AssetLayerProxyServerUrl;
        public string AssetLayerLoginUrl;
#if UNITY_EDITOR
        public string encryptedAssetLayerDidToken;
        public string encryptedAssetLayerAppSecret;
#endif

        private static AppConfig settingsInstance;

        public static AppConfig Instance
        {
            get
            {
                if (settingsInstance == null)
                {
                    settingsInstance = Resources.Load<AppConfig>("Config/AssetLayerAppConfig");

#if UNITY_EDITOR
                    if (settingsInstance == null)
                    {
                        AppConfig newConfig = ScriptableObject.CreateInstance<AppConfig>();

                        // Ensure parent directory structure exists
                        string resourceDir = Path.Combine(Application.dataPath, "Resources");
                        string configDir = Path.Combine(resourceDir, "Config");
                        EnsureDirectoryExists(resourceDir);
                        EnsureDirectoryExists(configDir);

                        // Create config asset
                        string configAssetPath = "Assets/Resources/Config/AssetLayerAppConfig.asset";
                        AssetDatabase.CreateAsset(newConfig, configAssetPath);
                        EditorApplication.delayCall += AssetDatabase.SaveAssets;
                        AssetDatabase.Refresh();
                        settingsInstance = newConfig;
                    }
#endif
                }
                return settingsInstance;
            }
        }

#if UNITY_EDITOR
        private static void EnsureDirectoryExists(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }
#endif
    }



#if UNITY_EDITOR
    static class AppSettingsIMGUIRegister
    {
        [SettingsProvider]
        public static SettingsProvider CreateAppSettingsProvider()
        {
            var provider = new SettingsProvider("Project/AssetLayerAppSettings", SettingsScope.Project)
            {
                label = "Asset Layer App Settings",
                guiHandler = (searchContext) =>
                {
                    var settings = AppConfig.Instance;
                    if (settings == null)
                    {
                        EditorGUILayout.HelpBox("AppConfig asset not found at the specified path.", MessageType.Error);
                        return;
                    }

                    EditorGUI.BeginChangeCheck();
                    // Draw the settings UI here
                    settings.AssetLayerAppId = EditorGUILayout.TextField("App ID", settings.AssetLayerAppId);
                    settings.AssetLayerProxyServerUrl = EditorGUILayout.TextField("Proxy Server URL", settings.AssetLayerProxyServerUrl);
                    settings.AssetLayerLoginUrl = EditorGUILayout.TextField("Login URL", settings.AssetLayerLoginUrl);
#if UNITY_EDITOR
                    // Decrypt data for display
                    var decryptedDidToken = EncryptionUtils.Decrypt(settings.encryptedAssetLayerDidToken);
                    var decryptedAppSecret = EncryptionUtils.Decrypt(settings.encryptedAssetLayerAppSecret);

                    decryptedDidToken = EditorGUILayout.TextField("DID Token", decryptedDidToken);
                    decryptedAppSecret = EditorGUILayout.TextField("App Secret", decryptedAppSecret);

                    // Encrypt data again before saving
                    if (EditorGUI.EndChangeCheck())
                    {
                        settings.encryptedAssetLayerDidToken = EncryptionUtils.Encrypt(decryptedDidToken);
                        settings.encryptedAssetLayerAppSecret = EncryptionUtils.Encrypt(decryptedAppSecret);
                        EditorUtility.SetDirty(settings);
                    }
#endif
                    if (EditorGUI.EndChangeCheck())
                    {
                        EditorUtility.SetDirty(settings);
                    }
                },

                keywords = new HashSet<string>(new[] {
                    "AssetLayerAppId",
                    "AssetLayerProxyServerUrl",
                    "AssetLayerLoginUrl",
                    "AssetLayerDidToken",
                    "AssetLayerAppSecret"
                })
            };

            return provider;
        }
    }
    [CustomEditor(typeof(AppConfig))]
    public class AppConfigEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            AppConfig script = (AppConfig)target;

            // Disable GUI if the object is in the Resources folder
            if (AssetDatabase.GetAssetPath(script).Contains("/Resources/"))
            {
                EditorGUILayout.HelpBox("Editing this configuration in Resources is not allowed. Please modify it in Project Settings.", MessageType.Warning);
                GUI.enabled = false;
            }

            // Draw the default inspector
            DrawDefaultInspector();

            // Optionally add buttons or other functionality here

            GUI.enabled = true;
        }
    }
#endif
}