using BackendService.Model;

namespace BackendService.Data.Interface
{
    public interface IInventoryRepository
    {
        Task<Inventory?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken);
        Task UpdateAsync(Inventory inventory, CancellationToken cancellationToken);
        Task CreateAsync(Inventory inventory, CancellationToken cancellationToken);
    }
}
