using BackendService.Data.DataContext;
using BackendService.Data.Interface;
using BackendService.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendService.Data
{
    public class ImportRepository(AppDbContext dbContext) : IImportRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<Import> CreateImportAsync(Import import, List<ImportDetail> details, CancellationToken cancellationToken)
        {
            string sqlImport = @"
                EXEC SP_Create_Import 
                    @Id = {0},
                    @Code = {1}, 
                    @TotalAmount = {2}, 
                    @Note = {3}, 
                    @CreatedBy = {4}";

            await _dbContext.Database.ExecuteSqlRawAsync(sqlImport, 
                import.Id,
                import.Code, 
                import.TotalAmount, 
                import.Note ?? string.Empty, 
                import.CreatedBy ?? "system");

            foreach (var detail in details)
            {
                string sqlDetail = @"
                    EXEC SP_Add_Import_Detail 
                        @ImportId = {0}, 
                        @ProductId = {1}, 
                        @Quantity = {2}, 
                        @Cost = {3}, 
                        @CreatedBy = {4}";

                await _dbContext.Database.ExecuteSqlRawAsync(sqlDetail, 
                    detail.ReceiptId, 
                    detail.ProductId, 
                    detail.Quantity, 
                    detail.ImportPrice, 
                    detail.CreatedBy ?? "system");
            }

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
