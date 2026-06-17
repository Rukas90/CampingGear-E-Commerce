using Microsoft.AspNetCore.Builder;
using TrailStore.Identity.Api.Authentication;
using TrailStore.Identity.Api.Csrf;
using TrailStore.Identity.Application;
using TrailStore.Identity.Infrastructure;
using TrailStore.Identity.Infrastructure.Data;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Registrations;

namespace TrailStore.Identity.Api.Registration;

public static class IdentityModuleRegistration
{
    public static ModuleHostBuilder AddIdentityModule(this ModuleHostBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;
        
        services.AddIdentityContext(configuration);
        
        services.AddAppServicesFromAssemblies(
            IdentityApiMaker.Reference,
            IdentityApplicationMarker.Reference,
            IdentityInfrastructureMarker.Reference);

        services.ConfigureAppOptionsFromAssemblies(configuration,
            IdentityApplicationMarker.Reference,
            IdentityInfrastructureMarker.Reference);

        services.AddAppAuthentication(configuration);

        builder.AddApiAssembly(IdentityApiMaker.Reference);
        
        return builder;
    }

    public static void UseIdentityModule(this WebApplication app)
    {
        app.UseMiddleware<CsrfInitializeMiddleware>();
        app.UseMiddleware<CsrfValidateMiddleware>();
    }
}