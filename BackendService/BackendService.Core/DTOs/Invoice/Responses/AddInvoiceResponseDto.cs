using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendService.Core.DTOs.Invoice.Responses
{
    public class AddInvoiceResponseDto
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }

}
