using BackendService.Core.DTOs.Category.Requests;
using BackendService.Core.DTOs.Category.Responses;

namespace BackendService.Services.Interface
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDto>> GetAllAsync(string? keyword, CancellationToken cancellationToken);
        Task<CategoryResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(CreateCategoryRequestDto request, CancellationToken cancellationToken);
        Task UpdateAsync(UpdateCategoryRequestDto request, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
