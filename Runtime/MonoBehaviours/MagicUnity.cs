using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_WEBGL
#else
using MagicSDK;
#endif
using UnityEngine;

public class MagicUnity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_WEBGL
    // not using magic for webgl
#else
        Magic magic = new Magic("pk_live_8FB965353AF0A346");
        Magic.Instance = magic;
#endif
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
