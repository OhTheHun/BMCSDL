using System;

namespace BackendService.Core.DTOs.User.Responses
{
    public class CustomerResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; }
    }
}
