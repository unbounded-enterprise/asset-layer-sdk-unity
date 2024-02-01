using UnityEditor;
using UnityEngine;
using System.IO;
using System;
using System.Threading.Tasks;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UIElements;

namespace AssetLayer.Unity
{

    public class CreateAssetBundlesFromSelection : EditorWindow
    {
        
        [MenuItem("Assets/Asset Layer/Create New Collection")]

        static void ShowWindow()
        {
            // Show existing window instance. If one doesn't exist, make one.
            EditorWindow editorWin = EditorWindow.GetWindow(typeof(CreateAssetBundlesFromSelection));
            editorWin.titleContent = new GUIContent("Create New Collection");
            editorWin.minSize = new Vector2(978, 744);
            editorWin.maxSize = editorWin.minSize;
        }
    
        [SerializeField]
        private VisualTreeAsset visualTreeAsset = default;

        [SerializeField]
        private VisualTreeAsset successTree = default;

        [SerializeField]
        private VisualTreeAsset warningTree = default;
        string slotId = "";
        string collectionName = "MyPrefabCollection";
        string[] slotNames;
        int? maximum = 0;
        int mintImmediately = 0;
        bool noMax = true;
        Texture2D image;
        string successMessage = "";
        const string BUNDLEPATH = "AssetlayerUnitySDK/AssetBundles";
        private const string AppAssetsPath = "Assets/AssetlayerUnitySDK/AppAssets";
        private const string DatabasePath = "Assets/AssetlayerUnitySDK/ScriptableObjects/AssetBundleDatabase.asset";
        float fieldOfView = 120f;
        float fieldOfViewPrefab = 30f;
        string[] slotIds;
        int slotIndex = 0;
        string expressionId;
        private int savedMax = 0;

        private bool isCreatingCollection = false;

        void OnEnable()
        {
            FetchSlotNames();
        }

        async void FetchSlotNames()
        {
            ApiManager sdkInstance = new ApiManager();
            slotIds = await sdkInstance.GetAppSlots();
            Debug.Log("slotids: " + slotIds);
            if (slotIds != null)
            {
                slotNames = new string[slotIds.Length];
                for (int i = 0; i < slotIds.Length; i++)
                {
                    var slotInfo = await sdkInstance.GetSlotInfo(slotIds[i]);
                    if (slotInfo != null && slotInfo.slotName != null)
                    {
                        slotNames[i] = slotInfo.slotName;
                    }
                }
                Debug.Log("slotnames: " + slotNames[0]);
                // Update the dropdown after the async operation
                EditorApplication.QueuePlayerLoopUpdate();
                EditorApplication.delayCall += UpdateDropdownWithSlotNames;
            }
        }

        void UpdateDropdownWithSlotNames()
        {
            // Assuming dropdownField is the DropdownField in your UI
            var dropdownField = rootVisualElement.Q<DropdownField>("SlotIdDropdown");
            if (dropdownField != null)
            {
                dropdownField.choices = new List<string>(slotNames);
                if (slotNames.Length > 0)
                {
                    dropdownField.value = slotNames[0];
                }
            }
            
        }



        private void EnsureAssetBundleDatabaseExists()
        {
            EnsureDirectoryExists(Path.GetDirectoryName(DatabasePath));
            if (!File.Exists(DatabasePath))
            {
                AssetBundleDatabase assetBundleDatabase = CreateInstance<AssetBundleDatabase>();
                AssetDatabase.CreateAsset(assetBundleDatabase, DatabasePath);
            }
        }

