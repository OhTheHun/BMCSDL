using BackendService.Configuration;
using BackendService.Core.DTOs.Category.Requests;
using BackendService.Core.DTOs.Category.Responses;
using BackendService.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BackendService.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController(
        IOptions<ConfigOptions> options, 
        ICategoryService categoryService, 
        IValidator<CreateCategoryRequestDto> createValidator,
        IValidator<UpdateCategoryRequestDto> updateValidator) : BackendBaseController(options)
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IValidator<CreateCategoryRequestDto> _createValidator = createValidator;
        private readonly IValidator<UpdateCategoryRequestDto> _updateValidator = updateValidator;

        [HttpGet]
        public async Task<ActionResult<List<CategoryResponseDto>>> GetAllAsync([FromQuery] string? keyword, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _categoryService.GetAllAsync(keyword, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _categoryService.GetByIdAsync(id, cancellationToken);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateCategoryRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return BadRequest(new { error = validationResult.Errors.Select(e => e.ErrorMessage) });
                }

                await _categoryService.CreateAsync(request, cancellationToken);
                return Ok(new { message = "Thêm danh mục thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateCategoryRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _updateValidator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return BadRequest(new { error = validationResult.Errors.Select(e => e.ErrorMessage) });
                }

                await _categoryService.UpdateAsync(request, cancellationToken);
                return Ok(new { message = "Cập nhật danh mục thành công" });
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
                await _categoryService.DeleteAsync(id, cancellationToken);
                return Ok(new { message = "Xóa danh mục thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
