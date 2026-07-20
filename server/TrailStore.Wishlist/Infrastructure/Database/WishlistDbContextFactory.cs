using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Wishlist.Infrastructure.Database;

// ReSharper disable once UnusedType.Global
public class WishlistDbContextFactory : ModuleDbContextFactory<WishlistDbContext>
{
    protected override string Schema => DbDefaults.DefaultSchema;
    protected override WishlistDbContext CreateContext(DbContextOptions<WishlistDbContext> options) => new(options);
}