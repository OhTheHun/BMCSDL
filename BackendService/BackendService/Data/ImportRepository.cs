using BackendService.Data.DataContext;
using BackendService.Data.Interface;
using BackendService.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendService.Data
{
    public class ImportRepository(PostgresDbContext dbContext) : IImportRepository
    {
        private readonly PostgresDbContext _dbContext = dbContext;

        public async Task<Import> CreateImportAsync(Import import, List<ImportDetail> details, CancellationToken cancellationToken)
        {
            await _dbContext.Imports.AddAsync(import, cancellationToken);
            await _dbContext.ImportDetails.AddRangeAsync(details, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return import;
        }

        public async Task<Import?> GetImportByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Imports.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
        }

        public async Task<List<Import>> GetImportsAsync(DateTime? fromDate, DateTime? toDate, CancellationToken cancellationToken)
        {
            var query = _dbContext.Imports.AsQueryable();

            if (fromDate.HasValue)
                query = query.Where(i => i.CreatedTime >= fromDate.Value);

            if (toDate.HasValue)
                query = query.Where(i => i.CreatedTime <= toDate.Value);

            return await query.OrderByDescending(i => i.CreatedTime).ToListAsync(cancellationToken);
        }

        public async Task<List<ImportDetail>> GetImportDetailsByImportIdAsync(Guid importId, CancellationToken cancellationToken)
        {
            return await _dbContext.ImportDetails.Where(d => d.ReceiptId == importId).ToListAsync(cancellationToken);
        }
    }
}
