#if UNITY_EDITOR
using System;
using System.IO;
using System.Security.Cryptography;
using UnityEditor;

public static class EncryptionUtils
{
    public static string Encrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText))
            return "";

        byte[] key = SecretGenerator.GetSecret();
        byte[] iv = new byte[16];
        byte[] encrypted;

        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }
                }

                encrypted = memoryStream.ToArray();
            }
        }

        return Convert.ToBase64String(encrypted);
    }

    public static string Decrypt(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText))
            return "";

        byte[] key = SecretGenerator.GetSecret();
        byte[] iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(cipherText);
        string plaintext = null;

        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader(cryptoStream))
                    {
                        plaintext = streamReader.ReadToEnd();
                    }
                }
            }
        }

        return plaintext;
    }
}
#endif
