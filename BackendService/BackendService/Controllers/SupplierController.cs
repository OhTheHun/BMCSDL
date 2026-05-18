using BackendService.Configuration;
using BackendService.Core.DTOs.Supplier.Requests;
using BackendService.Core.DTOs.Supplier.Responses;
using BackendService.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BackendService.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController(
        IOptions<ConfigOptions> options, 
        ISupplierService supplierService,
        IValidator<CreateSupplierRequestDto> createValidator,
        IValidator<UpdateSupplierRequestDto> updateValidator) : BackendBaseController(options)
    {
        private readonly ISupplierService _supplierService = supplierService;
        private readonly IValidator<CreateSupplierRequestDto> _createValidator = createValidator;
        private readonly IValidator<UpdateSupplierRequestDto> _updateValidator = updateValidator;

        [HttpGet("admin/list")]
        public async Task<ActionResult<AdminSuppliersPageDto>> GetAdminListAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _supplierService.GetAdminSuppliersPageAsync(cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<SupplierResponseDto>>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _supplierService.GetAllAsync(cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _supplierService.GetByIdAsync(id, cancellationToken);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateSupplierRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return BadRequest(new { error = validationResult.Errors.Select(e => e.ErrorMessage) });
                }

                await _supplierService.CreateAsync(request, cancellationToken);
                return Ok(new { message = "Thêm nhà cung cấp thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateSupplierRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return BadRequest(new { error = validationResult.Errors.Select(e => e.ErrorMessage) });
                }

                await _supplierService.UpdateAsync(request, cancellationToken);
                return Ok(new { message = "Cập nhật nhà cung cấp thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _supplierService.DeleteAsync(id, cancellationToken);
                return Ok(new { message = "Xóa nhà cung cấp thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
