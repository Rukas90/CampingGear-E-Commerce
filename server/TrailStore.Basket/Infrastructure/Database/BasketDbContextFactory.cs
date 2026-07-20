using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Basket.Infrastructure.Database;

// ReSharper disable once UnusedType.Global
public class BasketDbContextFactory : ModuleDbContextFactory<BasketDbContext>
{
    protected override string Schema => DbDefaults.DefaultSchema;
    protected override BasketDbContext CreateContext(DbContextOptions<BasketDbContext> options) => new(options);
}