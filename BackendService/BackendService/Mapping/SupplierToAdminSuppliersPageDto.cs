using BackendService.Core.DTOs.Supplier.Responses;
using BackendService.Model;

namespace BackendService.Mapping
{
    public static class SupplierToAdminSuppliersPageDto
    {
        public static AdminSuppliersPageDto Transform(List<Supplier> suppliers)
        {
            return new AdminSuppliersPageDto
            {
                TotalSuppliers = suppliers.Count,
                ActiveSuppliers = suppliers.Count,
                PendingSuppliers = 0,
                Suppliers = suppliers.Select(s => new AdminSupplierDto
                {
                    Id = s.Id,
                    SupplierName = s.SupplierName,
                    MST = s.TaxCode,
                    ContactName = s.ContactName,
                    ContactPhone = s.PhoneNumber,
                    Field = s.Field,
                    Status = s.Status.ToString()
                }).ToList()
            };
        }
    }
}
