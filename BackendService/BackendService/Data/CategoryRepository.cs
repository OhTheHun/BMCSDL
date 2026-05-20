using BackendService.Data.DataContext;
using BackendService.Data.Interface;
using BackendService.Model.Common;
using Microsoft.EntityFrameworkCore;

namespace BackendService.Data
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<Category>> GetAllAsync(string? keyword, CancellationToken cancellationToken)
        {
            var query = _context.Categories.Where(c => !c.DeleteFlag);

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(c => c.TenDanhMuc.Contains(keyword));
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && !c.DeleteFlag, cancellationToken);
        }

        public async Task AddAsync(Category category, CancellationToken cancellationToken)
        {
            string sql = @"
                EXEC SP_Add_Category 
                    @CategoryName = {0}, 
                    @Description = {1}, 
                    @ParentId = {2}, 
                    @CreatedBy = {3}";

            await _context.Database.ExecuteSqlRawAsync(sql, 
                category.TenDanhMuc, 
                category.Description, 
                category.ParentId, 
                category.CreatedBy ?? "system");
        }

        public async Task UpdateAsync(Category category, CancellationToken cancellationToken)
        {
            string sql = @"
                EXEC SP_Update_Category 
                    @Id = {0},
                    @CategoryName = {1}, 
                    @Description = {2}, 
                    @ParentId = {3}, 
                    @UpdatedBy = {4}";

            await _context.Database.ExecuteSqlRawAsync(sql, 
                category.Id,
                category.TenDanhMuc, 
                category.Description, 
                category.ParentId, 
                category.UpdatedBy ?? "system");
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            string sql = @"EXEC SP_Delete_Category @Id = {0}";
            await _context.Database.ExecuteSqlRawAsync(sql, id);
        }
    }
}
