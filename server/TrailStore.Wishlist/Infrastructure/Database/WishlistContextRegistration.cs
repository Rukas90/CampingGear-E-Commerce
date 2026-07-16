using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Shared.Infrastructure.Extensions;
using TrailStore.Wishlist.Application.Abstractions;

namespace TrailStore.Wishlist.Infrastructure.Database;

public static class WishlistContextRegistration
{
    public static void AddWishlistContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddModuleDbContext<WishlistDbContext, IWishlistUnitOfWork>(configuration, DbDefaults.DefaultSchema);
}