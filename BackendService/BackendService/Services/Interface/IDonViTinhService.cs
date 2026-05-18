using BackendService.Core.DTOs.Product.Responses;

namespace BackendService.Services.Interface
{
    public interface IDonViTinhService
    {
        Task<GetListDonViTinhResponseDto[]> GetAllAsync(CancellationToken cancellationToken);
    }
}
