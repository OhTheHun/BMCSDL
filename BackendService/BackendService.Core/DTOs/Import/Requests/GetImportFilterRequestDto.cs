namespace BackendService.Core.DTOs.Import.Requests
{
    public class GetImportFilterRequestDto
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? ProductName { get; set; }
    }
}
