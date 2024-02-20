using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AssetLayer.Unity
{

    public class ReferencedScriptsFinder : EditorWindow
    {
        public static void FindScripts()
        {
            UnityEngine.Object selectedObject = Selection.activeObject;

            if (selectedObject is GameObject)
            {
                FindScriptsInGameObject(selectedObject as GameObject);
            }
            else if (selectedObject is SceneAsset)
            {
                FindScriptsInScene(selectedObject as SceneAsset);
            }
            else if (selectedObject is GameObject && PrefabUtility.IsPartOfAnyPrefab(selectedObject))
            {
                FindScriptsInPrefab(selectedObject as GameObject);
            }
            else
            {
                Debug.LogWarning("Selected object is not recognized as a GameObject, Scene, or Prefab!");
            }
        }

        public static void FindScriptsInObject(UnityEngine.Object obj)
        {
            if (obj is GameObject)
            {
                FindScriptsInGameObject(obj as GameObject);
            }
            else if (obj is SceneAsset)
            {
                FindScriptsInScene(obj as SceneAsset);
            }
            else if (obj is GameObject && PrefabUtility.IsPartOfAnyPrefab(obj))
            {
                FindScriptsInPrefab(obj as GameObject);
            }
            else
            {
                Debug.LogWarning("Provided object is not recognized as a GameObject, Scene, or Prefab!");
            }
        }

        private static void FindScriptsInGameObject(GameObject gameObject)
        {
            List<string> scriptNames = GetScriptsFromGameObject(gameObject);
            // For demonstration, print to the console.
            Debug.Log("Scripts attached to " + gameObject.name + ": " + string.Join(", ", scriptNames));
        }

        private static void FindScriptsInScene(SceneAsset sceneAsset)
        {
            string scenePath = AssetDatabase.GetAssetPath(sceneAsset);
            EditorSceneManager.OpenScene(scenePath);

            GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
            HashSet<string> scriptNames = new HashSet<string>();

            foreach (var obj in allObjects)
            {
                List<string> names = GetScriptsFromGameObject(obj);
                foreach (var name in names)
                {
                    scriptNames.Add(name);
                }
            }

            // For demonstration, print to the console.
            Debug.Log("Scripts in the selected scene: " + string.Join(", ", scriptNames));
        }

        private static void FindScriptsInPrefab(GameObject prefab)
        {
            List<string> scriptNames = GetScriptsFromGameObject(prefab);

            // For demonstration, print to the console.
            Debug.Log("Scripts in the selected prefab: " + string.Join(", ", scriptNames));
        }

        private static List<string> GetScriptsFromGameObject(GameObject gameObject)
        {
            MonoBehaviour[] scripts = gameObject.GetComponentsInChildren<MonoBehaviour>(true);
            List<string> scriptNamesWithNamespace = new List<string>();

            foreach (var script in scripts)
            {
                if (script)
                {
                    Type scriptType = script.GetType();
                    string fullName = string.IsNullOrEmpty(scriptType.Namespace)
                        ? scriptType.Name
                        : scriptType.Namespace + "." + scriptType.Name;

                    scriptNamesWithNamespace.Add(fullName);


                }
            }

            return scriptNamesWithNamespace;
        }

        public static async Task AddScriptsToSlot(GameObject gameObject, string slotId)
        {
            MonoBehaviour[] scripts = gameObject.GetComponentsInChildren<MonoBehaviour>(true);

            foreach (var script in scripts)
            {
                if (script)
                {
                    string scriptPath = AssetDatabase.GetAssetPath(MonoScript.FromMonoBehaviour(script));
                    if (!string.IsNullOrEmpty(scriptPath))
                    {
                        string scriptData = ReadFileText(scriptPath);
                        string scriptDataB64 = "data:text/plain;base64," + Convert.ToBase64String(Encoding.UTF8.GetBytes(scriptData));
                        string fileName = Path.GetFileName(scriptPath);

                        ApiManager api = new ApiManager();
                        Debug.Log("Adding script: " + scriptPath + " data: " + scriptData.Substring(0, 20));

                        try
                        {
                            await api.AddScriptToSlot(slotId, fileName, scriptDataB64);
                        }
                        catch (Exception ex)
                        {
                            Debug.Log("Error adding script to slot: " + ex.Message);
                        }
                    }
                }
            }
        }



        private static string ReadFileText(string path)
        {
            // This method can be optimized for large file reading if necessary.
            return File.ReadAllText(path);
        }
    }


}