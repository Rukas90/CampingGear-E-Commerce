using Microsoft.EntityFrameworkCore;
using TrailStore.Catalog.Domain.Categories;
using TrailStore.Catalog.Domain.Options;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Reviews.Models;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Catalog.Infrastructure.Database;
using TrailStore.Seed.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Seed.Runners;

[AppService<ISeedRunner>]
public class CatalogSeedRunner(CatalogDbContext context) : SeedRunner
{
    public override string Identifier => "Catalog";

    protected override async Task DeleteAsync()
    {
        await context.ReviewVotes.ExecuteDeleteAsync();
        await context.Reviews.ExecuteDeleteAsync();
        await context.Skus.ExecuteDeleteAsync();
        await context.ProductImages.ExecuteDeleteAsync();
        await context.Products.ExecuteDeleteAsync();
        await context.Options.ExecuteDeleteAsync();
        await context.OptionGroups.ExecuteDeleteAsync();
        await context.Categories.ExecuteDeleteAsync();
        await context.CategoryGroups.ExecuteDeleteAsync();
        await context.Brands.ExecuteDeleteAsync();
    }

    protected override void Seed()
    {
        context.Brands.AddRange(Discover<Brand>(ExecutingAssembly));
        context.CategoryGroups.AddRange(Discover<CategoryGroup>(ExecutingAssembly));
        context.Categories.AddRange(Discover<Category>(ExecutingAssembly));
        context.OptionGroups.AddRange(Discover<OptionGroup>(ExecutingAssembly));
        context.Options.AddRange(Discover<Option>(ExecutingAssembly));
        context.Products.AddRange(Discover<Product>(ExecutingAssembly));
        context.ProductImages.AddRange(Discover<ProductImage>(ExecutingAssembly));
        context.Skus.AddRange(Discover<Sku>(ExecutingAssembly));
        context.Reviews.AddRange(Discover<Review>(ExecutingAssembly));
    }

    protected override Task Commit()
        => context.SaveChangesAsync();

    protected override Task<bool> IsSeededAsync()
        => context.Products.AnyAsync();
}