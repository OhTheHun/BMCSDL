using BackendService.Core.DTOs.Invoice.Responses;
using BackendService.Model;

namespace BackendService.Mapping
{
    public static class InvoiceToGetActorProcessedOrdersResponseDto
    {
        public static List<GetActorProcessedOrdersResponseDto> transform(List<Invoice> invoices)
        {
            return invoices.Select(i => new GetActorProcessedOrdersResponseDto
            {
                Id = i.Id,
                Code = i.Code,
                CustomerName = string.IsNullOrEmpty(i.FullName) ? "Khách vãng lai" : i.FullName,
                CreatedTime = i.CreatedTime,
                TotalAmount = i.TotalAmount,
                Status = i.Status.ToString()
            }).ToList();
        }
    }
}
