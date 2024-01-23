using UnityEditor;
using System.IO;
using UnityEngine;

public class PackageImporter : MonoBehaviour
{
    private static string packageDirectory = "Assets/AssetLayerUnitySDK/UnityPackages";

    [MenuItem("Assets/AssetLayer/Sync/Import All Synced Unity Packages")]
    public static void ImportAllUnityPackages()
    {
        var files = Directory.GetFiles(packageDirectory, "*.unitypackage", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            AssetDatabase.ImportPackage(file, false); // false means no interactive mode
        }
    }
}