        void CreateGUI()
        {
            // Clear existing content
            rootVisualElement.Clear();
            // Load and clone the main UI template
            var root = visualTreeAsset.CloneTree();
            rootVisualElement.Add(root);

            // Setup collection name input
            var collectionNameInput = root.Q<TextField>("CollectionNameInput");
            collectionNameInput.value = collectionName;
            collectionNameInput.RegisterValueChangedCallback(evt => collectionName = evt.newValue);
            var expressionDropdown = root.Q<DropdownField>("ExpressionDropdown");
            // Initial setup might be needed here, e.g., UpdateExpressionDropdown(expressionDropdown, initialSlotId);
            expressionDropdown.RegisterValueChangedCallback(evt => {
                expressionId = evt.newValue; // Assuming expressionId is a string. Adjust if it's an index or another type.
            });
            // Setup slot ID dropdown
            var slotIdDropdown = root.Q<DropdownField>("SlotIdDropdown");

            // Add 'Create New Expression' as an initial option
            expressionDropdown.choices = new List<string> { "Create New Expression" };
            expressionDropdown.value = "Create New Expression";
            slotIdDropdown.RegisterValueChangedCallback(evt => {
                    slotIndex = slotIdDropdown.index;
                    if (slotIds != null && slotIds.Length > 0)
                    {
                        slotId = slotIds[slotIndex];
                        UpdateExpressionDropdown(expressionDropdown, slotId);
                    }
                });

            // Set up the ObjectField for Texture2D
            var textureField = root.Q<ObjectField>("TextureSelector");
            textureField.objectType = typeof(Texture2D);
            textureField.RegisterValueChangedCallback(evt =>
            {
                image = evt.newValue as Texture2D;
            });


            // Setup max supply input
            var maxSupplyInput = root.Q<IntegerField>("MaxSupplyInput");
            maxSupplyInput.value = maximum.HasValue ? maximum.Value : 0;
            maxSupplyInput.RegisterValueChangedCallback(evt => maximum = evt.newValue);

            if (noMax)
            {
                maxSupplyInput.SetEnabled(false);
            }

            var mintImmediatelyInput = rootVisualElement.Q<IntegerField>("MintNow");
            mintImmediatelyInput.value = mintImmediately;
            mintImmediatelyInput.RegisterValueChangedCallback(evt => mintImmediately = evt.newValue);


            // Setup no max supply toggle
            var noMaxSupplyToggle = root.Q<Toggle>("NoMaxSupplyToggle");
            noMaxSupplyToggle.RegisterValueChangedCallback(evt => {
                if (evt.newValue)
                {
                    maxSupplyInput.SetEnabled(false);
                    savedMax = (int) maximum;
                    maximum = null;
                    maxSupplyInput.value = 0;
                    maxSupplyInput.SetEnabled(false);
                    noMax = true;
                }
                else
                {
                    maxSupplyInput.SetEnabled(true);
                    maximum = savedMax;
                    maxSupplyInput.value = savedMax;
                    maxSupplyInput.SetEnabled(true);
                    noMax = false;
                }
            });

            

            // Setup submit button
            var submitButton = root.Q<Button>("SubmitButton");
            submitButton.clickable.clicked += () => {
                submitButton.SetEnabled(false);
                // Your submit logic here
                CreateBundleFromSelection(slotId, maximum.HasValue ? maximum.Value : 0, collectionName, expressionId != "Create New Expression" ? expressionId : "");
            };
        }

