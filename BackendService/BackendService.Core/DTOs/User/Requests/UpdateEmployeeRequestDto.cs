using System;

namespace BackendService.Core.DTOs.User.Requests
{
    public class UpdateEmployeeRequestDto
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        
        // EmployeeProfile fields
        public DateOnly Birthday { get; set; }
        public string Identify { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
