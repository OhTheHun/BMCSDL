namespace BackendService.Core.DTOs.Product.Responses
{
    public class GetAdminProductResponseDto
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public Guid SupplierId { get; set; }
        public string UnitName { get; set; } = string.Empty;
        public Guid DonViTinhId { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Cost { get; set; }
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
        public int Status { get; set; }
    }
}
