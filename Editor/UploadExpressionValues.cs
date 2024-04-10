using UnityEditor;
using UnityEngine;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AssetLayer.SDK.Collections;
using UnityEngine.UIElements;
using Nethereum.Contracts.Standards.ERC20.TokenList;
using UnityGLTF;

namespace AssetLayer.Unity
{

    public class UploadExpressionAssets : EditorWindow
    {
        string collectionId = "";
        string expressionId = "";
        public GUISkin AssetLayerGUISkin;
        [SerializeField]
        private VisualTreeAsset m_VisualTreeAsset = default;

        [SerializeField]
        private VisualTreeAsset successTree = default;

        [SerializeField]
        private VisualTreeAsset warningTree = default;

        [SerializeField]
        private VisualTreeAsset loginPromptTree = default;

        string successMessage = "";
        const string BUNDLEPATH = "AssetlayerUnitySDK/AssetBundles";
        float fieldOfView = 120f;
        float fieldOfViewPrefab = 30f;
        private const string AppAssetsPath = "Assets/AssetlayerUnitySDK/AppAssets";

        private bool isUploadingExpression = false;

        [MenuItem("Assets/Asset Layer/Update/Upload Expression Assets")]
        static void ShowWindow()
        {
            // Show existing window instance. If one doesn't exist, make one.
            UploadExpressionAssets editorWin = EditorWindow.GetWindow<UploadExpressionAssets>(); // (typeof(UploadExpressionAssets), true, "Upload Expression Assets");
            editorWin.titleContent = new GUIContent("UploadExpressionAssets");
            editorWin.minSize = new Vector2(778, 444);
            editorWin.maxSize = editorWin.minSize;


        }
#if UNITY_2021
        /* 
        void OnGUI()
        {
            if (isUploadingExpression || !string.IsNullOrEmpty(successMessage))
            {
                if (!string.IsNullOrEmpty(successMessage))
                {
                    GUILayout.Label(successMessage, EditorStyles.boldLabel);
                    if (GUILayout.Button("Close"))
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                GUILayout.Label("Upload Expression Values", EditorStyles.boldLabel);
                collectionId = EditorGUILayout.TextField("Collection ID", collectionId);
                expressionId = EditorGUILayout.TextField("Expression ID", expressionId);
                image = (Texture2D)EditorGUILayout.ObjectField("Image", image, typeof(Texture2D), false);

                if (GUILayout.Button("Submit"))
                {
                    isUploadingExpression = true;
                    CreateBundleAndUploadExpression(collectionId, expressionId);
                }
            }
        } */
#endif

        void ShowLoginPromptUI()
        {
            // Clear the current UI
            rootVisualElement.Clear();

            // Clone and add the success UI to the root
            VisualElement loginRoot = loginPromptTree.CloneTree();
            rootVisualElement.Add(loginRoot);


            // Optionally, you can set up a close button in your success UXML
            var closeButton = loginRoot.Q<Button>("CloseButton"); // Adjust the name as necessary
            if (closeButton != null)
            {
                closeButton.clickable.clicked += () => this.Close(); // Close the window when the close button is clicked
            }

            var linkButton2 = loginRoot.Q<Button>("AssetLayerApp");
            linkButton2.clickable.clicked += () => Application.OpenURL("https://www.assetlayer.com");

            var linkButton3 = loginRoot.Q<Button>("UnityCollectionCreationGuide");
            linkButton3.clickable.clicked += () => Application.OpenURL("https://docs.assetlayer.com/create-assets/create-assets-without-code/submit-a-collection-for-a-3rd-party-app-coming-soon");
        }

