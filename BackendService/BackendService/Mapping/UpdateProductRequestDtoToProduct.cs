using BackendService.Core.DTOs.Product.Requests;
using BackendService.Model;

namespace BackendService.Mapping
{
    public static class UpdateProductRequestDtoToProduct
    {
        public static Product Transform(UpdateProductRequestDto request, Product product, string actor)
        {
            product.ProductName = request.ProductName;
            product.CategoryId = request.CategoryId;
            product.SupplierId = request.SupplierId;
            product.DonViTinhId = request.DonViTinhId;
            product.Price = request.Price;
            product.DiscountPrice = request.DiscountPrice;
            product.Cost = request.Cost;
            product.SKU = request.SKU;
            product.Description = request.Description;
            product.Image_Url = request.Image_Url;
            product.Status = request.Status;
            product.UpdatedTime = DateTime.UtcNow;
            product.UpdatedBy = actor;
            return product;
        }
    }
}
