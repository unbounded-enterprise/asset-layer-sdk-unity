using TMPro;
using UnityEngine;
using UnityEngine.UI; // Don't forget to include this to access Button and Text classes

namespace AssetLayer.Unity
{
    public class LoginDisplayLogic : MonoBehaviour
    {
        public Button loginButton;
        public GameObject emailInput;
        public GameObject opensInBrowser;
        public GameObject errorMessage;
        public GameObject callToAction;
        public GameObject awaitingLogin;

        private CanvasScaler canvasScaler;

        // Start is called before the first frame update
        void Start()
        {
            canvasScaler = GetComponent<CanvasScaler>();

            // Make sure canvasScaler is not null before using it
            if (canvasScaler != null)
            {
                // Handle UI elements based on the current platform
                if (!Application.platform == RuntimePlatform.WebGLPlayer)
                {
                    canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
                    SafeSetActive(awaitingLogin, false);
                    SafeSetActive(callToAction, false);
                    SafeSetActive(loginButton?.gameObject, true);
                    SafeSetActive(emailInput, false);
                    SafeSetActive(opensInBrowser, true);
                }
                else if (Application.platform == RuntimePlatform.WebGLPlayer)
                {
                    canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
                    SafeSetActive(callToAction, false);
                    SafeSetActive(awaitingLogin, true);
                    SafeSetActive(loginButton?.gameObject, false);
                    SafeSetActive(emailInput, false);
                    SafeSetActive(opensInBrowser, false);
                }
                else
                {
                    SafeSetActive(awaitingLogin, false);
                    SafeSetActive(callToAction, true);
                    SafeSetActive(loginButton?.gameObject, true);
                    SafeSetActive(emailInput, true);
                    SafeSetActive(opensInBrowser, false);
                }
            }
        }


        // Helper method to safely activate/deactivate game objects
        void SafeSetActive(GameObject obj, bool active)
        {
            if (obj != null)
            {
                obj.SetActive(active);
            }
        }
    }
}
