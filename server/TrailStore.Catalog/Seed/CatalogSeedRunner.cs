using Microsoft.EntityFrameworkCore;
using TrailStore.Catalog.Domain.Categories;
using TrailStore.Catalog.Domain.Options;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Reviews;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Catalog.Infrastructure.Database;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Seeding;

namespace TrailStore.Catalog.Seed;

[AppService<ISeedRunner>]
public class CatalogSeedRunner(CatalogDbContext context) : SeedRunner
{
    public override string Identifier => "Catalog";
    
    protected override void Clear()
    {
        context.ReviewVotes.RemoveRange(context.ReviewVotes);
        context.Reviews.RemoveRange(context.Reviews);
        context.Skus.RemoveRange(context.Skus);
        context.ProductImages.RemoveRange(context.ProductImages);
        context.Products.RemoveRange(context.Products);
        context.Options.RemoveRange(context.Options);
        context.OptionGroups.RemoveRange(context.OptionGroups);
        context.Categories.RemoveRange(context.Categories);
        context.CategoryGroups.RemoveRange(context.CategoryGroups);
        context.Brands.RemoveRange(context.Brands);
    }

    protected override void Seed()
    {
        var assembly = typeof(CatalogSeedRunner).Assembly;
        
        context.Brands.AddRange(Discover<Brand>(assembly));
        context.CategoryGroups.AddRange(Discover<CategoryGroup>(assembly));
        context.Categories.AddRange(Discover<Category>(assembly));
        context.OptionGroups.AddRange(Discover<OptionGroup>(assembly));
        context.Options.AddRange(Discover<Option>(assembly));
        context.Products.AddRange(Discover<Product>(assembly));
        context.ProductImages.AddRange(Discover<ProductImage>(assembly));
        context.Skus.AddRange(Discover<Sku>(assembly));
        context.Reviews.AddRange(Discover<Review>(assembly));
    }

    protected override Task Commit()
        => context.SaveChangesAsync();

    protected override Task<bool> IsSeededAsync()
        => context.Products.AnyAsync();
}