using BackendService.Core.DTOs.User.Requests;
using BackendService.Model;
using System;

namespace BackendService.Mapping
{
    public static class UpdateEmployeeMapper
    {
        public static (User, EmployeeProfile) Transform(UpdateEmployeeRequestDto request, User existingUser, string actor)
        {
            existingUser.FullName = request.FullName;
            existingUser.Phone = request.Phone;
            existingUser.Address = request.Address;
            existingUser.Role = request.Role;
            existingUser.IsActive = request.IsActive;
            existingUser.UpdatedBy = actor;
            existingUser.UpdatedTime = DateTime.UtcNow;

            var profile = new EmployeeProfile
            {
                UserId = request.Id,
                Date = request.Birthday,
                Identify = request.Identify,
                Salary = request.Salary,
                UpdatedBy = actor,
                UpdatedTime = DateTime.UtcNow
            };

            return (existingUser, profile);
        }
    }
}
