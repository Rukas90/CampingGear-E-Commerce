using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Identity.Infrastructure.Database;

// ReSharper disable once UnusedType.Global
public class IdentityDbContextFactory : ModuleDbContextFactory<IdentityDbContext>
{
    protected override string Schema => DbDefaults.DefaultSchema;
    protected override IdentityDbContext CreateContext(DbContextOptions<IdentityDbContext> options) => new(options);
}