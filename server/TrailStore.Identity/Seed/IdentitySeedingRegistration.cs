using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TrailStore.Identity.Infrastructure.Database;
using TrailStore.Shared.Seeding;

namespace TrailStore.Identity.Seed;

public static class IdentitySeedingRegistration
{
    public static HostApplicationBuilder AddIdentitySeeding(this HostApplicationBuilder builder)
    {
        builder.Services.AddIdentityContext(builder.Configuration);
        builder.Services.AddScoped<ISeedRunner, IdentitySeedRunner>();
        
        return builder;
    }
}