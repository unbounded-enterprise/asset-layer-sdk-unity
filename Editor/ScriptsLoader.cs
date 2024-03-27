using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using System.IO;
using System.Collections.Generic;
using Unity.EditorCoroutines.Editor;
using AssetLayer.SDK;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AssetLayer.Unity
{
    public class ScriptLoader
    {
        public class ScriptObject
        {
            public string scriptId;
            public string scriptFilename;
            public string slotId;
            public string value; // This is the URL to the script
        }

        private const string warningShownKey = "ScriptLoaderWarningShown";
        private static int scriptsToDownloadCount;
        private static int scriptsDownloadedCount;


        static ScriptLoader()
        {
            LoadAllScripts();
        }

        [MenuItem("Assets/Asset Layer/Sync/Download Required Slot Scripts")]
        public static async void LoadAllScripts()
        {
            List<ScriptObject> scriptObjects = await FetchScriptPaths();
            if (scriptObjects == null) return;

            List<string> conflictFiles = await DetectNamingConflicts(scriptObjects);

            // Debug.Log("Conflicts: " + conflictFiles + conflictFiles.Count);
            if (conflictFiles.Count > 0 && !EditorPrefs.GetBool(warningShownKey, false))
            {
                string message = "Following scripts have naming conflicts elsewhere in the project or already exist in the target directory:\n\n" + string.Join("\n", conflictFiles);
                EditorUtility.DisplayDialog("Script Naming Conflicts Detected", message, "OK");

                // Mark the warning as shown
                EditorPrefs.SetBool(warningShownKey, true);

                // Optionally, return here to prevent further processing. Comment this if you want to continue downloading non-conflicting files.
                return;
            }
            scriptsToDownloadCount = scriptObjects.Count - conflictFiles.Count;
            scriptsDownloadedCount = 0;
            foreach (var script in scriptObjects)
            {
                if (!conflictFiles.Contains(script.scriptFilename + (await GetNamespaceFromScript(script.value))))
                {
                    EditorCoroutineUtility.StartCoroutineOwnerless(DownloadCoroutine(script));
                }
            }
        }

        private static void CheckAndRefreshAssets()
        {
            scriptsDownloadedCount++;
            if (scriptsDownloadedCount == scriptsToDownloadCount)
            {
                AssetDatabase.Refresh();
            }
        }

        private static async Task<List<ScriptObject>> FetchScriptPaths()
        {
            ApiManager api = new ApiManager();
            if (string.IsNullOrEmpty(api.APP_SECRET))
            {
                return null;
            }
            string[] appslots = await api.GetAppSlots();
            if (appslots == null)
            {
                return null;
            }
            List<ScriptObject> scriptObjects = new List<ScriptObject>();


            foreach (string slotId in appslots)
            {
                List<ApiManager.Script> scriptList = await api.GetSlotScripts(slotId);


                if (scriptList == null || scriptList.Count == 0)
                {
                    Debug.Log($"No scripts found or there was an error fetching the scripts for slotId {slotId}.");
                    continue; // Continue to next slotId if no scripts found for this one
                }
                scriptList = scriptList.OrderByDescending(script => script.createdAt).ToList();

                foreach (var script in scriptList)
                {
                    scriptObjects.Add(new ScriptObject
                    {
                        scriptId = script.scriptId,
                        scriptFilename = script.fileName,
                        value = script.value,
                        slotId = slotId // Set slotId for each ScriptObject
                    });
                }
            }

            if (!scriptObjects.Any())
            {
                return null; // Return null if no scripts were added
            }

            return scriptObjects;
        }



        private static System.Collections.IEnumerator DownloadCoroutine(ScriptObject script)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(script.value))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log($"Failed to download {script.value}: {www.error}");
                }
                else
                {
                    SaveScript(www.downloadHandler.text, script.scriptFilename, script.slotId);
                    CheckAndRefreshAssets();
                }
            }
        }

        private static void SaveScript(string scriptContent, string filename, string slotId)
        {
            // Path for the 'RequiredSlotScripts' directory
            string requiredSlotScriptsDir = Path.Combine("Assets", "AssetLayerUnitySDK", "Scripts", "RequiredSlotScripts");

            // Ensure the 'RequiredSlotScripts' directory exists
            if (!Directory.Exists(requiredSlotScriptsDir))
            {
                Directory.CreateDirectory(requiredSlotScriptsDir);
            }

            // Path for the specific slot directory within 'RequiredSlotScripts'
            string directoryPath = Path.Combine(requiredSlotScriptsDir, slotId);

            // Ensure the slot-specific directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, filename);

            // Check if the file already exists in the target directory
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, scriptContent);
            }

            
        }
        private static string GetNamespaceFromFile(string fileContent)
        {
            string namespacePattern = @"^\s*namespace\s+([^{]+)";
            Match namespaceMatch = Regex.Match(fileContent, namespacePattern, RegexOptions.Multiline);

            if (namespaceMatch.Success)
            {
                string namespaceDeclaration = namespaceMatch.Groups[1].Value.Trim();
                return namespaceDeclaration;
            }

            return string.Empty;
        }

        private static async Task<string> GetNamespaceFromScript(string scriptContentUrl)
        {
            // Debug.Log("script content URL: " + scriptContentUrl);

            UnityWebRequest webRequest = UnityWebRequest.Get(scriptContentUrl);
            await webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + webRequest.error);
                return string.Empty;
            }

            string scriptContent = webRequest.downloadHandler.text;

            string namespacePattern = @"^\s*namespace\s+([^\{]+)";
            Match namespaceMatch = Regex.Match(scriptContent, namespacePattern, RegexOptions.Multiline);

            if (namespaceMatch.Success)
            {
                string namespaceDeclaration = namespaceMatch.Groups[1].Value.Trim();
                return namespaceDeclaration;
            }

            return string.Empty;
        }

        private static async Task<List<string>> DetectNamingConflicts(List<ScriptObject> scriptObjects)
        {
            string[] allScriptFiles = Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories);
            Dictionary<string, List<string>> projectScriptNamespaces = new Dictionary<string, List<string>>();

            foreach (var scriptFile in allScriptFiles)
            {
                // Exclude scripts in the RequiredSlotScripts folder
                if (!scriptFile.Contains(Path.Combine("AssetLayerUnitySDK", "Scripts", "RequiredSlotScripts")))
                {
                    string fileName = Path.GetFileName(scriptFile);
                    string fileContent = File.ReadAllText(scriptFile);
                    string fileNamespace = GetNamespaceFromFile(fileContent);
                    // Debug.Log("filenamespace:" + fileNamespace + " name: " + fileName);
                    if (!projectScriptNamespaces.ContainsKey(fileName))
                    {
                        projectScriptNamespaces[fileName] = new List<string>();
                    }
                    projectScriptNamespaces[fileName].Add(fileNamespace);
                }
            }

            List<string> conflicts = new List<string>();

            foreach (var scriptObj in scriptObjects)
            {
                if (projectScriptNamespaces.ContainsKey(scriptObj.scriptFilename))
                {
                    string incomingNamespace = await GetNamespaceFromScript(scriptObj.value);
                    // Debug.Log("script namespace: " + incomingNamespace + " scipt name: " + scriptObj.scriptFilename);
                    bool detected = false;
                    foreach (string existingNamespace in projectScriptNamespaces[scriptObj.scriptFilename])
                    {
                        if (existingNamespace.Split('.').SequenceEqual(incomingNamespace.Split('.')))
                        {
                            conflicts.Add(scriptObj.scriptFilename + incomingNamespace);
                            // Debug.Log("conflict added: " + scriptObj.scriptFilename + " with : " + existingNamespace);
                            detected = true;
                            break;
                        }
                    }
                    if (!detected)
                    {
                        // Debug.Log("No Conflict with " + incomingNamespace + " from: " + scriptObj.scriptFilename);
                    }
                }
            }

            return conflicts;
        }
    }
}
