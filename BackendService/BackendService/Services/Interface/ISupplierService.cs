using BackendService.Core.DTOs.Supplier.Requests;
using BackendService.Core.DTOs.Supplier.Responses;
using System;

namespace BackendService.Services.Interface
{
    public interface ISupplierService
    {
        Task<AdminSuppliersPageDto> GetAdminSuppliersPageAsync(CancellationToken cancellationToken);
        Task<List<SupplierResponseDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<SupplierResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(CreateSupplierRequestDto request, CancellationToken cancellationToken);
        Task UpdateAsync(UpdateSupplierRequestDto request, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
