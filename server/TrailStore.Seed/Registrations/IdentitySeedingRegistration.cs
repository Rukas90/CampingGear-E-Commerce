using TrailStore.Identity.Infrastructure.Database;
using TrailStore.Seed.Common;
using TrailStore.Seed.Runners;

namespace TrailStore.Seed.Registrations;

public static class IdentitySeedingRegistration
{
    public static HostApplicationBuilder AddIdentitySeeding(this HostApplicationBuilder builder)
    {
        builder.Services.AddIdentityContext(builder.Configuration);
        builder.Services.AddScoped<ISeedRunner, IdentitySeedRunner>();
        
        return builder;
    }
}