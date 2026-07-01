using TrailStore.Shared.Domain.Events;

namespace TrailStore.Inventory.Contracts.IntegrationEvents;

public sealed record StockChangedIntegrationEvent(Guid SkuId, int Stock) : IntegrationEvent;