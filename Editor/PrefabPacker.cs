using System.IO;
using UnityEditor;
using UnityEngine;

namespace AssetLayer.Unity
{
    public class PrefabPacker
    {
        public static string PackagePrefab(GameObject prefab, string slotId)
        {
            // Get the name of the selected prefab
            string prefabName = prefab.name;

            // Set the predefined package path with dynamic prefab name
            string packagePath = "Assets/AssetLayerUnitySDK/UnityPackages/" + slotId + "/" + prefabName + ".unitypackage";

            string assetPath = AssetDatabase.GetAssetPath(prefab);
            UtilityFunctions.EnsureDirectoryExists(Path.GetDirectoryName(packagePath));
            // Export the prefab with dependencies
            AssetDatabase.ExportPackage(assetPath, packagePath, ExportPackageOptions.IncludeDependencies);
            AssetDatabase.Refresh();  // Refresh the Asset Database
            Debug.Log("Prefab package created at: " + packagePath);
            return packagePath;
        }
    }
}
