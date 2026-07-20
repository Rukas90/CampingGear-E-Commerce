using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Catalog.Infrastructure.Database;

// ReSharper disable once UnusedType.Global
public class CatalogDbContextFactory : ModuleDbContextFactory<CatalogDbContext>
{
    protected override string Schema => DbDefaults.DefaultSchema;
    protected override CatalogDbContext CreateContext(DbContextOptions<CatalogDbContext> options) => new(options);
}