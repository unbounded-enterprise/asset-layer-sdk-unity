using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class ColorSpaceAutoSet
{
    static ColorSpaceAutoSet()
    {
        if (PlayerSettings.colorSpace != ColorSpace.Gamma)
        {
            PlayerSettings.colorSpace = ColorSpace.Gamma;
            Debug.Log("Color Space set to Gamma.");
        }
    }
}
