using BackendService.Model.Common;

namespace BackendService.Data.Interface
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync(string? keyword, CancellationToken cancellationToken);
        Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(Category category, CancellationToken cancellationToken);
        Task UpdateAsync(Category category, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
