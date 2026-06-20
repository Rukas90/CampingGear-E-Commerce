using Microsoft.EntityFrameworkCore;
using TrailStore.Catalog.Application.Abstractions;
using TrailStore.Catalog.Domain.Categories;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Reviews;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Shared.Infrastructure.Conversions;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Catalog.Infrastructure.Database;

[AppService<ICatalogUnitOfWork>]
public class CatalogDbContext(DbContextOptions<CatalogDbContext> options)
    : BaseDbContext<CatalogDbContext>(options)
{
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Sku> Skus { get; set; }
    
    public DbSet<Review> Reviews { get; set; }
    
    public DbSet<CategoryGroup> CategoryGroups { get; set; }
    
    public DbSet<Brand> Brands { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder config)
    {
        IdConfigConversions.ConfigureIdConversion(config, typeof(CatalogDbContext).Assembly);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("catalog");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
    }
}