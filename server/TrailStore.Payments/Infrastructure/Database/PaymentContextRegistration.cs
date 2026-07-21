using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Payments.Application.Abstractions;
using TrailStore.Shared.Infrastructure.Extensions;
using TrailStore.Shared.Infrastructure.Outbox;

namespace TrailStore.Payments.Infrastructure.Database;

public static class PaymentContextRegistration
{
    public static void AddPaymentsContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddModuleDbContext<PaymentDbContext, IPaymentUnitOfWork>(configuration, DbDefaults.DefaultSchema, 
        (sp, options) => 
        {
            var outboxInterceptor = sp.GetRequiredService<OutboxSignalInterceptor<IPaymentOutbox>>();
            options.AddInterceptors(outboxInterceptor);
        });
}