using BackendService.Core.DTOs.Import.Requests;
using BackendService.Core.DTOs.Import.Responses;

namespace BackendService.Services.Interface
{
    public interface IImportService
    {
        Task<ImportResponseDto> AddImportAsync(AddImportRequestDto request, string actor, CancellationToken cancellationToken);
        Task<List<ImportResponseDto>> GetImportsAsync(GetImportFilterRequestDto filter, CancellationToken cancellationToken);
    }
}
