using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Shared.Domain.Messages;
using TrailStore.Shared.Infrastructure.Outbox;

namespace TrailStore.Shared.Infrastructure.Extensions;

public static class OutboxRegistrationExtensions
{
    public static void AddOutbox<TOutbox, TContext>(this IServiceCollection services)
        where TOutbox : class, IOutbox where TContext : DbContext, TOutbox
    {
        services.AddScoped<TOutbox>(sp => sp.GetRequiredService<TContext>());
        services.AddHostedService<OutboxProcessor<TOutbox>>();
    }
}