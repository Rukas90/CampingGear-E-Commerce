using TrailStore.Inventory.Contracts.IntegrationEvents;
using TrailStore.Inventory.Domain;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Inventory.Application.EventHandlers;

[AppService<IEventHandler<StockReservedDomainEvent>>]
internal sealed class StockReservedDomainEventHandler(IEventPublisher publisher) 
    : IEventHandler<StockReservedDomainEvent>
{
    public Task HandleAsync(StockReservedDomainEvent evt, CancellationToken ct)
        => publisher.PublishAsync(new ItemStockChangedIntegrationEvent(evt.SkuId, evt.AvailableStock), ct);
}