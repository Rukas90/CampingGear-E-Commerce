using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Ordering.Infrastructure.Database;

// ReSharper disable once UnusedType.Global
public class OrderingDbContextFactory : ModuleDbContextFactory<OrderingDbContext>
{
    protected override string Schema => DbDefaults.DefaultSchema;
    protected override OrderingDbContext CreateContext(DbContextOptions<OrderingDbContext> options) => new(options);
}