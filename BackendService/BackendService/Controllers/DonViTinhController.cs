using BackendService.Configuration;
using BackendService.Core.DTOs.Product.Responses;
using BackendService.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BackendService.Controllers
{
    [Route("api/donvitinh")]
    [ApiController]
    public class DonViTinhController(IOptions<ConfigOptions> options, IDonViTinhService donViTinhService) : BackendBaseController(options)
    {
        private readonly IDonViTinhService _donViTinhService = donViTinhService;

        [HttpGet]
        public async Task<ActionResult<List<GetListDonViTinhResponseDto>>> GetListUnitsAsync(CancellationToken cancellationToken)
        {
            try
            {
                var units = await _donViTinhService.GetAllAsync(cancellationToken);
                return Ok(units);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}
