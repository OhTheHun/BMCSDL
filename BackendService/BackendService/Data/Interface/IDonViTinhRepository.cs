using BackendService.Model;

namespace BackendService.Data.Interface
{
    public interface IDonViTinhRepository
    {
        Task<DonViTinh[]> GetAllAsync(CancellationToken cancellationToken);
    }
}
