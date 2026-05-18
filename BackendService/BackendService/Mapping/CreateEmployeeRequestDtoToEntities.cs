using BackendService.Core.DTOs.User.Requests;
using BackendService.Model;
using System;

namespace BackendService.Mapping
{
    public static class CreateEmployeeRequestDtoToEntities
    {
        public static (User User, EmployeeProfile Profile) Transform(CreateEmployeeRequestDto request, string actor)
        {
            var now = DateTime.UtcNow;
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                FullName = request.FullName,
                Phone = request.Phone,
                Address = request.Address,
                Role = request.Role,
                IsActive = true,
                CreatedBy = actor,
                UpdatedBy = actor,
                CreatedTime = now,
                UpdatedTime = now,
                DeleteFlag = false
            };

            var profile = new EmployeeProfile
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Date = request.Birthday,
                Identify = request.Identify,
                Salary = request.Salary,
                CreatedBy = actor,
                UpdatedBy = actor,
                CreatedTime = now,
                UpdatedTime = now,
                DeleteFlag = false
            };

            return (user, profile);
        }
    }
}
