using BackendService.Data.DataContext;
using BackendService.Data.Interface;
using BackendService.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendService.Data
{
    public class DonViTinhRepository(AppDbContext dbContext) : IDonViTinhRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<DonViTinh[]> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.DonViTinhs
                .Where(d => !d.DeleteFlag)
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);
        }
    }
}
