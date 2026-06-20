using Microsoft.AspNetCore.Builder;
using TrailStore.Identity.Api.Api.Authentication;
using TrailStore.Identity.Api.Api.Csrf;
using TrailStore.Identity.Api.Infrastructure.Database;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Registrations;

namespace TrailStore.Identity.Api;

public static class IdentityModuleRegistration
{
    public static ModuleHostBuilder AddIdentityModule(this ModuleHostBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;
        
        services.AddIdentityContext(configuration);
        
        services.AddAppServicesFromAssemblies(IdentityMaker.Reference);

        services.ConfigureAppOptionsFromAssemblies(configuration, IdentityMaker.Reference);

        services.AddAppAuthentication(configuration);

        builder.AddApiAssembly(IdentityMaker.Reference);
        
        return builder;
    }

    public static void UseIdentityModule(this WebApplication app)
    {
        app.UseMiddleware<CsrfInitializeMiddleware>();
        app.UseMiddleware<CsrfValidateMiddleware>();
    }
}