using BackendService.Model;

namespace BackendService.Data.Interface
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllAsync(CancellationToken cancellationToken);
        Task<Supplier?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(Supplier supplier, CancellationToken cancellationToken);
        Task UpdateAsync(Supplier supplier, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
