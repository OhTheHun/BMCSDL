using BackendService.Core.DTOs.User.Responses;
using BackendService.Model;
using System.Collections.Generic;
using System.Linq;

namespace BackendService.Mapping
{
    public static class UserToEmployeeResponseDto
    {
        public static List<EmployeeResponseDto> Transform(IEnumerable<(User User, EmployeeProfile? Profile)> data)
        {
            return data.Select(item => new EmployeeResponseDto
            {
                Id = item.User.Id,
                Email = item.User.Email,
                FullName = item.User.FullName,
                Phone = item.User.Phone,
                Address = item.User.Address,
                Image = item.User.Image,
                Role = item.User.Role,
                IsActive = item.User.IsActive,
                
                Birthday = item.Profile?.Date,
                Identify = item.Profile?.Identify,
                Salary = item.Profile?.Salary
            }).ToList();
        }
    }
}
