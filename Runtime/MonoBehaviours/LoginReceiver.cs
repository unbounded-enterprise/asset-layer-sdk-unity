using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System;
using PimDeWitte.UnityMainThreadDispatcher;
using Newtonsoft.Json.Linq;
using System.Collections;



namespace AssetLayer.Unity
{
    public class LoginReceiver : MonoBehaviour
    {
        public string SceneToLoadOnLogin;
        public bool loginReady = false;
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
        private HttpServer httpServer;


        void Start()
        {
            string savedDidToken = SecurePlayerPrefs.GetSecureString("didtoken");
            // InvApiManager manager = new ApiManager();
            try
            {
                bool tokenIsValid = IsDIDTokenValid(savedDidToken);
                if (!tokenIsValid)
                {
                    SecurePlayerPrefs.RemoveSecureString("didtoken");
                    savedDidToken = null;
                }
            }
            catch (Exception ex)
            {
                Debug.Log("token no longer valid");
                SecurePlayerPrefs.RemoveSecureString("didtoken");
                savedDidToken = null;
            }
            if (string.IsNullOrEmpty(savedDidToken) || !IsDIDTokenValid(savedDidToken))
            {
                httpServer = new HttpServer();
                httpServer.onRequestReceived += HandleLoginReceived;
                httpServer.Start();
            }
            else
            {
                Debug.Log("did token is already there" + savedDidToken);
                loginReady = true;
                SetDIDToken(savedDidToken);
            }

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


        void OnDestroy()
        {
            if (httpServer != null)
            {
                httpServer.Stop();
            }
        }
        public void HandleLoginReceived(HttpListenerContext context)
        {
            string didToken = "";
            // Read query parameters
            try
            {
                didToken = context.Request.QueryString["token"];
            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
                return;
            }
            string responseText = "Message received";

            try
            {
                
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseText);

                var response = context.Response;
                response.ContentType = "text/plain";
                response.ContentLength64 = buffer.Length;

                if (didToken != null)
                {
                    UnityMainThreadDispatcher.Instance().Enqueue(() => SetDIDToken(didToken));
                }
                else
                {
                    Debug.Log("token is null");
                }

                var output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                output.Close();

            }
            catch (Exception ex)
            {
                Debug.Log("error sending a response" + ex.ToString());
            }
        }




#endif
        IEnumerator WaitForLogin()
        {
            yield return new WaitUntil(() => loginReady == true);
            // Load scene or do any other task once loginReady is true
            try
            {
                SceneManager.LoadScene(SceneToLoadOnLogin);
            }
            catch (Exception ex)
            {
                Debug.Log("loading scene wnet wrong" + ex.Message);
            }


        }

        public void SetDIDToken(string token)
        {

            SecurePlayerPrefs.SetSecureString("didtoken", token);
            loginReady = true;
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
            /* if (httpServer != null)
            {
                httpServer.Stop();
            } */
#endif
            // Load the desired scene after successful login but only after eventuell animations are done in the loading scene
            StartCoroutine(WaitForLogin());
        }


    }

}
