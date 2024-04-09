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

    [MenuItem("Asset Layer/Utilities/Export Selected GameObject to GLB")]
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
        string tempPath = Path.GetTempPath() + objectToExport.name + ".glb";
        ExportToGLB(objectToExport, tempPath);

        try
        {
            byte[] bytes = File.ReadAllBytes(tempPath);
            string base64 = Convert.ToBase64String(bytes);
            return $"data:model/gltf-binary;base64,{base64}";
        }
        finally
        {
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
        }
    }

}
}
