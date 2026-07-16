using TrailStore.Shared.Api.Registrations;
using TrailStore.Shared.Infrastructure.Extensions;
using TrailStore.Wishlist.Infrastructure.Database;

namespace TrailStore.Wishlist;

public static class WishlistModuleRegistration
{
    public static ModuleHostBuilder AddWishlistModule(this ModuleHostBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        services.AddWishlistContext(configuration);
        
        services.AddAppServicesFromAssemblies(WishlistMarker.Reference);
        
        services.ConfigureAppOptionsFromAssemblies(configuration, WishlistMarker.Reference);
        
        builder.AddApiAssembly(WishlistMarker.Reference);
        
        return builder;
    }
}