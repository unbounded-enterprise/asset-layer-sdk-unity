using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

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

        [MenuItem("Tools/Log Scripts from Selected GameObject")]
        private static void LogScriptsFromSelectedGameObject()
        {
            GameObject selectedGameObject = Selection.activeGameObject;
            if (selectedGameObject != null)
            {
                List<string> scriptNames = GetScriptsFromGameObject(selectedGameObject);
                // Debug.Log("Scripts attached to " + selectedGameObject.name + ": " + string.Join(", ", scriptNames));
            }
            else
            {
                Debug.LogWarning("No GameObject selected.");
            }
        }

        // [MenuItem("Tools/Log Scripts test")]
        private static HashSet<string>  FindScriptsInGlobalNamespace()
        {
            HashSet<string> globalNamespaceScripts = new HashSet<string>();
            // Get all loaded assemblies
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // Loop through each assembly
            foreach (var assembly in assemblies)
            {

                // Skip Unity engine assemblies
                // if (IsUnityEngineAssembly(assembly))
                   // continue;
                
                // Get all types in the assembly
                var types = assembly.GetTypes();

                // Filter to only get types that are classes, have a global namespace, and inherit from MonoBehaviour
                var scriptsInGlobalNamespace = types.Where(t => t.IsClass && string.IsNullOrEmpty(t.Namespace) && t.IsSubclassOf(typeof(MonoBehaviour)));

                // Print the names of the scripts in the global namespace
                foreach (var type in scriptsInGlobalNamespace)
                {
                    // Debug.Log("global: " + type.Name);
                    globalNamespaceScripts.Add(type.FullName);
                }
            }

            return globalNamespaceScripts;
        }

        private static bool IsSystemOrUnityorAssetLayerNamespace(string namespaceName)
        {
            if (string.IsNullOrEmpty(namespaceName))
                return false;
            return namespaceName.StartsWith("System") || namespaceName.StartsWith("UnityEngine") || namespaceName.StartsWith("UnityEditor") || namespaceName.StartsWith("Unity") || namespaceName.Contains("AssetLayer");
        }

        private static bool IsUnityEngineAssembly(string assemblyName)
        {
            if (string.IsNullOrEmpty(assemblyName))
                return false;

            // Try to load the assembly
            if (!TryLoadAssembly(assemblyName, out Assembly assembly))
                return false;

            // Check if the assembly is part of the Unity engine assemblies
            if (assembly.GetReferencedAssemblies().Any(assemblyRef => assemblyRef.Name.StartsWith("Unity")))
                return true;

            // Check if the assembly is part of other third-party assemblies you want to exclude
            if (assembly.GetReferencedAssemblies().Any(assemblyRef => assemblyRef.Name.StartsWith("AssetLayer")))
                return true;

            return false;
        }

        private static void FindScriptsInPrefab(GameObject prefab)
        {
            List<string> scriptNames = GetScriptsFromGameObject(prefab);

            // For demonstration, print to the console.
            Debug.Log("Scripts in the selected prefab: " + string.Join(", ", scriptNames));
        }

        /* private static List<string> GetScriptsFromGameObject(GameObject gameObject)
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
        } */

        private static List<string> GetScriptsFromGameObject(GameObject gameObject)
        {
            MonoBehaviour[] scripts = gameObject.GetComponentsInChildren<MonoBehaviour>(true);
            List<string> scriptNamesWithNamespace = new List<string>();
            HashSet<string> seenScripts = new HashSet<string>(); // To avoid duplicates

            foreach (var script in scripts)
            {
                if (script)
                {
                    Type scriptType = script.GetType();
                    string scriptAssemblyName = scriptType.AssemblyQualifiedName;
                    if (IsSystemOrUnityorAssetLayerNamespace(scriptType.Namespace) || IsUnityEngineAssembly(scriptAssemblyName))
                    {
                        continue; // Skip scripts from System, Unity, or AssetLayer namespaces
                    }
                    string fullName = string.IsNullOrEmpty(scriptType.Namespace)
                        ? scriptType.Name
                        : scriptType.Namespace + "." + scriptType.Name;

                    scriptNamesWithNamespace.Add(fullName);
                    seenScripts.Add(fullName);

                    string scriptPath = AssetDatabase.GetAssetPath(MonoScript.FromMonoBehaviour(script));

                    if (!string.IsNullOrEmpty(scriptPath))
                    {
                        List<string> referencedScripts = GetReferencedScripts(scriptPath);
                        foreach (string referencedScript in referencedScripts)
                        {
                            if (!seenScripts.Contains(referencedScript))
                            {
                                scriptNamesWithNamespace.Add(referencedScript);
                                seenScripts.Add(referencedScript);
                                // Debug.Log("script added: " + referencedScript);
                            }
                        }
                    }
                }
            }
            // Debug.Log("script Names with namespaces:" + scriptNamesWithNamespace);
            return scriptNamesWithNamespace;
        }

        private static bool TryLoadAssembly(string assemblyName, out Assembly assembly)
        {
            try
            {
                assembly = Assembly.Load(assemblyName);
                return true;
            }
            catch (Exception)
            {
                assembly = null;
                return false;
            }
        }

        private static List<string> GetReferencedScripts(string scriptPath, string targetNamespace = null, HashSet<string> seenScripts = null)
        {
            if (seenScripts == null)
                seenScripts = new HashSet<string>();

            List<string> referencedScripts = new List<string>();
            string scriptCode = File.ReadAllText(scriptPath);

            // Match using statements
            MatchCollection usingMatches = Regex.Matches(scriptCode, @"using\s+([\w\.]+);");
            foreach (Match match in usingMatches)
            {
                string usingNamespace = match.Groups[1].Value;
                if (targetNamespace == null || usingNamespace.StartsWith(targetNamespace))
                {
                    if (!IsSystemOrUnityorAssetLayerNamespace(usingNamespace) && !IsUnityEngineAssembly(usingNamespace) && !seenScripts.Contains(usingNamespace))
                    {
                        referencedScripts.Add(usingNamespace);
                        seenScripts.Add(usingNamespace);
                    }
                }
            }

            // Match class definitions with and without namespace
            MatchCollection classDefMatches = Regex.Matches(scriptCode, @"\bnamespace\s+(?:(" + targetNamespace + @"\.\w+)|((?!\s*namespace\b)\w+))\s*\{");
            foreach (Match match in classDefMatches)
            {
                string className = match.Groups[1].Value;
                if (string.IsNullOrEmpty(className))
                {
                    className = match.Groups[2].Value;
                }
                if (!IsSystemOrUnityorAssetLayerNamespace(className) && !IsUnityEngineAssembly(className) && !seenScripts.Contains(className))
                {
                    referencedScripts.Add(className);
                    seenScripts.Add(className);
                }
            }

            // Get scripts in the global namespace
            HashSet<string> scriptsInGlobalNamespace = FindScriptsInGlobalNamespace();

            // Add scripts from the global namespace that are referenced in the current script
            foreach (string script in scriptsInGlobalNamespace)
            {
                if (scriptCode.Contains(script))
                {
                    if (!IsSystemOrUnityorAssetLayerNamespace(script) && !IsUnityEngineAssembly(script) && !seenScripts.Contains(script))
                    {
                        referencedScripts.Add(script);
                        seenScripts.Add(script);
                    }
                }
            }

            // Create a temporary list to avoid modifying the collection while enumerating
            List<string> tempReferencedScripts = new List<string>(referencedScripts);

            // Recursively get referenced scripts from the referenced scripts
            foreach (string referencedScript in tempReferencedScripts)
            {
                string referencedScriptPath = GetScriptPathFromName(referencedScript);
                if (!string.IsNullOrEmpty(referencedScriptPath))
                {
                    referencedScripts.AddRange(GetReferencedScripts(referencedScriptPath, targetNamespace, seenScripts));
                }
            }

            return referencedScripts;
        }

        private static string GetScriptPathFromName(string scriptName)
        {
            string[] assetGuids = AssetDatabase.FindAssets($"t:MonoScript {scriptName.Replace(".", "/")}", null);
            if (assetGuids.Length > 0)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(assetGuids[0]);
                return assetPath;
            }
            return null;
        }

        public static async Task AddScriptsToSlot(GameObject gameObject, string slotId)
        {
            List<string> scriptNamesWithNamespace = GetScriptsFromGameObject(gameObject);

            foreach (string scriptName in scriptNamesWithNamespace)
            {
                string scriptPath = GetScriptPathFromName(scriptName);
                if (scriptPath.StartsWith("Packages/"))
                {
                    // ideally code here that informs the downloader that he has to install that package
                    continue;
                }
                if (!string.IsNullOrEmpty(scriptPath))
                {
                    string scriptData = ReadFileText(scriptPath);
                    string scriptDataB64 = "data:text/plain;base64," + Convert.ToBase64String(Encoding.UTF8.GetBytes(scriptData));
                    string fileName = Path.GetFileName(scriptPath);

                    ApiManager api = new ApiManager();
                    // Debug.Log("Adding script: " + scriptPath + " data: " + scriptData.Substring(0, 20));

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



        private static string ReadFileText(string path)
        {
            // This method can be optimized for large file reading if necessary.
            return File.ReadAllText(path);
        }
    }


}