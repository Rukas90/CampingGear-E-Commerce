using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Infrastructure.Persistence;
using TrailStore.Wishlist.Application.Abstractions;
using TrailStore.Wishlist.Domain;

namespace TrailStore.Wishlist.Infrastructure.Database;

public class WishlistDbContext(DbContextOptions<WishlistDbContext> options)
    : BaseDbContext<WishlistDbContext>(options), IWishlistUnitOfWork
{
    protected override string DefaultSchema => DbDefaults.DefaultSchema;
    
    public DbSet<CustomerWishlist> Wishlists { get; set; }
    
    public DbSet<WishlistItem> WishlistItems { get; set; }

    protected override Assembly[] AdditionalConfigurationAssemblies()
        =>
        [
            typeof(UserRef).Assembly, typeof(SkuRef).Assembly
        ];
}