namespace BackendService.Core.DTOs.Invoice.Responses
{
    public class AdminOrdersPageDto
    {
        public decimal TodayRevenue { get; set; }
        public int NewOrdersToday { get; set; }
        public double ConversionRate { get; set; } // Mocked

        public List<AdminOrderDto> Orders { get; set; } = new();
    }

    public class AdminOrderDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
