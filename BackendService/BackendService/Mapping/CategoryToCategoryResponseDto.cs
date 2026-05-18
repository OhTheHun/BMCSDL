using BackendService.Core.DTOs.Category.Responses;
using BackendService.Model.Common;

namespace BackendService.Mapping
{
    public static class CategoryToCategoryResponseDto
    {
        public static CategoryResponseDto Transform(Category category)
        {
            return new CategoryResponseDto
            {
                Id = category.Id,
                TenDanhMuc = category.TenDanhMuc,
                Description = category.Description,
                ParentId = category.ParentId
            };
        }

        public static List<CategoryResponseDto> Transform(List<Category> categories)
        {
            return categories.Select(Transform).ToList();
        }
    }
}
