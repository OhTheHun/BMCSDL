namespace BackendService.Core.DTOs.Supplier.Responses
{
    public class AdminSuppliersPageDto
    {
        public int TotalSuppliers { get; set; }
        public int ActiveSuppliers { get; set; }
        public int PendingSuppliers { get; set; }

        public List<AdminSupplierDto> Suppliers { get; set; } = new();
    }

    public class AdminSupplierDto
    {
        public Guid Id { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string MST { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
        public string Field { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
