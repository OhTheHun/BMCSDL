using BackendService.Services.Interface;

namespace BackendService.Services
{
    public class OtherService : IOtherService
    {
        public string GenerateRandomCode()
        {
            string prefix = "HD";
            string datePart = DateTime.Now.ToString("yyyyMMdd");
            string randomPart = Guid.NewGuid()
                                    .ToString("N")
                                    .Substring(0, 6)
                                    .ToUpper();
            return $"{prefix}{datePart}{randomPart}";
        }

        public string GenerateResetPasswordCode()
        {
            return new Random().Next(100000, 999999).ToString();
        }
    }
}