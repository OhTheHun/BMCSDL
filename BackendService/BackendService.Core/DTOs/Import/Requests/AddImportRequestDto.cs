namespace BackendService.Core.DTOs.Import.Requests
{
    public class AddImportRequestDto
    {
        public string? Note { get; set; }
        public List<AddImportDetailRequestDto> Details { get; set; } = new();
    }

    public class AddImportDetailRequestDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ImportPrice { get; set; }
    }
}
