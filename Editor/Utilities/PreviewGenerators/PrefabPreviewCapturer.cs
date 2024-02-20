#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace AssetLayer.Unity
{

    public class PrefabPreviewCapturer
    {

        

        public static async Task<string> CapturePrefabPreview(string prefabPath, float fieldOfView)
        {

            // Save the current scene
            Scene currentScene = SceneManager.GetActiveScene();
            string currentScenePath = currentScene.path;
            bool useCurrentScene = false;
            if (currentScene.isDirty)
            {
                if (EditorUtility.DisplayDialog("Unsaved Changes",
                    "The current scene has unsaved changes. Save changes before continuing?", "Yes", "No"))
                {
                    EditorSceneManager.SaveScene(currentScene);
                }
                else
                {
                    useCurrentScene = true;
                }
            }

            // Create a temporary scene

            Scene tempScene = new Scene();
            if (!useCurrentScene)
            {
                tempScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
                SceneManager.SetActiveScene(tempScene);
            }
            
            // Load the prefab
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            GameObject gameObject = PrefabUtility.InstantiatePrefab(prefab) as GameObject;

            GameObject[] lightObjects = AddLightingToScene(gameObject);

            // Create a new camera in the scene
            GameObject cameraObject = new GameObject("Preview Camera");
            Camera previewCamera = cameraObject.AddComponent<Camera>();

            // Calculate bounds
            Bounds bounds = new Bounds(gameObject.transform.position, Vector3.zero);
            foreach (Renderer renderer in gameObject.GetComponentsInChildren<Renderer>())
            {
                bounds.Encapsulate(renderer.bounds);
            }

            float maxSize = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);
            float distance = maxSize / (2.0f * Mathf.Tan(0.5f * fieldOfView * Mathf.Deg2Rad)); // changed to fieldOfView

            // Position the camera above and in front of the object and look down at 45 degrees
            cameraObject.transform.position = bounds.center + new Vector3(0, distance, -distance);
            cameraObject.transform.LookAt(bounds.center);

            // Set the field of view
            previewCamera.fieldOfView = fieldOfView;

            // Create a new RenderTexture
            RenderTexture renderTexture = new RenderTexture(500, 500, 24);
            // Assign the RenderTexture to the camera
            previewCamera.targetTexture = renderTexture;

            string outputPath = string.Empty;

            // Wait for a frame to ensure all textures are loaded
            await Task.Yield();

            // Render the camera's view to the RenderTexture
            previewCamera.Render();

            // Capture the RenderTexture to a Texture2D
            Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);
            RenderTexture.active = renderTexture;
            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture2D.Apply();

            // Write the Texture2D to a PNG file
            byte[] bytes = texture2D.EncodeToPNG();
            string directoryPath = Path.GetDirectoryName(prefabPath);
            string prefabName = Path.GetFileNameWithoutExtension(prefabPath);
            outputPath = Path.Combine(directoryPath, prefabName + "_Preview.png");
            File.WriteAllBytes(outputPath, bytes);

            // Refresh the AssetDatabase
            AssetDatabase.Refresh();

            // Cleanup
            if (previewCamera != null)
            {
                UnityEngine.Object.DestroyImmediate(previewCamera.gameObject);
            }

            if (useCurrentScene)
            {

                // Cleanup the prefab GameObject in the current scene
                if (gameObject != null)
                {
                    UnityEngine.Object.DestroyImmediate(gameObject);
                }
                // Cleanup the light objects in the current scene
                foreach (GameObject lightObject in lightObjects)
                {
                    if (lightObject != null)
                    {
                        UnityEngine.Object.DestroyImmediate(lightObject);
                    }
                }
            }

            if (renderTexture != null)
            {
                renderTexture.Release();
            }
            if (!useCurrentScene && tempScene.IsValid())
            {
                EditorSceneManager.CloseScene(tempScene, true);

                if (!string.IsNullOrEmpty(currentScenePath))
                {
                    EditorSceneManager.OpenScene(currentScenePath);
                }
            }
            
            

            return outputPath;
        }

        private static GameObject[] AddLightingToScene(GameObject targetObject)
        {
            // Add a directional light
            GameObject directionalLight = new GameObject("Directional Light");
            Light dirLight = directionalLight.AddComponent<Light>();
            dirLight.type = LightType.Directional;
            dirLight.intensity = 1.0f;
            dirLight.transform.eulerAngles = new Vector3(50, -30, 0); // Adjust angles for better lighting

            // Add the first spotlight
            GameObject spotlight1 = new GameObject("Spotlight 1");
            Light spotLight1 = spotlight1.AddComponent<Light>();
            spotLight1.type = LightType.Spot;
            spotLight1.intensity = 1.0f;
            spotLight1.spotAngle = 45;
            spotLight1.transform.position = targetObject.transform.position + new Vector3(-3, 3, -3); // Adjust position
            spotLight1.transform.LookAt(targetObject.transform);

            // Add the second spotlight
            GameObject spotlight2 = new GameObject("Spotlight 2");
            Light spotLight2 = spotlight2.AddComponent<Light>();
            spotLight2.type = LightType.Spot;
            spotLight2.intensity = 1.0f;
            spotLight2.spotAngle = 45;
            spotLight2.transform.position = targetObject.transform.position + new Vector3(3, 3, 3); // Adjust position
            spotLight2.transform.LookAt(targetObject.transform);

            return new GameObject[] { directionalLight, spotlight1, spotlight2 };
        }
    }
}
#endif
