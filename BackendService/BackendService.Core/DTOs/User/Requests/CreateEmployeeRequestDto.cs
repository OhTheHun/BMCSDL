using System;

namespace BackendService.Core.DTOs.User.Requests
{
    public class CreateEmployeeRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string Role { get; set; } = string.Empty; // Seller or WareHouseManager
        
        // EmployeeProfile fields
        public DateOnly Birthday { get; set; }
        public string Identify { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
