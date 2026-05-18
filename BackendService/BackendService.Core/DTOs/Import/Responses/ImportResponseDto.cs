namespace BackendService.Core.DTOs.Import.Responses
{
    public class ImportResponseDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Note { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        
        public List<ImportDetailResponseDto> Details { get; set; } = new();
    }

    public class ImportDetailResponseDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
