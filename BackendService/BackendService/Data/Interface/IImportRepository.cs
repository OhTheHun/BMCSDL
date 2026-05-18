using BackendService.Model;

namespace BackendService.Data.Interface
{
    public interface IImportRepository
    {
        Task<Import> CreateImportAsync(Import import, List<ImportDetail> details, CancellationToken cancellationToken);
        Task<Import?> GetImportByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Import>> GetImportsAsync(DateTime? fromDate, DateTime? toDate, CancellationToken cancellationToken);
        Task<List<ImportDetail>> GetImportDetailsByImportIdAsync(Guid importId, CancellationToken cancellationToken);
    }
}
