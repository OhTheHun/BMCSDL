using BackendService.Model.Enums;
using System;

namespace BackendService.Core.DTOs.Supplier.Requests
{
    public class UpdateSupplierRequestDto
    {
        public Guid Id { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TaxCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public string Field { get; set; } = string.Empty;
        public SupplierEnum Status { get; set; }
    }
}
