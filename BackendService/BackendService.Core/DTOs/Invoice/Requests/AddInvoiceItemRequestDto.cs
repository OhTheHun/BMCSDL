using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendService.Core.DTOs.Invoice.Requests
{
    public class AddInvoiceItemRequestDto
    {
        public Guid InvoiceId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
