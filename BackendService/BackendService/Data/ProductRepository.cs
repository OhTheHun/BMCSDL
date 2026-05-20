using BackendService.Data.DataContext;
using BackendService.Data.Interface;
using BackendService.Model;
using BackendService.Model.Common;
using BackendService.Model.Enums;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BackendService.Data
{
    public class ProductRepository(AppDbContext dbContext) : IProductRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken)
        {
            if (product.Id == Guid.Empty)
            {
                product.Id = Guid.NewGuid();
            }

            string sql = @"
                EXEC SP_Add_Product 
                    @Id = {0},
                    @CategoryId = {1}, 
                    @ProductName = {2}, 
                    @Price = {3}, 
                    @DiscountPrice = {4}, 
                    @Cost = {5}, 
                    @Description = {6}, 
                    @ImageUrl = {7}, 
                    @SupplierId = {8}, 
                    @CreatedBy = {9},
                    @DonViTinhId = {10},
                    @SKU = {11}";

            await _dbContext.Database.ExecuteSqlRawAsync(sql, 
                product.Id,
                product.CategoryId, 
                product.ProductName, 
                product.Price, 
                product.DiscountPrice, 
                product.Cost, 
                product.Description, 
                product.Image_Url, 
                product.SupplierId, 
                product.CreatedBy ?? "system",
                product.DonViTinhId,
                product.SKU);

            return product;
        }

        public async Task<Product[]> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            return await _dbContext.Products
                .Where(p => p.CategoryId == categoryId && !p.DeleteFlag)
                .Include(p => p.DonViTinh)
                .ToArrayAsync(cancellationToken);
        }

        public async Task<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.Include(p => p.DonViTinh).FirstOrDefaultAsync(p => p.Id == productId && !p.DeleteFlag, cancellationToken);
        }

        public async Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductName.ToLower() == name.ToLower() && !p.DeleteFlag, cancellationToken);   
        }

        public async Task<Product[]> GetListAysnc(string? keyword, CancellationToken cancellationToken)
        {
            IQueryable<Product> query = _dbContext.Products.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(x =>
                   x.ProductName.ToLower().Contains(keyword.ToLower()));
            }

            query = query
                .Where(x => !x.DeleteFlag)
                .Where(x => x.Status == ProductEnum.Active )
                                .Include(p => p.DonViTinh);

            return await query.ToArrayAsync(cancellationToken);
        }

        public async Task<Product[]> GetAdminListAsync(string? keyword, Guid? categoryId, int? status, CancellationToken cancellationToken)
        {
            IQueryable<Product> query = _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.DonViTinh)
                .Include(p => p.Supplier)
                .Where(x => !x.DeleteFlag);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(x =>
                   x.ProductName.ToLower().Contains(keyword.ToLower()) ||
                   x.SKU.ToLower().Contains(keyword.ToLower()));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }

            if (status.HasValue)
            {
                query = query.Where(x => (int)x.Status == status.Value);
            }

            return await query.OrderByDescending(x => x.CreatedTime).ToArrayAsync(cancellationToken);
        }

        public async Task<Category[]> GetListCategoryAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Categories.Where(c => !c.DeleteFlag).AsNoTracking().ToArrayAsync(cancellationToken);
        }

        public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            string sql = @"
                EXEC SP_Update_Product 
                    @Id = {0},
                    @CategoryId = {1}, 
                    @SupplierId = {2}, 
                    @ProductName = {3}, 
                    @Price = {4}, 
                    @DiscountPrice = {5}, 
                    @Cost = {6}, 
                    @Description = {7}, 
                    @ImageUrl = {8}, 
                    @Status = {9},
                    @UpdatedBy = {10},
                    @DonViTinhId = {11},
                    @SKU = {12}";

            await _dbContext.Database.ExecuteSqlRawAsync(sql, 
                product.Id,
                product.CategoryId, 
                product.SupplierId, 
                product.ProductName, 
                product.Price, 
                product.DiscountPrice, 
                product.Cost, 
                product.Description, 
                product.Image_Url, 
                (int)product.Status,
                product.UpdatedBy ?? "system",
                product.DonViTinhId,
                product.SKU);

            return product;
        }

        public async Task SoftDeleteAsync(Guid productId, string actor, CancellationToken cancellationToken)
        {
            string sql = @"EXEC SP_Delete_Product @Id = {0}";
            await _dbContext.Database.ExecuteSqlRawAsync(sql, productId);
        }
    };
}
