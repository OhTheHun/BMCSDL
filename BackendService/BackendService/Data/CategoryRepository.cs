using BackendService.Data.DataContext;
using BackendService.Data.Interface;
using BackendService.Model.Common;
using Microsoft.EntityFrameworkCore;

namespace BackendService.Data
{
    public class CategoryRepository(PostgresDbContext context) : ICategoryRepository
    {
        private readonly PostgresDbContext _context = context;

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
            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Category category, CancellationToken cancellationToken)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(id, cancellationToken);
            if (category != null)
            {
                category.DeleteFlag = true;
                category.UpdatedTime = DateTime.UtcNow;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
