using BackendService.Core.DTOs.Product.Responses;
using BackendService.Model;

namespace BackendService.Mapping
{
    public static class DonViTinhToGetListDonViTinhResponseDto
    {
        public static GetListDonViTinhResponseDto Transform(DonViTinh donViTinh)
        {
            return new GetListDonViTinhResponseDto
            {
                Id = donViTinh.Id,
                TenDonViTinh = donViTinh.TenDonViTinh
            };
        }
    }
}
