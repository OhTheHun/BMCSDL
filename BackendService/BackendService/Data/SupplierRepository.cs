using BackendService.Data.DataContext;
using BackendService.Data.Interface;
using BackendService.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendService.Data
{
    public class SupplierRepository(PostgresDbContext context) : ISupplierRepository
    {
        private readonly PostgresDbContext _context = context;

        public async Task<List<Supplier>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Suppliers.Where(s => !s.DeleteFlag).ToListAsync(cancellationToken);
        }

        public async Task<Supplier?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == id && !s.DeleteFlag, cancellationToken);
        }

        public async Task AddAsync(Supplier supplier, CancellationToken cancellationToken)
        {
            await _context.Suppliers.AddAsync(supplier, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Supplier supplier, CancellationToken cancellationToken)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var supplier = await _context.Suppliers.FindAsync(id, cancellationToken);
            if (supplier != null)
            {
                supplier.DeleteFlag = true;
                supplier.UpdatedTime = DateTime.UtcNow;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
