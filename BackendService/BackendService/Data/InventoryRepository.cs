using BackendService.Data.DataContext;
using BackendService.Data.Interface;
using BackendService.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendService.Data
{
    public class InventoryRepository(PostgresDbContext context) : IInventoryRepository
    {
        private readonly PostgresDbContext _context = context;

        public async Task<Inventory?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken)
        {
            return await _context.Inventories
                .FirstOrDefaultAsync(i => i.ProductId == productId && i.DeleteFlag == false, cancellationToken);
        }

        public async Task UpdateAsync(Inventory inventory, CancellationToken cancellationToken)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task CreateAsync(Inventory inventory, CancellationToken cancellationToken)
        {
            await _context.Inventories.AddAsync(inventory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
