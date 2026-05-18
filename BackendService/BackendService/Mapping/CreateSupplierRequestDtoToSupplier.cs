using BackendService.Core.DTOs.Supplier.Requests;
using BackendService.Model;

namespace BackendService.Mapping
{
    public static class CreateSupplierRequestDtoToSupplier
    {
        public static Supplier Transform(CreateSupplierRequestDto dto)
        {
            return new Supplier
            {
                Id = Guid.NewGuid(),
                SupplierName = dto.SupplierName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                TaxCode = dto.TaxCode,
                Address = dto.Address,
                ContactName = dto.ContactName,
                Field = dto.Field,
                Status = dto.Status,
                CreatedTime = DateTime.UtcNow,
                UpdatedTime = DateTime.UtcNow,
                DeleteFlag = false
            };
        }
    }
}
