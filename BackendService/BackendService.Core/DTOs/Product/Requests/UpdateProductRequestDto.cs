using BackendService.Model.Enums;

namespace BackendService.Core.DTOs.Product.Requests
{
    public class UpdateProductRequestDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public Guid DonViTinhId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Cost { get; set; }
        public string SKU { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Image_Url { get; set; } = string.Empty;
        public ProductEnum Status { get; set; }
    }
}
