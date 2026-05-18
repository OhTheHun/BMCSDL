namespace BackendService.Core.DTOs.Category.Requests
{
    public class CreateCategoryRequestDto
    {
        public string TenDanhMuc { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? ParentId { get; set; }
    }
}
