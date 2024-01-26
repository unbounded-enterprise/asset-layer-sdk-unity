using UnityEditor;
using UnityEngine;

public class ModifyStripSettings
{
    private const string PrefKey = "HasPromptedForStripCodeSetting";

    [InitializeOnLoadMethod]
    static void ModifyStripCodeSetting()
    {
        bool hasPrompted = EditorPrefs.GetBool(PrefKey, false);

        if (!hasPrompted && PlayerSettings.stripEngineCode)
        {
            if (EditorUtility.DisplayDialog("Strip Code Setting",
                    "The current project has code stripping enabled, this might lead to Asset Layer Assets not loading correctly, do you want to disable it?",
                    "Yes", "No"))
            {
                PlayerSettings.stripEngineCode = false;
                Debug.Log("Strip Code Setting has been disabled.");
            }
            else
            {
                Debug.Log("User chose not to disable Strip Code Setting.");
                EditorPrefs.SetBool(PrefKey, true); // Set the flag so the user is not prompted again
            }
        }
        else if (!hasPrompted)
        {
        }
    }
}