        async void UpdateExpressionDropdown(DropdownField expressionDropdown, string selectedSlotId)
        {
            List<string> expressions;
            try
            {
                ApiManager manager = new ApiManager();
                expressions = await manager.GetAssetExpressions(selectedSlotId);
                expressions.Add("Create New Expression");
                expressionDropdown.choices = expressions;
                expressionDropdown.value = expressions.FirstOrDefault(); // Set the first item as selected by default
            } catch(Exception ex)
            {
                Debug.Log("failure reading expression Ids of slot: " + ex.Message);
            }

            expressionId = expressionDropdown.value; // Update class variable
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


        /* void OnGUI()
        {
            if (isCreatingCollection || !string.IsNullOrEmpty(successMessage))
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
                GUILayout.Label("Create Asset Bundle", EditorStyles.boldLabel);

                if (slotNames != null) // Change from slotIds to slotNames
                {
                    slotIndex = EditorGUILayout.Popup("Slot Name", slotIndex, slotNames);
                    slotId = slotIds[slotIndex];
                }

                collectionName = EditorGUILayout.TextField("Collection Name", collectionName);
                maximum = EditorGUILayout.IntField("Max�mum", maximum.Value);
                mintImmediately = EditorGUILayout.IntField("Mint Immediately", mintImmediately);

                image = (Texture2D)EditorGUILayout.ObjectField("Image", image, typeof(Texture2D), false);

                if (GUILayout.Button("Create Bundle"))
                {
                    isCreatingCollection = true;
                    EnsureAssetBundleDatabaseExists();
                    CreateBundleFromSelection(slotId, maximum.Value, collectionName);
                }
            }
        } */

        BuildTarget GetBuildTarget(BuildPlatform platform)
        {
            switch (platform)
            {
                case BuildPlatform.iOS:
                    return BuildTarget.iOS;
                case BuildPlatform.Android:
                    return BuildTarget.Android;
                case BuildPlatform.StandaloneWindows:
                    return BuildTarget.StandaloneWindows64; // Or StandaloneWindows depending on your needs.
                case BuildPlatform.StandaloneOSX:
                    return BuildTarget.StandaloneOSX;
                case BuildPlatform.WebGL:
                    return BuildTarget.WebGL;
                default:
                    throw new ArgumentException("Invalid platform specified.");
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




        private void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        async Task CreateBundleFromSelection(string slotId, int maxSupply, string collectionName, string expressionId)
        {
            bool wasScene = Selection.activeObject is SceneAsset;
            bool wasPrefab = Selection.activeObject is GameObject;
            UnityEngine.Object[] selectedObjects = Selection.objects;

            // Ensure that some assets are selected.
            if (selectedObjects.Length == 0)
            {
                UnityEngine.Debug.Log("No assets selected for bundling");
                return;
            }

            // Ensure that a single GameObject is selected if it's not a SceneAsset.
            if (selectedObjects.Length != 1)
            {
                Debug.LogError("Please select a single GameObject or scene for asset bundling.");
                return;
            }

            GameObject selectedGameObject = wasScene ? null : selectedObjects[0] as GameObject;
            UnityEngine.Object selectedObject = selectedObjects[0];
            // Ensure the bundle save path exists.
            string fullPath = Path.Combine(Application.dataPath, BUNDLEPATH);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }


            // Set the bundle name to the first selected object's name.
            string bundleName = selectedObject.name.ToLower();


            string assetPath = AssetDatabase.GetAssetPath(selectedObject);
            AssetImporter.GetAtPath(assetPath).SetAssetBundleNameAndVariant(bundleName, "");

            // Refresh the AssetDatabase after setting the asset bundle names.
            AssetDatabase.Refresh();

            // Prepare to build only the specified AssetBundle
            AssetBundleBuild[] buildMap = new AssetBundleBuild[1];
            buildMap[0].assetBundleName = bundleName;
            buildMap[0].assetNames = new string[] { assetPath };
            ApiManager sdkInstance = new ApiManager();




            // Output log
            UnityEngine.Debug.Log("AssetBundle Created: " + bundleName);
            string imageUrl = "";

            // If no image is selected and the first selected asset is a scene or a prefab, capture a preview image
            if (image == null && (wasScene || wasPrefab))
            {
                string imagePath = "";

                if (wasScene)
                {
                    imagePath = ScenePreviewCapturer.CaptureScenePreview(assetPath, fieldOfView);
                }
                else if (wasPrefab)
                {
                    imagePath = await PrefabPreviewCapturer.CapturePrefabPreview(assetPath, fieldOfViewPrefab);
                }

                if (!string.IsNullOrEmpty(imagePath))
                {
                    byte[] bytes = File.ReadAllBytes(imagePath);
                    Texture2D tex = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                    if (tex.LoadImage(bytes))
                    {
                        tex.filterMode = FilterMode.Bilinear;
                        tex.wrapMode = TextureWrapMode.Clamp;
                        image = tex;
                    }
                    else
                    {
                        Debug.LogError("Failed to load image data into texture");
                    }
                }
            }
            // If an image is selected, convert it to a data URL and print it to the console.
            if (image != null)
            {
                Texture2D readableImage = MakeTextureReadable(image);
                imageUrl = ImageToDataUrlResized(readableImage);
                Debug.Log("Image Data URL: " + imageUrl);
            }

            string collectionId = await sdkInstance.CreateCollection(slotId, collectionName, noMax ? null : maxSupply, imageUrl);
            if (collectionId != null)
            {
                if (selectedGameObject != null)
                {
                    SavePrefab(selectedGameObject, slotId, collectionId, collectionName);
                    try
                    {
                        await ReferencedScriptsFinder.AddScriptsToSlot(selectedGameObject, slotId);
                    }
                    catch (Exception e)
                    {
                        Debug.Log("script uploading failed due to : " + e.Message);
                    }
                }
                Debug.Log("Collection created successfully!");
                
                if (string.IsNullOrEmpty(expressionId))
                {
                    // If no existing expression found, create a new one
                    string expressionTypeId = "64b1ce76716b83c3de7df84e";
                    string expressionName = "AssetBundle";
                    expressionId = await sdkInstance.CreateExpression(slotId, expressionTypeId, expressionName, "Assetbundle Expression");

                    if (string.IsNullOrEmpty(expressionId))
                    {
                        Debug.Log("Failed to create expression.");
                        return;
                    }
                }

                foreach (BuildPlatform platform in Enum.GetValues(typeof(BuildPlatform)))
                {
                    BuildTarget buildTarget = GetBuildTarget(platform);
                    BuildPipeline.BuildAssetBundles(fullPath, buildMap, BuildAssetBundleOptions.ChunkBasedCompression, buildTarget);


                    string platformName = platform.ToString();
                    // Move and get the dataUrl for the bundle
                    string bundlePath = MoveAssetBundles(bundleName);
                    string dataUrl = BundleToDataUrl(bundlePath);
                    await sdkInstance.UploadBundleExpression(collectionId, dataUrl, "AssetBundle" + platformName, "AssetBundle", expressionId);

                }
                if (selectedGameObject != null)
                {
                    try
                    {
                        string location = PrefabPacker.PackagePrefab(selectedGameObject, slotId);
                        string unityPackageDataUrl = BundleToDataUrl(location);

                        await sdkInstance.UploadBundleExpression(collectionId, unityPackageDataUrl, "UnityPackage", "AssetBundle", expressionId);
                    } catch(Exception e)
                    {
                        Debug.Log("unity package saving failed: " + e.Message);
                    }
                }
                


                string menuViewExpressionId = await sdkInstance.GetMenuViewExpression(slotId);

                bool menuViewSuccess = await sdkInstance.UploadBundleExpression(collectionId, imageUrl, "Image", "Menu View");


                bool mintSuccess = true;
                // Call MintNFT function after the upload.
                if (mintImmediately > 0)
                {
                    mintSuccess = await sdkInstance.Mint(collectionId, mintImmediately);
                }
              
                if (mintSuccess)
                {
                    successMessage = "Collection and AssetBundle created and uploaded successfully!";
                    ShowSuccessUI();
                    Repaint();
                }
                else
                {
                    Debug.Log("Failed to mint NFT.");
                }

            }
            else
            {
                Debug.Log("Failed to create collection.");
            }


            AssetImporter.GetAtPath(assetPath).SetAssetBundleNameAndVariant("", "");

            // Refresh the AssetDatabase after removing the asset bundle names.
            AssetDatabase.Refresh();

            
            
        }


        public string MoveAssetBundles(string bundleName)
        {
            // Convert the relative bundle path to an absolute path
            string absoluteBundlePath = Path.Combine(Application.dataPath, BUNDLEPATH);

            // Create a new directory for the bundle and its manifest.
            string bundleDirectoryPath = Path.Combine(absoluteBundlePath, bundleName + "_dir");

            // Check if directory exists, delete and recreate if it does.
            if (Directory.Exists(bundleDirectoryPath))
            {
                Directory.Delete(bundleDirectoryPath, true);
            }
            Directory.CreateDirectory(bundleDirectoryPath);

            string bundlePath = Path.Combine(absoluteBundlePath, bundleName);
            string bundleManifestPath = Path.Combine(absoluteBundlePath, bundleName + ".manifest");
            string targetBundlePath = Path.Combine(bundleDirectoryPath, bundleName + ".bundle");
            string targetBundleManifestPath = Path.Combine(bundleDirectoryPath, bundleName + ".bundle.manifest");

            // Check if bundle file exists, delete it if it does.
            if (File.Exists(targetBundlePath))
            {
                File.Delete(targetBundlePath);
            }

            // Check if bundle manifest file exists, delete it if it does.
            if (File.Exists(targetBundleManifestPath))
            {
                File.Delete(targetBundleManifestPath);
            }

            // Move the AssetBundle and its manifest file to the new directory with .bundle extension.
            File.Move(bundlePath, targetBundlePath);
            File.Move(bundleManifestPath, targetBundleManifestPath);

            return targetBundlePath;
        }



        Texture2D MakeTextureReadable(Texture2D originalTexture)
        {
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
            // Create a new Texture2D of size 500x500
            Texture2D resizedImage = new Texture2D(500, 500);

            // Use RenderTexture to render the source image into the new size
            RenderTexture rt = RenderTexture.GetTemporary(500, 500);
            RenderTexture.active = rt;

            // Copy the source image into the RenderTexture
            Graphics.Blit(image, rt);

            // Read the RenderTexture into the new Texture2D
            resizedImage.ReadPixels(new Rect(0, 0, 500, 500), 0, 0);
            resizedImage.Apply();

            // Release the RenderTexture to free up memory
            RenderTexture.active = null;
            rt.Release();

            // Convert the resized image to a data URL
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
