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

            // Handle UI elements based on the current platform
            if (Application.platform == RuntimePlatform.WindowsEditor ||
                Application.platform == RuntimePlatform.WindowsPlayer ||
                Application.platform == RuntimePlatform.OSXPlayer)
            {
                // Only show the loginButton and header

                canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
                awaitingLogin.SetActive(false);
                callToAction.SetActive(false);
                loginButton.gameObject.SetActive(true);
                emailInput.SetActive(false);
                opensInBrowser.SetActive(true);
            }
            else if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
                // Hide everything but the header
                callToAction.SetActive(false);
                awaitingLogin.SetActive(true);
                loginButton.gameObject.SetActive(false);
                emailInput.SetActive(false);
                opensInBrowser.SetActive(false);
            }
            else if (Application.platform == RuntimePlatform.Android ||
                     Application.platform == RuntimePlatform.IPhonePlayer)
            {
                // Show everything
                awaitingLogin.SetActive(false);
                callToAction.SetActive(true);
                loginButton.gameObject.SetActive(true);
                emailInput.SetActive(true);
                opensInBrowser.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Your logic here
        }
    }

}