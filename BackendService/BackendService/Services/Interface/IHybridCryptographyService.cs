namespace BackendService.Services.Interface
    {
        public interface IHybridCryptographyService
        {
            string Encrypt(string plainText);
            string Decrypt(string cipherTextPayload);
        }
    }
    
