using BackendService.Core.DTOs.Invoice.Responses;
using BackendService.Model;

namespace BackendService.Mapping
{
    public static class InvoiceToAddInvoiceResponseDto
    {
        public static AddInvoiceResponseDto Transform(Invoice invoice)
        {
            return new AddInvoiceResponseDto
            {
                Id = invoice.Id,
                CustomerId = invoice.CustomerId,
                Code = invoice.Code,
                PaymentMethod = invoice.PaymentMethod,
                TotalAmount = invoice.TotalAmount,
                Status = invoice.Status.ToString()
            };
        }
    }
}
