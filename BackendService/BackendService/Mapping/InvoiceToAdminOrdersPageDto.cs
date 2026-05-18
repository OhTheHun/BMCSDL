using BackendService.Core.DTOs.Invoice.Responses;
using BackendService.Model;
using BackendService.Model.Enums;

namespace BackendService.Mapping
{
    public static class InvoiceToAdminOrdersPageDto
    {
        public static AdminOrdersPageDto Transform(List<Invoice> invoices)
        {
            var today = DateTime.UtcNow.Date;
            var todayInvoices = invoices.Where(i => i.CreatedTime.Date == today).ToList();
            
            return new AdminOrdersPageDto
            {
                TodayRevenue = todayInvoices.Where(i => i.Status == InvoiceEnum.Completed).Sum(i => i.TotalAmount),
                NewOrdersToday = todayInvoices.Count,
                ConversionRate = 3.2, // Mocking conversion rate like in the image (3.2%)
                Orders = invoices.OrderByDescending(i => i.CreatedTime).Select(i => new AdminOrderDto
                {
                    Id = i.Id,
                    Code = i.Code,
                    CustomerName = string.IsNullOrEmpty(i.FullName) ? "Khách vãng lai" : i.FullName,
                    CreatedTime = i.CreatedTime,
                    TotalAmount = i.TotalAmount,
                    Status = i.Status.ToString()
                }).ToList()
            };
        }
    }
}
