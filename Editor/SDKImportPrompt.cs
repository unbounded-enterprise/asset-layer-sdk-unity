using UnityEditor;
using System.IO;
namespace AssetLayer.Unity
{
    public class SDKImportPrompt
    {
        /* static SDKImportPrompt()
        {
            string packageCheckPath = "Packages/com.assetlayer.sdk.unity/Runtime";
            // Path to a marker file to prevent repeated prompts
            string markerFilePath = "Assets/AssetLayerUnitySDK/com.assetlayer.sdk.unity_imported";
            if (Directory.Exists(packageCheckPath) && !File.Exists(markerFilePath))
            {
                if (EditorUtility.DisplayDialog("Import SDK",
                    "Do you want to import AssetLayer Essentials to your /Assets folder?",
                    "Yes", "No"))
                {
                    ImportSDK();
                }
                // Ensure the directory for the marker file exists
                UtilityFunctions.EnsureDirectoryExists(Path.GetDirectoryName(markerFilePath));

                // Create a marker file to indicate the prompt has been shown
                File.Create(markerFilePath).Dispose();
            }
        } */ 


        [MenuItem("Assets/AssetLayer/Import Essentials")]
        private static void ImportSDKMenu()
        {
            string packageCheckPath = "Packages/com.assetlayer.sdk.unity/Runtime";
            string markerFilePath = "Assets/AssetLayerUnitySDK/com.assetlayer.sdk.unity_imported";

            if (Directory.Exists(packageCheckPath) && !File.Exists(markerFilePath))
            {
                if (EditorUtility.DisplayDialog("Import SDK",
                    "Do you want to import Asset Layer Essentials to your /Assets/AssetLayerUnitySDK/ folder?",
                    "Yes", "No"))
                {
                    ImportSDK();
                }
                // UtilityFunctions.EnsureDirectoryExists(Path.GetDirectoryName(markerFilePath));
                // File.Create(markerFilePath).Dispose();
            }
        }

        private static void ImportSDK()
        {
            string sourcePath = "Packages/com.assetlayer.sdk.unity/Runtime/Assets/AssetLayerUnitySDK";
            string targetPath = "Assets/AssetLayerUnitySDK";

            if (!Directory.Exists(sourcePath))
            {
                EditorUtility.DisplayDialog("Import Failed", "The source path does not exist.", "OK");
                return;
            }

            if (Directory.Exists(targetPath))
            {
                if (!EditorUtility.DisplayDialog("Warning", "AssetLayerUnitySDK already exists in Assets. Overwrite?", "Yes", "No"))
                    return;
                FileUtil.DeleteFileOrDirectory(targetPath);
            }

            FileUtil.MoveFileOrDirectory(sourcePath, targetPath);
            AssetDatabase.Refresh();
        }

    }
}