using UnityEngine;
using TMPro; // Required for TextMeshProUGUI

namespace AssetLayer.Unity
{
    public class CoinPickup : MonoBehaviour
    {
        private static int coinCount = 0; // Static variable for coin count
        private TextMeshProUGUI coinCountText; // TextMeshProUGUI object

        private void Start()
        {
            // Search and assign the TextMeshProUGUI object
            coinCountText = GameObject.Find("CoinCount").GetComponent<TextMeshProUGUI>();
            if (coinCountText == null)
            {
                Debug.LogError("TextMeshProUGUI object 'CoinCount' not found.");
                return;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    Debug.LogError("AudioSource component not found.");
                    return;
                }

                AudioClip pickupSound = audioSource.clip;
                if (pickupSound == null)
                {
                    Debug.LogError("No Audio clip found in the AudioSource.");
                    return;
                }

                audioSource.PlayOneShot(pickupSound);
                GetComponent<Collider>().enabled = false;
                GetComponent<Renderer>().enabled = false;

                Destroy(gameObject, pickupSound.length);

                // Update coin count and TextMeshProUGUI text
                coinCount++;
                coinCountText.text = "" + coinCount;
            }
        }
    }
}
