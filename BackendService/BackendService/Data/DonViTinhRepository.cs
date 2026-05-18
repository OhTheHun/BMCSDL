using BackendService.Data.DataContext;
using BackendService.Data.Interface;
using BackendService.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendService.Data
{
    public class DonViTinhRepository(PostgresDbContext dbContext) : IDonViTinhRepository
    {
        private readonly PostgresDbContext _dbContext = dbContext;

        public async Task<DonViTinh[]> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.DonViTinhs
                .Where(d => !d.DeleteFlag)
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);
        }
    }
}
