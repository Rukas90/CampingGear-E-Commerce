using TrailStore.Ordering.Infrastructure.Database;
using TrailStore.Seed.Common;
using TrailStore.Seed.Runners;

namespace TrailStore.Seed.Registrations;

public static class OrderingSeedingRegistration
{
    public static HostApplicationBuilder AddOrderingSeeding(this HostApplicationBuilder builder)
    {
        builder.Services.AddOrderingContext(builder.Configuration);
        builder.Services.AddScoped<ISeedRunner, OrderingSeedRunner>();
        
        return builder;
    }
}