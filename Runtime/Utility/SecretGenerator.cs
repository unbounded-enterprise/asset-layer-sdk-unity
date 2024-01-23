#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public static class SecretGenerator
{
    private const string SecretKey = "EncryptionKey";
    private const int KeySize = 32; // 32 bytes for AES-256

    public static byte[] GetSecret()
    {
        string base64Secret = EditorPrefs.GetString(SecretKey, string.Empty);

        if (string.IsNullOrEmpty(base64Secret) || !IsValidBase64(base64Secret))
        {
            byte[] secret = GenerateSecret();
            base64Secret = System.Convert.ToBase64String(secret);
            EditorPrefs.SetString(SecretKey, base64Secret);
            Debug.Log("Generated and saved new secret.");
        }

        return System.Convert.FromBase64String(base64Secret);
    }

    private static byte[] GenerateSecret()
    {
        byte[] randomBytes = new byte[KeySize];
        using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
        {
            rng.GetBytes(randomBytes);
        }
        return randomBytes;
    }

    private static bool IsValidBase64(string base64String)
    {
        if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
           || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
            return false;

        try
        {
            System.Convert.FromBase64String(base64String);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
#endif
