using BackendService.Core.DTOs.Category.Requests;
using BackendService.Core.DTOs.Category.Responses;
using BackendService.Data.Interface;
using BackendService.Mapping;
using BackendService.Services.Interface;

namespace BackendService.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<List<CategoryResponseDto>> GetAllAsync(string? keyword, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync(keyword, cancellationToken);
            return CategoryToCategoryResponseDto.Transform(categories);
        }

        public async Task<CategoryResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(id, cancellationToken);
            return category == null ? null : CategoryToCategoryResponseDto.Transform(category);
        }

        public async Task CreateAsync(CreateCategoryRequestDto request, CancellationToken cancellationToken)
        {
            var category = CreateCategoryRequestDtoToCategory.Transform(request);
            await _categoryRepository.AddAsync(category, cancellationToken);
        }

        public async Task UpdateAsync(UpdateCategoryRequestDto request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (category != null)
            {
                category.TenDanhMuc = request.TenDanhMuc;
                category.Description = request.Description;
                category.ParentId = request.ParentId;
                category.UpdatedTime = DateTime.UtcNow;

                await _categoryRepository.UpdateAsync(category, cancellationToken);
            }
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteAsync(id, cancellationToken);
        }
    }
}
