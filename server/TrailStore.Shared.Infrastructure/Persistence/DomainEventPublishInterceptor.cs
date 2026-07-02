using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Shared.Infrastructure.Persistence;

[AppService<DomainEventPublishInterceptor>]
public sealed class DomainEventPublishInterceptor(
    ILogger<DomainEventPublishInterceptor> logger,
    IEventPublisher eventPublisher) : SaveChangesInterceptor
{
    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken ct = default)
    {
        if (eventData.Context is not null)
        {
            await DispatchDomainEvents(eventData.Context, ct);
        }

        return result;
    }

    private async Task DispatchDomainEvents(DbContext context, CancellationToken ct)
    {
        var aggregates = context.ChangeTracker
            .Entries<IHasDomainEvents>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Count > 0)
            .ToArray();
        
        var domainEvents = aggregates
            .SelectMany(e => e.DomainEvents)
            .ToArray();
        
        foreach (var domainEvent in domainEvents)
        {
            logger.LogInformation("Executing domain event: {DomainEvent}", domainEvent.GetType().Name);
            
            await eventPublisher.PublishAsync(domainEvent, ct);
        }
        
        foreach (var aggregate in aggregates)
        {
            aggregate.ClearDomainEvents();
        }
    }
}