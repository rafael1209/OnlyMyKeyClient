﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using OnlyMyKeyClient.Infrastructure.Storage;

namespace OnlyMyKeyClient.Infrastructure.Security
{
    public static class EncryptionHelper
    {
        private static readonly string Key = TokenStorage.TryLoadToken("key");
        private static readonly string Iv = TokenStorage.TryLoadToken("iv");

        public static string Encrypt(string plainText)
        {
            if (Key.Length != 16 && Key.Length != 24 && Key.Length != 32)
                throw new ArgumentException("Key size must be 16, 24, or 32 characters for AES.");

            if (Iv.Length != 16)
                throw new ArgumentException("IV size must be 16 characters for AES.");

            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(Iv);

            using var msEncrypt = new MemoryStream();
            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using var swEncrypt = new StreamWriter(csEncrypt);

            swEncrypt.Write(plainText);
            swEncrypt.Flush();
            csEncrypt.FlushFinalBlock();

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public static string Decrypt(string cipherText)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(Iv);

            var decrypt = aes.CreateDecryptor(aes.Key, aes.IV);

            using var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText));
            using var csDecrypt = new CryptoStream(msDecrypt, decrypt, CryptoStreamMode.Read);
            using var srDecrypt = new StreamReader(csDecrypt);
            return srDecrypt.ReadToEnd();
        }

        public static string GenerateKey()
        {
            byte[] keyBytes = new byte[12];
            RandomNumberGenerator.Fill(keyBytes);
            string base64Key = Convert.ToBase64String(keyBytes);
            return base64Key.Substring(0, 16);
        }
    }
}
