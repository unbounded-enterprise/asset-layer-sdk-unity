using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssetLayer.SDK.Apps;
using AssetLayer.Unity;
#if UNITY_ANDROID || UNITY_IOS || UNITY_STANDALONE
using MagicSDK;
#endif
using Newtonsoft.Json.Linq;

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AssetLayer.Unity
{

        public class AssetLayerMagicUnityButton : MonoBehaviour
    {
        private string email;
        private Button buttonComponent;
        private bool showLoading = false;
        public GameObject loadingIndicator;
        public TextMeshProUGUI errorMessage = null;

        public LoginReceiver loginReceiver = null;
        // Start is called before the first frame update
        void Start()
        {
            buttonComponent = GetComponent<Button>();
#if UNITY_WEBGL
                // Disable the GameObject if we are running in WebGL
                gameObject.SetActive(false);
#endif

#if !UNITY_ANDROID && !UNITY_IOS && !UNITY_STANDALONE
                // Show the button only if it's not running on Android or iOS
                ShowButton(true);
#elif UNITY_ANDROID || UNITY_IOS || UNITY_STANDALONE
            CheckCurrentToken();
            ShowButton(false);
#else
            ShowButton(false);
#endif
        }

        private void ShowButton(bool show)
        {
            if (buttonComponent)
            {
                buttonComponent.interactable = show;
            }
        }


        private void CheckCurrentToken()
        {
            if (IsDIDTokenValid(SecurePlayerPrefs.GetSecureString("didtoken")))  // appslots != null)
            {

                // Load the desired scene after successful login
                SceneManager.LoadScene(loginReceiver.SceneToLoadOnLogin);
            }
            else
            {
                SecurePlayerPrefs.RemoveSecureString("didtoken");
            }
        }

        void OpenBrowser()
        {
            Debug.Log("Should open browser");
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
            Application.OpenURL(AppConfig.Instance.AssetLayerLoginUrl);
#endif
        }



        // Update is called once per frame
        void Update()
        {
        
        }

        public async void Login()
        {
            Debug.Log("login clicked");
            ShowButton(false);
            if (errorMessage != null)
            {
                errorMessage.gameObject.SetActive(false);
            }
            showLoading = true;
            buttonComponent.interactable = false;
            loadingIndicator.SetActive(true);
#if UNITY_ANDROID || UNITY_IOS || UNITY_STANDALONE
            // Android and iOS logic
            Debug.Log("Login..");
            Magic magic = Magic.Instance;

            try
            {
                if (magic == null)
                {
                    Debug.LogError("Magic failed to initialize");
                }
                var token = await magic.Auth.LoginWithEmailOtp(email);
                ApiManager manager = new ApiManager();
                string otp = await manager.GetOTP(token);
                var tokenWithAttachment = await magic.User.GenerateIdToken(3600000, otp);

                SecurePlayerPrefs.SetSecureString("didtoken", tokenWithAttachment);
                ApiManager.UserRegisterBody2 response = await manager.RegisterUser(otp);
                if (!string.IsNullOrEmpty(response.handle))
                {
                    Debug.Log("login successful");
                } else
                {
                    DisplayError("Login was unsuccessful");
                    Debug.Log("Error, removing login token: handle emtpy");
                    SecurePlayerPrefs.RemoveSecureString("didtoken");
                }
                /* string[] appslots = null;
                try
                {
                    
                    appslots  = await manager.GetAppSlots();
                } catch(Exception e)
                {
                    Debug.Log("Error, removing login token: " + e.Message);
                    SecurePlayerPrefs.RemoveSecureString("didtoken");
                    DisplayError("Login error");
                } */ 
                if (IsDIDTokenValid(tokenWithAttachment))  // appslots != null)
                {

                    // Load the desired scene after successful login
                    SceneManager.LoadScene(loginReceiver.SceneToLoadOnLogin);
                } else
                {
                    Debug.Log("Error, removing login token:  appslots null");
                    SecurePlayerPrefs.RemoveSecureString("didtoken");
                    DisplayError("Login failed");
                }
               
            }
            catch (Exception e)
            {
                Debug.Log("Error, removing login token: " + e.Message);
                SecurePlayerPrefs.RemoveSecureString("didtoken");
                DisplayError("Failed to login: " + e.Message);
            }
#else
                // Windows and macOS logic
                OpenBrowser();
#endif
        }

        public bool IsDIDTokenValid(string DIDToken)
        {
            if (string.IsNullOrEmpty(DIDToken))
            {
                return false;
            }
            try
            {
                // Decode Base64 string tuple to get 'proof' and 'claim'
                byte[] decodedBytes = Convert.FromBase64String(DIDToken);
                string decodedText = Encoding.UTF8.GetString(decodedBytes);
                JArray decodedJsonArray = JArray.Parse(decodedText);

                // Extract 'proof' and 'claim'
                string proof = decodedJsonArray[0].ToString();
                string claim = decodedJsonArray[1].ToString();

                // Parse 'claim' to JObject
                JObject claimObj = JObject.Parse(claim);

                // Check 'ext' (Expiration timestamp)
                long expirationTimestamp = claimObj["ext"].Value<long>();

                // Get current UTC time in seconds
                long currentTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                // Check if token is expired
                if (currentTimestamp > expirationTimestamp)
                {
                    Debug.Log("Token has expired.");
                    return false;
                }


                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred while validating the DID token: {ex.Message}");
                return false;
            }
        }



        private void DisplayError(string message)
        {
            Debug.Log("display error login: " + message);
            ShowButton(true);
            if (errorMessage != null)
            {
                
                errorMessage.text = message;
                errorMessage.gameObject.SetActive(true);
            }
        }

        public void SetEmail(string email)
        {
            if (UtilityFunctions.IsValidEmail(email))
            {
                this.email = email;
                ShowButton(true);
            }
            else
            {
                Debug.LogError("Not a valid email");
                ShowButton(false);
            }
        }
    }

}
