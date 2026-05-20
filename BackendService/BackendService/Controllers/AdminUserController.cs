using BackendService.Configuration;
using BackendService.Core.DTOs.User.Requests;
using BackendService.Core.DTOs.User.Responses;
using BackendService.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackendService.Controllers
{
    [Route("api/admin/user")]
    [ApiController]
    public class AdminUserController(
        IOptions<ConfigOptions> options,
        IAdminUserService adminUserService,
        IValidator<CreateEmployeeRequestDto> createEmployeeValidator,
        IValidator<UpdateEmployeeRequestDto> updateEmployeeValidator) : BackendBaseController(options)
    {
        private readonly IAdminUserService _adminUserService = adminUserService;
        private readonly IValidator<CreateEmployeeRequestDto> _createEmployeeValidator = createEmployeeValidator;
        private readonly IValidator<UpdateEmployeeRequestDto> _updateEmployeeValidator = updateEmployeeValidator;

        [HttpGet("customers")]
        public async Task<ActionResult<List<CustomerResponseDto>>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            try
            {
                var customers = await _adminUserService.GetAllCustomersAsync(cancellationToken);
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpGet("employees")]
        public async Task<ActionResult<List<EmployeeResponseDto>>> GetAllEmployeesAsync([FromQuery] string? keyword, CancellationToken cancellationToken)
        {
            try
            {
                var employees = await _adminUserService.GetAllEmployeesAsync(keyword, cancellationToken);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpPost("employee/create")]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _createEmployeeValidator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return BadRequest(new { errors = validationResult.Errors.Select(e => e.ErrorMessage) });
                }

                await _adminUserService.CreateEmployeeAsync(request, Username, cancellationToken);
                return Ok(new { message = "Employee created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpPut("employee/update")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromBody] UpdateEmployeeRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _updateEmployeeValidator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return BadRequest(new { errors = validationResult.Errors.Select(e => e.ErrorMessage) });
                }

                await _adminUserService.UpdateEmployeeAsync(request, Username, cancellationToken);
                return Ok(new { message = "Employee updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpDelete("delete/{userId:guid}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] Guid userId, CancellationToken cancellationToken)
        {
            try
            {
                await _adminUserService.DeleteUserAsync(userId, cancellationToken);
                return Ok(new { message = "User deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}
