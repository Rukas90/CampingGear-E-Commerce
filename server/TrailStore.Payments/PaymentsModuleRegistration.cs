using Microsoft.Extensions.DependencyInjection;
using Stripe;
using TrailStore.Payments.Infrastructure.Database;
using TrailStore.Shared.Api.Registrations;
using TrailStore.Shared.Infrastructure.Extensions;

namespace TrailStore.Payments;

public static class PaymentsModuleRegistration
{
    public static ModuleHostBuilder AddPaymentsModule(this ModuleHostBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        services.AddPaymentsContext(configuration);
        
        services.AddAppServicesFromAssemblies(PaymentsMarker.Reference);

        StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];
        
        services.AddSingleton<PaymentIntentService>();
        
        services.ConfigureAppOptionsFromAssemblies(configuration, PaymentsMarker.Reference);
        
        builder.AddApiAssembly(PaymentsMarker.Reference);
        
        return builder;
    }
}