using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.EShop.Products.Products;
using EasyAbp.EShop.Products.Categories;
using EasyAbp.EShop.Products.ProductTypes;
using EasyAbp.EShop.Products.ProductCategories;
using EasyAbp.EShop.Products.ProductStores;

namespace EasyAbp.EShop.Products.EntityFrameworkCore
{
    [ConnectionStringName(ProductsDbProperties.ConnectionStringName)]
    public interface IProductsDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Product> Products { get; set; }
        DbSet<ProductDetail> ProductDetails { get; set; }
        DbSet<ProductAttribute> ProductAttributes { get; set; }
        DbSet<ProductAttributeOption> ProductAttributeOptions { get; set; }
        DbSet<ProductSku> ProductSkus { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<ProductStore> ProductStores { get; set; }
    }
}