namespace BackendService.Services.Interface
{
    public interface IOtherService
    {
        public string GenerateRandomCode();
        public string GenerateResetPasswordCode();
    }
}
