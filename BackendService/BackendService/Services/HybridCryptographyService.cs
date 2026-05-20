using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using BackendService.Configuration;
using BackendService.Services.Interface;
using Microsoft.Extensions.Options;

namespace BackendService.Services
{
    public class HybridCryptographyService : IHybridCryptographyService
    {
        private readonly ConfigOptions _configOptions;

        public HybridCryptographyService(IOptions<ConfigOptions> options)
        {
            _configOptions = options.Value;
        }

        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return plainText;

            try
            {
                using (var aes = Aes.Create())
                {
                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.GenerateKey();
                    aes.GenerateIV();

                    // 1. Mã hóa dữ liệu bằng khóa đối xứng AES
                    byte[] cipherBytes;
                    using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                            cs.Write(plainBytes, 0, plainBytes.Length);
                            cs.FlushFinalBlock();
                        }
                        cipherBytes = ms.ToArray();
                    }

                    string base64CipherText = Convert.ToBase64String(cipherBytes);
                    string base64IV = Convert.ToBase64String(aes.IV);

                    // 2. Mã hóa khóa đối xứng AES bằng khóa công khai RSA
                    string base64EncryptedAESKey;
                    using (var rsa = RSA.Create())
                    {
                        rsa.ImportFromPem(_configOptions.AsymmetricKeys.PublicKey.AsSpan());
                        byte[] encryptedAESKeyBytes = rsa.Encrypt(aes.Key, RSAEncryptionPadding.OaepSHA256);
                        base64EncryptedAESKey = Convert.ToBase64String(encryptedAESKeyBytes);
                    }

                    // 3. Kết hợp các phần tử thành chuỗi payload mã hóa lai dạng base64EncKey:base64IV:base64CipherText
                    return $"{base64EncryptedAESKey}:{base64IV}:{base64CipherText}";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Hybrid encryption failed: {ex.Message}", ex);
            }
        }

        public string Decrypt(string cipherTextPayload)
        {
            if (string.IsNullOrEmpty(cipherTextPayload))
                return cipherTextPayload;

            // Nếu payload không chứa dấu hai chấm ':' ngăn cách, có thể đó là dữ liệu chưa mã hóa (mã cũ)
            string[] parts = cipherTextPayload.Split(':');
            if (parts.Length != 3)
            {
                return cipherTextPayload;
            }

            try
            {
                string base64EncryptedAESKey = parts[0];
                string base64IV = parts[1];
                string base64CipherText = parts[2];

                byte[] encryptedAESKeyBytes = Convert.FromBase64String(base64EncryptedAESKey);
                byte[] ivBytes = Convert.FromBase64String(base64IV);
                byte[] cipherBytes = Convert.FromBase64String(base64CipherText);

                byte[] aesKeyBytes;
                // 1. Giải mã khóa đối xứng AES bằng khóa bí mật RSA
                using (var rsa = RSA.Create())
                {
                    rsa.ImportFromPem(_configOptions.AsymmetricKeys.PrivateKey.AsSpan());
                    aesKeyBytes = rsa.Decrypt(encryptedAESKeyBytes, RSAEncryptionPadding.OaepSHA256);
                }

                // 2. Giải mã dữ liệu chính bằng khóa AES và IV đã giải mã
                using (var aes = Aes.Create())
                {
                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var decryptor = aes.CreateDecryptor(aesKeyBytes, ivBytes))
                    using (var ms = new MemoryStream(cipherBytes))
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var sr = new StreamReader(cs, Encoding.UTF8))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                // Fallback: nếu lỗi giải mã, có thể đây là dữ liệu cũ chưa mã hóa, trả về giá trị ban đầu
                return cipherTextPayload;
            }
        }
    }
}
