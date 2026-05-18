using BackendService.Core.DTOs.User.Requests;
using BackendService.Core.DTOs.User.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BackendService.Services.Interface
{
    public interface IAdminUserService
    {
        Task<List<CustomerResponseDto>> GetAllCustomersAsync(CancellationToken cancellationToken);
        Task<List<EmployeeResponseDto>> GetAllEmployeesAsync(string? keyword, CancellationToken cancellationToken);
        Task CreateEmployeeAsync(CreateEmployeeRequestDto request, string actor, CancellationToken cancellationToken);
        Task UpdateEmployeeAsync(UpdateEmployeeRequestDto request, string actor, CancellationToken cancellationToken);
        Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken);
    }
}
