using BackendService.Core.DTOs.Supplier.Responses;
using BackendService.Model;

namespace BackendService.Mapping
{
    public static class SupplierToSupplierResponseDto
    {
        public static SupplierResponseDto Transform(Supplier supplier)
        {
            return new SupplierResponseDto
            {
                Id = supplier.Id,
                SupplierName = supplier.SupplierName,
                PhoneNumber = supplier.PhoneNumber,
                Email = supplier.Email,
                TaxCode = supplier.TaxCode,
                Address = supplier.Address,
                ContactName = supplier.ContactName,
                Field = supplier.Field,
                Status = supplier.Status.ToString()
            };
        }

        public static List<SupplierResponseDto> Transform(List<Supplier> suppliers)
        {
            return suppliers.Select(Transform).ToList();
        }
    }
}
