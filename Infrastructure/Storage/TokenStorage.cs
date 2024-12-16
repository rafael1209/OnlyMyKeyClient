using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlyMyKeyClient.Infrastructure.Storage
{
    public static class TokenStorage
    {
        public static void SaveToken(string authToken, string fileName)
        {
            var tokenFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "OnlyMyKey", $"{fileName}.dat");

            try
            {
                var encryptedData = ProtectedData.Protect(
                    System.Text.Encoding.UTF8.GetBytes(authToken),
                    null,
                    DataProtectionScope.CurrentUser);

                Directory.CreateDirectory(Path.GetDirectoryName(tokenFilePath));
                File.WriteAllBytes(tokenFilePath, encryptedData);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving token: " + ex.Message);
            }
        }

        public static string? TryLoadToken(string fileName)
        {
            var tokenFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "OnlyMyKey", $"{fileName}.dat");

            try
            {
                if (File.Exists(tokenFilePath))
                {
                    var encryptedData = File.ReadAllBytes(tokenFilePath);
                    var decryptedData = ProtectedData.Unprotect(
                        encryptedData,
                        null,
                        DataProtectionScope.CurrentUser);

                    return System.Text.Encoding.UTF8.GetString(decryptedData);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading token: " + ex.Message);
            }
        }

        public static void DeleteToken(string fileName)
        {
            var tokenFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "OnlyMyKey", $"{fileName}.dat");

            if (File.Exists(tokenFilePath))
            {
                File.Delete(tokenFilePath);
            }
        }
    }
}
