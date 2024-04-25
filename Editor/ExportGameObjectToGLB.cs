using UnityEngine;
using UnityEditor;
using UnityGLTF;
using System;
using System.IO;

namespace AssetLayer.Unity { 
public class ExportGameObjectToGLB : MonoBehaviour
{
    public static void ExportToGLB(GameObject objectToExport, string outputPath)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create an ExportContext
        ExportContext exportContext = new ExportContext();

        // Pass the ExportContext to the GLTFSceneExporter constructor
        var exporter = new GLTFSceneExporter(new[] { objectToExport.transform }, exportContext);
        exporter.SaveGLB(outputPath, objectToExport.name);
        Debug.Log("Exported GLB to " + outputPath);
    }

    [MenuItem("Assets/Asset Layer/Utilities/Export Selected GameObject to GLB")]
    private static void ExportSelectedToGLB()
    {
        if (Selection.activeGameObject == null)
        {
            Debug.LogError("No GameObject selected for export.");
            return;
        }

        string path = EditorUtility.SaveFilePanel("Save exported GameObject as GLB", "", Selection.activeGameObject.name + ".glb", "glb");
        if (string.IsNullOrEmpty(path)) return;

        ExportToGLB(Selection.activeGameObject, path);
    }

    public static string ExportToGLBDataURL(GameObject objectToExport)
    {
            string projectFolderPath = Path.Combine(Application.dataPath, "AssetLayerUnitySDK/GLBs");
            Directory.CreateDirectory(projectFolderPath); // Ensure the directory exists

            string fileName = objectToExport.name + ".glb";
            string fullOutputPath = Path.Combine(projectFolderPath, fileName);
            ExportToGLB(objectToExport, fullOutputPath);
            // Adjusting the path to match the expected directory structure
            string nestedFolderPath = Path.Combine(projectFolderPath, fileName); // Folder named after the GameObject
            string finalGLBPath = Path.Combine(nestedFolderPath, fileName); // The actual GLB file inside the nested folder


            try
            {
            byte[] bytes = File.ReadAllBytes(finalGLBPath); // this here should be a changed fullOutputPath that now 
            string base64 = Convert.ToBase64String(bytes);
                byte[] glbBytes = Convert.FromBase64String(base64);
                // Define a new path to save the GLB file for verification
                string verificationGLBPath = Path.Combine(nestedFolderPath, "verification_" + fileName);
                // Save the GLB file back to disk for verification
                File.WriteAllBytes(verificationGLBPath, glbBytes);
                return $"data:application/octet-stream;base64,{base64}";
        }
        catch (Exception ex)
        {
            Debug.Log($"glb could not be created: {ex.Message}");
            return "";
        }
        }

}
}
