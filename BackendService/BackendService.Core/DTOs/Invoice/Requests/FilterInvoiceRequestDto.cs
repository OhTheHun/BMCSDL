using BackendService.Model.Enums;

namespace BackendService.Core.DTOs.Invoice.Requests
{
    public class FilterInvoiceRequestDto
    {
        public InvoiceEnum? Status { get; set; }
    }
}
