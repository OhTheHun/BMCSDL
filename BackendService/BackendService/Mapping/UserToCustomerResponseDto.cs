using BackendService.Core.DTOs.User.Responses;
using BackendService.Model;
using System.Collections.Generic;
using System.Linq;

namespace BackendService.Mapping
{
    public static class UserToCustomerResponseDto
    {
        public static List<CustomerResponseDto> Transform(IEnumerable<User> users)
        {
            return users.Select(u => new CustomerResponseDto
            {
                Id = u.Id,
                Email = u.Email,
                FullName = u.FullName,
                Phone = u.Phone,
                Address = u.Address,
                Image = u.Image,
                IsActive = u.IsActive
            }).ToList();
        }
    }
}
