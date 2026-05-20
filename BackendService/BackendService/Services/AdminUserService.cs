using BackendService.Core.DTOs.User.Requests;
using BackendService.Core.DTOs.User.Responses;
using BackendService.Data.Interface;
using BackendService.Mapping;
using BackendService.Model;
using BackendService.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BackendService.Services
{
    public class AdminUserService(IUserRepository userRepository, IPasswordHasherService passwordHasherService) : IAdminUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordHasherService _passwordHasherService = passwordHasherService;

        public async Task<List<CustomerResponseDto>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            var customers = await _userRepository.GetCustomersAsync(cancellationToken);
            return UserToCustomerResponseDto.Transform(customers);
        }

        public async Task<List<EmployeeResponseDto>> GetAllEmployeesAsync(string? keyword, CancellationToken cancellationToken)
        {
            var employees = await _userRepository.GetEmployeesAsync(keyword, cancellationToken);
            return UserToEmployeeResponseDto.Transform(employees);
        }

        public async Task CreateEmployeeAsync(CreateEmployeeRequestDto request, string actor, CancellationToken cancellationToken)
        {
            var (user, profile) = CreateEmployeeRequestDtoToEntities.Transform(request, actor);
            user.Password = _passwordHasherService.Hash(request.Password);
            
            await _userRepository.AddEmployeeAsync(user, profile, cancellationToken);
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeRequestDto request, string actor, CancellationToken cancellationToken)
        {
            var userInDb = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (userInDb == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }

            var (updatedUser, profile) = UpdateEmployeeMapper.Transform(request, userInDb, actor);

            await _userRepository.UpdateEmployeeAsync(updatedUser, profile, cancellationToken);
        }

        public async Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
        {
            await _userRepository.SoftDeleteUserAsync(userId, cancellationToken);
        }
    }
}
