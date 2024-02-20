using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AssetLayer.Unity
{
    public class FinishLine : MonoBehaviour
    {
        public GameObject player;
        public TextMeshProUGUI winText;
        private bool playerPassedFinishLine = false;

        void Update()
        {
            if (player.transform.position.x > transform.position.x && !playerPassedFinishLine)
            {
                playerPassedFinishLine = true;
                winText.gameObject.SetActive(true);
                StartCoroutine(ScaleText(winText, 0f, 1f));
            }
            else if (player.transform.position.x <= transform.position.x && playerPassedFinishLine)
            {
                playerPassedFinishLine = false;
                StartCoroutine(ScaleText(winText, 1f, 0f));
            }
        }

        IEnumerator ScaleText(TextMeshProUGUI text, float startScale, float endScale)
        {
            float currentTime = 0f;
            float duration = 0.4f; // Animation duration in seconds

            while (currentTime < duration)
            {
                float scale = Mathf.Lerp(startScale, endScale, currentTime / duration);
                text.transform.localScale = new Vector3(scale, scale, scale);
                currentTime += Time.deltaTime;
                yield return null;
            }

            text.transform.localScale = new Vector3(endScale, endScale, endScale);

            if (endScale == 0f)
            {
                text.gameObject.SetActive(false);
            }
        }
    }
}
