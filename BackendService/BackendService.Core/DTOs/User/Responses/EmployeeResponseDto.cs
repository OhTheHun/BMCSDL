using System;

namespace BackendService.Core.DTOs.User.Responses
{
    public class EmployeeResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        
        // From EmployeeProfile
        public DateOnly? Birthday { get; set; }
        public string? Identify { get; set; }
        public decimal? Salary { get; set; }
    }
}
