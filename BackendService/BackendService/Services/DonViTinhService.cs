using BackendService.Core.DTOs.Product.Responses;
using BackendService.Data.Interface;
using BackendService.Mapping;
using BackendService.Services.Interface;

namespace BackendService.Services
{
    public class DonViTinhService(IDonViTinhRepository donViTinhRepository) : IDonViTinhService
    {
        private readonly IDonViTinhRepository _donViTinhRepository = donViTinhRepository;

        public async Task<GetListDonViTinhResponseDto[]> GetAllAsync(CancellationToken cancellationToken)
        {
            var units = await _donViTinhRepository.GetAllAsync(cancellationToken);
            return units.Select(DonViTinhToGetListDonViTinhResponseDto.Transform).ToArray();
        }
    }
}
