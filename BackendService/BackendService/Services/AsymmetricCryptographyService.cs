using System;
using System.Security.Cryptography;
using System.Text;
using BackendService.Services.Interface;

namespace BackendService.Services
{
    public class AsymmetricCryptographyService : IAsymmetricCryptographyService
    {
        public (string PublicKey, string PrivateKey) GenerateKeyPair()
        {
            using (var rsa = RSA.Create(2048))
            {
                var publicKey = rsa.ExportSubjectPublicKeyInfoPem();
                var privateKey = rsa.ExportPkcs8PrivateKeyPem();
                return (publicKey, privateKey);
            }
        }

        public string Encrypt(string plainText, string publicKey)
        {
            try
            {
                using (var rsa = RSA.Create())
                {
                    rsa.ImportFromPem(publicKey.AsSpan());
                    var dataBytes = Encoding.UTF8.GetBytes(plainText);
                    var encryptedBytes = rsa.Encrypt(dataBytes, RSAEncryptionPadding.OaepSHA256);
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Encryption failed: {ex.Message}", ex);
            }
        }

        public string Decrypt(string cipherText, string privateKey)
        {
            try
            {
                using (var rsa = RSA.Create())
                {
                    rsa.ImportFromPem(privateKey.AsSpan());
                    var cipherBytes = Convert.FromBase64String(cipherText);
                    var decryptedBytes = rsa.Decrypt(cipherBytes, RSAEncryptionPadding.OaepSHA256);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Decryption failed: {ex.Message}", ex);
            }
        }

        public string SignData(string data, string privateKey)
        {
            try
            {
                using (var rsa = RSA.Create())
                {
                    rsa.ImportFromPem(privateKey.AsSpan());
                    var dataBytes = Encoding.UTF8.GetBytes(data);
                    var signatureBytes = rsa.SignData(dataBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    return Convert.ToBase64String(signatureBytes);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Signing failed: {ex.Message}", ex);
            }
        }

        public bool VerifySignature(string data, string signature, string publicKey)
        {
            try
            {
                using (var rsa = RSA.Create())
                {
                    rsa.ImportFromPem(publicKey.AsSpan());
                    var dataBytes = Encoding.UTF8.GetBytes(data);
                    var signatureBytes = Convert.FromBase64String(signature);
                    return rsa.VerifyData(dataBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Signature verification failed: {ex.Message}", ex);
            }
        }
    }
}
