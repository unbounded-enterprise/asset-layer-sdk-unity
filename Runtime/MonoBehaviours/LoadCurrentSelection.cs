using UnityEngine;

namespace AssetLayer.Unity
{
    public class LoadCurrentSelection : MonoBehaviour
    {
        private string SelectionSaveKey = "AssetLayerSelectedAssetId";
        // this is the key the AssetBundleImporter saves the last loaded asset to, 
        // if you change this you need to setup the saving of the current selected assetId yourself.

        public GameObject defaultModel; // Default model that will be activated if no asset ID is found.

        /* 
         * This Script needs to be on a GameObject that has an AssetBundleImporter 
         * (like the AssetLayerGameObejct prefab) and loads it with the assetId 
         * that was saved in the PlayerPrefs.
         * The AssetBundleImporter sets the needed PlayerPref Attribute on each change of the Asset it imports.
         * it also calls the Loading Method on the LoadCurrentSelection Script after having fetched the users account data.
         */
        private void Start()
        {
            Inventory inventoryComponent = FindObjectOfType<Inventory>();
            if (inventoryComponent != null)
            {
                inventoryComponent.onUserIdFetched.AddListener(OnUserIdFetched);
            }
            else
            {
                Debug.LogWarning("LoadCurrentSelection: Inventory component not found in the scene.");
            }
        }

        private void OnUserIdFetched(string userId)
        {
            // Optionally, you can check the userId here before calling Loading.
            Loading(userId);
        }

        public void Loading(string userId)
        {

            if (!string.IsNullOrEmpty(userId))
            {
                SelectionSaveKey = "AssetLayerSelectedAssetId" + userId;
            } else
            {
                return;
            }

            AssetBundleImporter importer = GetComponent<AssetBundleImporter>();
            string loadedAssetId = PlayerPrefs.GetString(SelectionSaveKey);

            // Check if asset ID is not empty and load it, otherwise activate default model if present.
            if (!string.IsNullOrEmpty(loadedAssetId))
            {
                importer.SetNftId(loadedAssetId);
            }
            else
            {
                if (defaultModel != null)
                {
                    defaultModel.SetActive(true);
                }
            }
        }

        // Update is called once per frame.
        void Update()
        {

        }
    }
}
