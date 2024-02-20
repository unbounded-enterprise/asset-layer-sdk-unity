using AssetLayer.SDK.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace AssetLayer.Unity
{
    public class SyncAssetPrefabs : EditorWindow
    {

        private static string[] slotIds;
        private static  ApiManager manager;

        private static bool isFinished = false;

        [MenuItem("Assets/Asset Layer/Sync/Download Packages for All Collections")]
        public static void SyncAssetsMenuOption()
        {
            ImportAssetBundles(false);
        }

        [InitializeOnLoadMethod]
        private static void InitializeOnLoad()
        {
            ImportAssetBundles(true);
        }


        private static async Task<bool> DownloadAndSaveUnityPackage(string packageUrl, string slotId, string collectionName)
        {
            string unityPackageDirectoryPath = Path.Combine("Assets/AssetLayerUnitySDK/UnityPackages", slotId);
            string unityPackageFilePath = Path.Combine(unityPackageDirectoryPath, $"{collectionName}.unitypackage");

            // Create the directory if it doesn't exist
            if (!Directory.Exists(unityPackageDirectoryPath))
            {
                Directory.CreateDirectory(unityPackageDirectoryPath);
                AssetDatabase.Refresh();
            }

            Debug.Log($"Attempting to download UnityPackage: {packageUrl}");

            using (UnityWebRequest request = UnityWebRequest.Get(packageUrl))
            {
                // Send request and await its completion
                await request.SendWebRequest();

                // Check for network errors
                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Error while downloading UnityPackage: {request.error}");
                    return false;
                }

                try
                {
                    File.WriteAllBytes(unityPackageFilePath, request.downloadHandler.data);
                    Debug.Log($"UnityPackage saved to: {unityPackageFilePath}");
                    return true;
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to save UnityPackage. Exception: {e.Message}");
                    return false;
                }
            }
        }


        private static async void ImportAssetBundles(bool skipExistingFolders = false)
        {
            if (!Directory.Exists("Assets/AssetLayerUnitySDK"))
            {
                Debug.LogWarning("AssetLayerUnitySDK directory not found. Skipping ImportAssetBundles process.");
                return;
            }
            isFinished = false;
            manager = new ApiManager(); // Assuming this is your class for managing API calls
            if (string.IsNullOrEmpty(manager.APP_SECRET))
            {
                return;
            }
            if (slotIds == null)
            {
                slotIds = await manager.GetAppSlots();
            }

            if (slotIds != null)
            {
                List<Collection> allCollections = new List<Collection>();
                foreach (var currentSlotId in slotIds)
                {
                    List<Collection> collections = await manager.GetAllAssetsOfSlot(currentSlotId);
                    if (collections != null)
                    {
                        allCollections.AddRange(collections);
                    }
                }

                foreach (Collection collection in allCollections)
                {
                    string unityPackagePath = $"Assets/AssetLayerUnitySDK/UnityPackages/{collection.slotId}/{collection.collectionName}.unityPackage";
                    if (skipExistingFolders && File.Exists(unityPackagePath))
                    {
                        // Debug.Log($"Skipping download for {collection.collectionName} as it already exists at {unityPackagePath}.");
                        continue; // Correctly skips to the next iteration
                    }

                    string packageUrl = UtilityFunctions.GetExpressionValueByAttributeId(collection.exampleExpressionValues, "65aec64e8cbc424457ff1c0e");
                    if (packageUrl == null)
                    {
                        continue;
                    }
                    try
                    {
                        bool success = await DownloadAndSaveUnityPackage(packageUrl, collection.slotId, collection.collectionName);
                        if (!success)
                        {
                            Debug.LogError("Failed to download and save UnityPackage.");
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogError($"Failed to process UnityPackage from {packageUrl}. Exception: {e}");
                    }
                    finally
                    {
                        await Task.Yield(); // Yield control to allow GUI update
                    }
                }
            }
            else
            {
                Debug.Log("Failed to load slot IDs from AssetLayer");
            }

            isFinished = true;
            AssetDatabase.Refresh();
        }


    }
}
