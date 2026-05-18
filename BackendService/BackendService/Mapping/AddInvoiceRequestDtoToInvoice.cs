using BackendService.Core.DTOs.Invoice.Requests;
using BackendService.Model;
using BackendService.Model.Enums;

namespace BackendService.Mapping
{
    public static class AddInvoiceRequestDtoToInvoice
    {
        public static Invoice Transform(AddInvoiceRequestDto dto, string randomCode, string user)
        {
            return new Invoice
            {
                Id = Guid.NewGuid(),
                CustomerId = dto.CustomerId,
                FullName = dto.FullName,
                Phone = dto.Phone,
                Address = dto.Address,
                PaymentMethod = dto.PaymentMethod,
                Code = randomCode,
                UpdatedBy = user,
                CreatedBy = user,
                UpdatedTime = DateTime.UtcNow,
                CreatedTime = DateTime.UtcNow,
                DeleteFlag  = false,
                TotalAmount = dto.TotalAmount,
                Status = InvoiceEnum.Confirmed

            };
        }
    }
}
