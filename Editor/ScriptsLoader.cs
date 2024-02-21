using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using System.IO;
using System.Collections.Generic;
using Unity.EditorCoroutines.Editor;
using AssetLayer.SDK;
using System.Threading.Tasks;
using System.Linq;

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


        static ScriptLoader()
        {
            LoadAllScripts();
        }

        [MenuItem("Assets/Asset Layer/Sync/Download Required Slot Scripts")]
        public static async void LoadAllScripts()
        {
            List<ScriptObject> scriptObjects = await FetchScriptPaths();
            if (scriptObjects == null) return;

            List<string> conflictFiles = DetectNamingConflicts(scriptObjects);

            if (conflictFiles.Count > 0 && !EditorPrefs.GetBool(warningShownKey, false))
            {
                string message = "Following scripts have naming conflicts elsewhere in the project or already exist in the target directory:\n\n" + string.Join("\n", conflictFiles);
                EditorUtility.DisplayDialog("Script Naming Conflicts Detected", message, "OK");

                // Mark the warning as shown
                EditorPrefs.SetBool(warningShownKey, true);

                // Optionally, return here to prevent further processing. Comment this if you want to continue downloading non-conflicting files.
                return;
            }

            foreach (var script in scriptObjects)
            {
                if (!conflictFiles.Contains(script.scriptFilename)) // Only download non-conflicting files
                {
                    EditorCoroutineUtility.StartCoroutineOwnerless(DownloadCoroutine(script));
                }
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

            // Check if the file already exists
            if (File.Exists(filePath))
            {
                Debug.LogWarning($"{filename} already exists in slot {slotId}. Skipping download.");
                return;
            }

            File.WriteAllText(filePath, scriptContent);
            AssetDatabase.Refresh();
        }

        private static List<string> DetectNamingConflicts(List<ScriptObject> scriptObjects)
        {
            string[] allScriptFiles = Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories);
            HashSet<string> projectScriptNames = new HashSet<string>();

            foreach (var scriptFile in allScriptFiles)
            {
                // Exclude scripts in the RequiredSlotScripts folder
                if (!scriptFile.Contains(Path.Combine("AssetLayerUnitySDK", "Scripts", "RequiredSlotScripts")))
                {
                    projectScriptNames.Add(Path.GetFileName(scriptFile));
                }
            }

            List<string> conflicts = new List<string>();
            foreach (var scriptObj in scriptObjects)
            {
                if (projectScriptNames.Contains(scriptObj.scriptFilename))
                {
                    conflicts.Add(scriptObj.scriptFilename);
                }
            }

            return conflicts;
        }
    }
}
