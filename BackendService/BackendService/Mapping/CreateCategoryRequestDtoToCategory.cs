using BackendService.Core.DTOs.Category.Requests;
using BackendService.Model.Common;

namespace BackendService.Mapping
{
    public static class CreateCategoryRequestDtoToCategory
    {
        public static Category Transform(CreateCategoryRequestDto dto)
        {
            return new Category
            {
                Id = Guid.NewGuid(),
                TenDanhMuc = dto.TenDanhMuc,
                Description = dto.Description,
                ParentId = dto.ParentId,
                CreatedTime = DateTime.UtcNow,
                UpdatedTime = DateTime.UtcNow,
                DeleteFlag = false
            };
        }
    }
}
