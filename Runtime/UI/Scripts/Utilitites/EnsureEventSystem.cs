using UnityEngine;
using UnityEngine.EventSystems;

namespace AssetLayer
{
    public class EnsureEventSystem : MonoBehaviour
    {
        void Awake()
        {
            if (FindObjectOfType<EventSystem>() == null)
            {
                // Create a new Event System and add it to the scene
                new GameObject("Event this System", typeof(EventSystem), typeof(StandaloneInputModule));
            }
        }
    }
}

