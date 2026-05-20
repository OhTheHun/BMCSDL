using BackendService.Model.Enums;
using BeeExamPro.BackendService.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendService.Model
{
    public class Supplier: BaseEntity
    {
        public string SupplierName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? TaxCode { get; set; }
        public string? Address { get; set; }
        public string? ContactName { get; set; }
        public string? Field { get; set; }
        public SupplierEnum Status { get; set; }
    }
}
