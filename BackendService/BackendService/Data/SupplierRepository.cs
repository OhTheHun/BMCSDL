using BackendService.Data.DataContext;
using BackendService.Data.Interface;
using BackendService.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendService.Data
{
    public class SupplierRepository(AppDbContext context) : ISupplierRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<Supplier>> GetAllAsync(CancellationToken cancellationToken)
        {
            var list = await _context.Suppliers
                .FromSqlRaw("EXEC sp_Supplier_Decrypt_Data")
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            return list.Where(s => !s.DeleteFlag).ToList();
        }

        public async Task<Supplier?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var list = await _context.Suppliers
                .FromSqlRaw("EXEC sp_Supplier_Decrypt_Data @SupplierId = {0}", id)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            return list.FirstOrDefault();
        }

        public async Task AddAsync(Supplier supplier, CancellationToken cancellationToken)
        {
            string sql = @"
                EXEC SP_Add_Supplier 
                    @SupplierName = {0}, 
                    @Email = {1}, 
                    @PhoneNumber = {2}, 
                    @TaxCode = {3}, 
                    @Address = {4}, 
                    @CreatedBy = {5}";

            await _context.Database.ExecuteSqlRawAsync(sql, 
                supplier.SupplierName, 
                supplier.Email, 
                supplier.PhoneNumber, 
                supplier.TaxCode, 
                supplier.Address, 
                supplier.CreatedBy ?? "system");
        }

        public async Task UpdateAsync(Supplier supplier, CancellationToken cancellationToken)
        {
            string sql = @"
                EXEC SP_Update_Supplier 
                    @Id = {0},
                    @SupplierName = {1}, 
                    @Email = {2}, 
                    @PhoneNumber = {3}, 
                    @TaxCode = {4}, 
                    @Address = {5}, 
                    @UpdatedBy = {6}";

            await _context.Database.ExecuteSqlRawAsync(sql, 
                supplier.Id,
                supplier.SupplierName, 
                supplier.Email, 
                supplier.PhoneNumber, 
                supplier.TaxCode, 
                supplier.Address, 
                supplier.UpdatedBy ?? "system");
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            string sql = @"EXEC SP_Delete_Supplier @Id = {0}";
            await _context.Database.ExecuteSqlRawAsync(sql, id);
        }
    }
}
