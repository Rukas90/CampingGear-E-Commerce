using Microsoft.EntityFrameworkCore;
using TrailStore.Catalog.Application.Abstractions;
using TrailStore.Catalog.Domain.Categories;
using TrailStore.Catalog.Domain.Options;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Reviews;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Catalog.Infrastructure.Database.Converters;
using TrailStore.Shared.Infrastructure.Configurations;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Catalog.Infrastructure.Database;

[AppService<ICatalogUnitOfWork>]
public class CatalogDbContext(DbContextOptions<CatalogDbContext> options)
    : BaseDbContext<CatalogDbContext>(options), ICatalogUnitOfWork
{
    public DbSet<Product> Products { get; set; }
    
    public DbSet<ProductImage> ProductImages { get; set; }
    
    public DbSet<Sku> Skus { get; set; }
    
    public DbSet<OptionGroup> OptionGroups { get; set; }
    
    public DbSet<Option> Options { get; set; }
    
    public DbSet<Brand> Brands { get; set; }
    
    public DbSet<CategoryGroup> CategoryGroups { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Review> Reviews { get; set; }
    
    public DbSet<ReviewVote> ReviewVotes { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder config)
    {
        DatabaseConventionConfiguration.ApplyDefaultConventions<CatalogDbContext>(config);
        config.Properties<SkuCode>().HaveConversion<SkuCodeConverter>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbDefaults.DefaultSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
    }
}