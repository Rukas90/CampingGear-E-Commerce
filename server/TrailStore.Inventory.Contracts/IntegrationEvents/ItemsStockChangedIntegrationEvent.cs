using TrailStore.Shared.Domain.Events;

namespace TrailStore.Inventory.Contracts.IntegrationEvents;

public sealed record ItemsStockChangedIntegrationEvent(
    IReadOnlyCollection<ItemChangedStock> ChangedItems) : IntegrationEvent;