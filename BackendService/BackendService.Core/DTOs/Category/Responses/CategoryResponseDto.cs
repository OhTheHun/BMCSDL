using System;

namespace BackendService.Core.DTOs.Category.Responses
{
    public class CategoryResponseDto
    {
        public Guid Id { get; set; }
        public string TenDanhMuc { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? ParentId { get; set; }
    }
}
