namespace BackendService.Services.Interface
{
    public interface IAsymmetricCryptographyService
    {
        (string PublicKey, string PrivateKey) GenerateKeyPair();
        string Encrypt(string plainText, string publicKey);
        string Decrypt(string cipherText, string privateKey);
        string SignData(string data, string privateKey);
        bool VerifySignature(string data, string signature, string publicKey);
    }
}