        void ShowSuccessUI()
        {
            // Clear the current UI
            rootVisualElement.Clear();

            // Clone and add the success UI to the root
            VisualElement successRoot = successTree.CloneTree();
            rootVisualElement.Add(successRoot);


            // Optionally, you can set up a close button in your success UXML
            var closeButton = successRoot.Q<Button>("CloseButton"); // Adjust the name as necessary
            if (closeButton != null)
            {
                closeButton.clickable.clicked += () => this.Close(); // Close the window when the close button is clicked
            }

            var linkButton2 = successRoot.Q<Button>("AssetLayerApp");
            linkButton2.clickable.clicked += () => Application.OpenURL("https://www.assetlayer.com");

            var linkButton3 = successRoot.Q<Button>("UnityCollectionCreationGuide");
            linkButton3.clickable.clicked += () => Application.OpenURL("https://docs.assetlayer.com/create-assets/create-assets-without-code/submit-a-collection-for-a-3rd-party-app-coming-soon");
        }

        void ShowWarningUI()
        {
            // Clear the current UI
            rootVisualElement.Clear();

            // Clone and add the success UI to the root
            VisualElement warningRoot = warningTree.CloneTree();
            rootVisualElement.Add(warningRoot);


            // Optionally, you can set up a close button in your success UXML
            var finalSubmitButton = warningRoot.Q<Button>("FinalSubmitButton"); // Adjust the name as necessary
            if (finalSubmitButton != null)
            {
                finalSubmitButton.clickable.clicked += SubmitClicked; // Close the window when the close button is clicked
            }

        }

        public void CreateGUI()
        {
#if UNITY_2021
            return;
#endif
            ApiManager manager = new ApiManager();
            if (string.IsNullOrEmpty(manager.DID_TOKEN))
            {
                ShowLoginPromptUI();
                return;
            }

            rootVisualElement.style.flexDirection = FlexDirection.Column;
            rootVisualElement.style.justifyContent = Justify.SpaceBetween;
            rootVisualElement.style.height = Length.Percent(100);
            VisualElement root = m_VisualTreeAsset.CloneTree();
            rootVisualElement.Add(root);
            // Set up the link button
            var linkButton = root.Q<Button>("myPendingCollectionsLink");
            linkButton.clickable.clicked += () => Application.OpenURL("https://www.assetlayer.com");


            var submitButton = root.Q<Button>("SubmitButton");
            submitButton.clickable.clicked += SubmitOneClicked;

            /* // Optionally, load USS file
            StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("path/to/your.uss");
            rootVisualElement.styleSheets.Add(styleSheet); */
        }

        void SubmitOneClicked()
        {
            collectionId = rootVisualElement.Q<TextField>("collectionID").value;
            expressionId = rootVisualElement.Q<TextField>("expressionID").value;
            if (expressionId == "Enter Expression ID")
            {
                expressionId = "";
            }
            if (collectionId == "Enter Collection ID")
            {
                collectionId = "";
            }
            ShowWarningUI();
        }

