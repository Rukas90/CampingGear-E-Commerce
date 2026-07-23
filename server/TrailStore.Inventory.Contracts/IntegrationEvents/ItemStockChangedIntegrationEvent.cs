using TrailStore.Shared.Domain.Events;

namespace TrailStore.Inventory.Contracts.IntegrationEvents;

public sealed record ItemStockChangedIntegrationEvent(Guid SkuId, int Stock) : IntegrationEvent;