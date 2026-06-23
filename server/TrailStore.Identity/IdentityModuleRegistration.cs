using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Identity.Api.Authentication;
using TrailStore.Identity.Api.Csrf;
using TrailStore.Identity.Infrastructure.Database;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Registrations;

namespace TrailStore.Identity;

public static class IdentityModuleRegistration
{
    public static ModuleHostBuilder AddIdentityModule(this ModuleHostBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;
        
        services.AddIdentityContext(configuration);
        
        services.AddAppServicesFromAssemblies(IdentityMarker.Reference);

        services.ConfigureAppOptionsFromAssemblies(configuration, IdentityMarker.Reference);

        services.AddAppAuthentication(configuration);
        services.AddAuthorization();

        builder.AddApiAssembly(IdentityMarker.Reference);
        
        return builder;
    }

    public static void UseIdentityModule(this WebApplication app)
    {
        app.UseMiddleware<CsrfInitializeMiddleware>();
        app.UseMiddleware<CsrfValidateMiddleware>();
    }
}