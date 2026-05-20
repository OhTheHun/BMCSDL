using BackendService.Core.DTOs.Invoice.Requests;
using BackendService.Model;

namespace BackendService.Mapping
{
    public static class AddInvoiceItemRequestDtoToInvoiceItem
    {
        public static InvoiceItem Transform(AddInvoiceItemRequestDto dto)
        {
            return new InvoiceItem
            {
                Id = Guid.NewGuid(),
                InvoiceId = dto.InvoiceId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                Total = dto.Total,
                UpdatedBy = "Customer",
                CreatedBy = "Customer",
                CreatedTime = DateTime.UtcNow, 
                UpdatedTime = DateTime.UtcNow,
                DeleteFlag = false
            };
        }
    }
}
