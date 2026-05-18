using BackendService.Core.DTOs.Product.Responses;
using BackendService.Model;

namespace BackendService.Mapping
{
    public static class ProductToGetAdminProductResponseDto
    {
        public static GetAdminProductResponseDto Transform(Product product, Inventory inventory)
        {
            return new GetAdminProductResponseDto
            {
                Id = product.Id,
                ImageUrl = product.Image_Url,
                ProductName = product.ProductName,
                SKU = product.SKU,
                CategoryId = product.CategoryId,
                SupplierName = product.Supplier?.SupplierName ?? "Không có",
                SupplierId = product.SupplierId,
                UnitName = product.DonViTinh?.TenDonViTinh ?? "Không có",
                DonViTinhId = product.DonViTinhId,
                Price = product.Price,
                DiscountPrice = product.DiscountPrice,
                Cost = product.Cost,
                Description = product.Description,
                StockQuantity = inventory?.quantity ?? 0,
                Status = (int)product.Status,
            };
        }
    }
}
