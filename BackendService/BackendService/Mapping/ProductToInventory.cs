using BackendService.Model;

namespace BackendService.Mapping
{
    public static class ProductToInventory
    {
        public static Inventory Transform(Product product, string actor)
        {
            return new Inventory
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                quantity = 0,
                CreatedBy = actor,
                CreatedTime = DateTime.UtcNow,
                UpdatedBy = actor,
                UpdatedTime = DateTime.UtcNow,
                DeleteFlag = false
            };
        }
    }
}
