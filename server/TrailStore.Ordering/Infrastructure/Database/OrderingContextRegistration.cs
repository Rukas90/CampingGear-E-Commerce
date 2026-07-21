using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Shared.Infrastructure.Extensions;
using TrailStore.Shared.Infrastructure.Outbox;

namespace TrailStore.Ordering.Infrastructure.Database;

public static class OrderingContextRegistration
{
    public static void AddOrderingContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddModuleDbContext<OrderingDbContext, IOrderingUnitOfWork>(configuration, DbDefaults.DefaultSchema, 
        (sp, options) => 
        {
            var outboxInterceptor = sp.GetRequiredService<OutboxSignalInterceptor<IOrderingOutbox>>();
            options.AddInterceptors(outboxInterceptor);
        });
}