        async void SubmitClicked()
        {
            isUploadingExpression = true;
            var submitButton = rootVisualElement.Q<Button>("FinalSubmitButton");
            submitButton.style.display = DisplayStyle.None;

            await CreateBundleAndUploadExpression(collectionId.Trim(), expressionId.Trim());

            isUploadingExpression = false;

            if (true)
            {
                Debug.Log("AssetBundle uploaded successfully!");
                successMessage = "AssetBundle created and uploaded successfully!";
                ShowSuccessUI(); // Call method to show success UI
            }
            else
            {
                Debug.Log("Failed to upload AssetBundle.");
            }

        }

#if UNITY_2021
        void OnGUI()
        {
            // GUI.skin = this.AssetLayerGUISkin;
            if (isUploadingExpression || !string.IsNullOrEmpty(successMessage))
            {
                if (!string.IsNullOrEmpty(successMessage))
                {
                    GUILayout.Label(successMessage, EditorStyles.boldLabel);
                    if (GUILayout.Button("Close"))
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                GUIStyle customButtonStyle = new GUIStyle(GUI.skin.button)
                {
                    fontSize = 12,
                    fontStyle = FontStyle.Bold
                };

                GUILayout.Label("Upload Expression Assets", EditorStyles.boldLabel);

                EditorGUILayout.LabelField("Collection ID: Used to identify your collection.");
                GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Can be found in ", GUILayout.Width(110));
                GUIStyle linkStyle = new GUIStyle(EditorStyles.linkLabel)
                {
                    wordWrap = true
                };
                if (GUILayout.Button("My Pending Collections", linkStyle))
                {
                    Application.OpenURL("https://www.assetlayer.com");
                }
                GUILayout.EndHorizontal();

                // Placeholder for Collection ID
                GUI.SetNextControlName("CollectionIDField");
                collectionId = EditorGUILayout.TextField(string.IsNullOrEmpty(collectionId) || collectionId == "Enter Collection ID" ? "" : collectionId);
                if (GUI.GetNameOfFocusedControl() != "CollectionIDField" && string.IsNullOrEmpty(collectionId))
                {
                    collectionId = "Enter Collection ID";
                }

                EditorGUILayout.LabelField("Expression ID: Used to identify the collection you are uploading assets for.");

                // Placeholder for Expression ID
                GUI.SetNextControlName("ExpressionIDField");
                expressionId = EditorGUILayout.TextField(string.IsNullOrEmpty(expressionId) || expressionId == "Enter Expression ID" ? "" : expressionId);
                if (GUI.GetNameOfFocusedControl() != "ExpressionIDField" && string.IsNullOrEmpty(expressionId))
                {
                    expressionId = "Enter Expression ID";
                }


                if (GUILayout.Button("Submit"))
                {
                    isUploadingExpression = true;
                    CreateBundleAndUploadExpression(collectionId, expressionId);
                }

            }
        }
#endif


        async Task CreateBundleAndUploadExpression(string collectionId, string expressionId = "")
        {
            // get collection info
            ApiManager manager = new ApiManager();
            List<string> collectionIds = new List<string>();
            collectionIds.Add(collectionId);
            List<Collection> collectionInfo = await manager.GetCollectionInfo(collectionIds);
            string collectionName = collectionInfo[0].collectionName;
            string slotId = collectionInfo[0].slotId;

            UnityEngine.Object selectedObject = Selection.activeObject;


            // AssetBundling process
            var selectedAssets = Selection.objects;
            if (selectedAssets.Length == 0)
            {
                UnityEngine.Debug.Log("No assets selected for bundling");
                return;
            }
            string bundleName = selectedAssets[0].name.ToLower();
            foreach (var asset in selectedAssets)
            {
                string assetPath = AssetDatabase.GetAssetPath(asset);
                AssetImporter.GetAtPath(assetPath).SetAssetBundleNameAndVariant(bundleName, "");
            }

            AssetBundleBuild[] buildMap = new AssetBundleBuild[1];
            buildMap[0].assetBundleName = bundleName;
            buildMap[0].assetNames = AssetDatabase.GetAssetPathsFromAssetBundle(bundleName);

            // Ensure the bundle save path exists.
            string fullPath = Path.Combine(Application.dataPath, BUNDLEPATH);
            EnsureDirectoryExists(fullPath);


            bool uploadSuccess = false;
            try
            {
                BuildTarget[] platforms =
                {
                BuildTarget.iOS,
                BuildTarget.Android,
                BuildTarget.StandaloneWindows,
                BuildTarget.StandaloneOSX,
                BuildTarget.WebGL
            };

                foreach (BuildTarget platform in platforms)
                {
                    // Build the asset bundles for the current platform
                    BuildPipeline.BuildAssetBundles(fullPath, buildMap, BuildAssetBundleOptions.ChunkBasedCompression, platform);


                    // Move and get the dataUrl for the bundle
                    string bundlePath = MoveAssetBundles(bundleName);
                    string dataUrl = BundleToDataUrl(bundlePath);

                    // Upload the AssetBundle for the current platform using the SDK.
                    uploadSuccess = await manager.UploadBundleExpression(collectionId, dataUrl, "AssetBundle" + platform.ToString(), "AssetBundle", expressionId);

                    if (!uploadSuccess)
                    {
                        Debug.LogError($"Failed to upload AssetBundle for platform {platform}.");
                    }
                }

                if (selectedObject != null)
                {
                    try
                    {
                        string location = PrefabPacker.PackagePrefab((GameObject)selectedObject, slotId);
                        string unityPackageDataUrl = BundleToDataUrl(location);
                        await manager.UploadBundleExpression(collectionId, unityPackageDataUrl, "UnityPackage", "AssetBundle", expressionId);
                        try
                        {
                            string glb = ExportGameObjectToGLB.ExportToGLBDataURL((GameObject)selectedObject);

                            if (!string.IsNullOrEmpty(glb))
                            {
                                await manager.UploadBundleExpression(collectionId, glb, "GLB", "AssetBundle", expressionId);
                            }
                        }
                        catch (Exception glbException)
                        {
                            Debug.Log("skipping glb upload" + glbException.Message);
                        }

                        Debug.Log("upload package expression done");
                    }
                    catch (Exception ex)
                    {
                        Debug.Log("unity package saving failed: " + ex.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Exception caught: " + e.ToString());
            }

            if (uploadSuccess && selectedObject is GameObject)
            {
                try
                {
                    await ReferencedScriptsFinder.AddScriptsToSlot(selectedObject as GameObject, slotId);
                }
                catch (Exception e)
                {
                    Debug.Log("Script uploading failed due to: " + e.Message);
                }
            }

            if (uploadSuccess && selectedObject is GameObject)
            {
                SavePrefab((GameObject)selectedObject, slotId, collectionId, collectionName);
            }

            if (uploadSuccess)
            {

                Debug.Log("AssetBundle uploaded successfully!");
                successMessage = "AssetBundle created and uploaded successfully!";
                Repaint();
            }
            else
            {
                Debug.Log("Failed to upload AssetBundle.");
            }

            foreach (var asset in selectedAssets)
            {
                if (asset == null)
                {
                    continue;
                }
                string assetPath = AssetDatabase.GetAssetPath(asset);
                AssetImporter.GetAtPath(assetPath).SetAssetBundleNameAndVariant("", "");
            }

            AssetDatabase.Refresh();
        }

        public string MoveAssetBundles(string bundleName)
        {
            // Convert the relative bundle path to an absolute path
            string absoluteBundlePath = Path.Combine(Application.dataPath, BUNDLEPATH);

            string bundleDirectoryPath = Path.Combine(absoluteBundlePath, bundleName + "_dir");

            if (Directory.Exists(bundleDirectoryPath))
            {
                Directory.Delete(bundleDirectoryPath, true);
            }
            Directory.CreateDirectory(bundleDirectoryPath);

            string bundlePath = Path.Combine(absoluteBundlePath, bundleName);
            string bundleManifestPath = Path.Combine(absoluteBundlePath, bundleName + ".manifest");
            string targetBundlePath = Path.Combine(bundleDirectoryPath, bundleName + ".bundle");
            string targetBundleManifestPath = Path.Combine(bundleDirectoryPath, bundleName + ".bundle.manifest");

            if (File.Exists(targetBundlePath))
            {
                File.Delete(targetBundlePath);
            }

            if (File.Exists(targetBundleManifestPath))
            {
                File.Delete(targetBundleManifestPath);
            }

            File.Move(bundlePath, targetBundlePath);
            File.Move(bundleManifestPath, targetBundleManifestPath);

            return targetBundlePath;
        }

        private void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void SavePrefab(GameObject selectedGameObject, string slotId, string collectionId, string collectionName)
        {
            try
            {
                string slotFolderPath = Path.Combine(AppAssetsPath, slotId);
                string collectionFolderPath = Path.Combine(slotFolderPath, collectionId);
                string gameObjectPath = Path.Combine(slotFolderPath, collectionName + collectionId + ".prefab");

                // Create directories if they do not exist
                EnsureDirectoryExists(AppAssetsPath);
                EnsureDirectoryExists(slotFolderPath);
                EnsureDirectoryExists(collectionFolderPath);

                // Check if a prefab with the same name already exists
                if (File.Exists(gameObjectPath))
                {
                    // Delete the existing prefab
                    AssetDatabase.DeleteAsset(gameObjectPath);
                }

                // Save the prefab to disk
                GameObject prefabAsset = PrefabUtility.SaveAsPrefabAsset(selectedGameObject, gameObjectPath);

                if (prefabAsset != null)
                {
                    // Calculate hash
                    string prefabHash = UtilityFunctions.CalculatePrefabHash(prefabAsset);
                    Debug.Log("Prefab Hash: " + prefabHash);

                    // Load the AssetBundleDatabase ScriptableObject
                    string databasePath = "Assets/AssetlayerUnitySDK/ScriptableObjects/AssetBundleDatabase.asset";
                    AssetBundleDatabase assetBundleDatabase = AssetDatabase.LoadAssetAtPath<AssetBundleDatabase>(databasePath);
                    if (assetBundleDatabase == null)
                    {
                        Debug.LogError("AssetBundleDatabase not found at path: " + databasePath);
                        return;
                    }
                    else
                    {
                        Debug.Log("scriptable object found");
                    }

                    // Create a new AssetBundleData entry
                    AssetBundleData newAssetBundleData = new AssetBundleData
                    {
                        prefabPath = gameObjectPath,
                        hash = prefabHash,
                        collectionId = collectionId,
                        collectionName = collectionName,
                        slotId = slotId,
                        version = "1.0" // Set the version number as required
                    };

                    // Add the new entry to the AssetBundleDatabase
                    assetBundleDatabase.bundles.Add(newAssetBundleData);

                    // Save changes to the AssetBundleDatabase
                    EditorUtility.SetDirty(assetBundleDatabase);
                    AssetDatabase.SaveAssets();

                    // Refresh the AssetDatabase
                    AssetDatabase.Refresh();
                }
                else
                {
                    Debug.LogError("Failed to save prefab: " + selectedGameObject.name);
                }
            }
            catch (Exception ex)
            {
                Debug.Log("save prefab exception: " + ex.Message);
            }

        }


        Texture2D MakeTextureReadable(Texture2D originalTexture)
        {
            if (originalTexture.isReadable)
            {
                return originalTexture;
            }
            RenderTexture renderTexture = RenderTexture.GetTemporary(
                originalTexture.width,
                originalTexture.height,
                0,
                RenderTextureFormat.Default,
                RenderTextureReadWrite.Linear);

            Graphics.Blit(originalTexture, renderTexture);
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = renderTexture;
            Texture2D readableTexture = new Texture2D(originalTexture.width, originalTexture.height);
            readableTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            readableTexture.Apply();
            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(renderTexture);

            return readableTexture;
        }

        string ImageToDataUrl(Texture2D image)
        {
            byte[] imageBytes = image.EncodeToPNG();
            string base64String = Convert.ToBase64String(imageBytes);
            return "data:image/png;base64," + base64String;
        }

        string ImageToDataUrlResized(Texture2D image)
        {
            Texture2D resizedImage = new Texture2D(500, 500);
            RenderTexture rt = RenderTexture.GetTemporary(500, 500);
            RenderTexture.active = rt;
            Graphics.Blit(image, rt);
            resizedImage.ReadPixels(new Rect(0, 0, 500, 500), 0, 0);
            resizedImage.Apply();
            RenderTexture.active = null;
            rt.Release();

            byte[] imageBytes = resizedImage.EncodeToPNG();
            string base64String = Convert.ToBase64String(imageBytes);

            return "data:image/png;base64," + base64String;
        }

        string BundleToDataUrl(string bundleFilePath)
        {
            byte[] bundleBytes = File.ReadAllBytes(bundleFilePath);
            string base64String = Convert.ToBase64String(bundleBytes);
            return "data:application/octet-stream;base64," + base64String;
        }
    }

}
