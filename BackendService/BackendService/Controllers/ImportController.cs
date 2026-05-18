using BackendService.Common;
using BackendService.Core.DTOs.Import.Requests;
using BackendService.Services.Interface;
using BackendService.Core.DTOs.Import.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendService.Controllers
{
    [Route("api/import")]
    [ApiController]
    public class ImportController(IImportService importService, IValidator<AddImportRequestDto> addImportRequestValidator) : ControllerBase
    {
        private readonly IImportService _importService = importService;
        private readonly IValidator<AddImportRequestDto> _addImportRequestValidator = addImportRequestValidator;

        [HttpPost("create")]
        public async Task<ActionResult<ImportResponseDto>> AddImportAsync([FromBody] AddImportRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _addImportRequestValidator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return BadRequest(ValidationResultToCustomValidationResult.Map(validationResult.Errors));
                }

                string actor = User.Identity?.Name ?? "System";

                var response = await _importService.AddImportAsync(request, actor, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<ImportResponseDto>>> GetImportsAsync([FromQuery] GetImportFilterRequestDto filter, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _importService.GetImportsAsync(filter, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}
