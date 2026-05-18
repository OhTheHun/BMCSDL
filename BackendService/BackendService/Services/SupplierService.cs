using BackendService.Core.DTOs.Supplier.Requests;
using BackendService.Core.DTOs.Supplier.Responses;
using System;
using BackendService.Data.Interface;
using BackendService.Mapping;
using BackendService.Services.Interface;

namespace BackendService.Services
{
    public class SupplierService(ISupplierRepository supplierRepository) : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository = supplierRepository;

        public async Task<AdminSuppliersPageDto> GetAdminSuppliersPageAsync(CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.GetAllAsync(cancellationToken);
            return SupplierToAdminSuppliersPageDto.Transform(suppliers);
        }

        public async Task<List<SupplierResponseDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.GetAllAsync(cancellationToken);
            return SupplierToSupplierResponseDto.Transform(suppliers);
        }

        public async Task<SupplierResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id, cancellationToken);
            return supplier == null ? null : SupplierToSupplierResponseDto.Transform(supplier);
        }

        public async Task CreateAsync(CreateSupplierRequestDto request, CancellationToken cancellationToken)
        {
            var supplier = CreateSupplierRequestDtoToSupplier.Transform(request);
            await _supplierRepository.AddAsync(supplier, cancellationToken);
        }

        public async Task UpdateAsync(UpdateSupplierRequestDto request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.Id, cancellationToken);
            if (supplier != null)
            {
                supplier.SupplierName = request.SupplierName;
                supplier.PhoneNumber = request.PhoneNumber;
                supplier.Email = request.Email;
                supplier.TaxCode = request.TaxCode;
                supplier.Address = request.Address;
                supplier.ContactName = request.ContactName;
                supplier.Field = request.Field;
                supplier.Status = request.Status;
                supplier.UpdatedTime = DateTime.UtcNow;

                await _supplierRepository.UpdateAsync(supplier, cancellationToken);
            }
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _supplierRepository.DeleteAsync(id, cancellationToken);
        }
    }
}
