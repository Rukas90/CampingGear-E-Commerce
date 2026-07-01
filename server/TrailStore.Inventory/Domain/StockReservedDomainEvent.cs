using TrailStore.Shared.Domain.Events;

namespace TrailStore.Inventory.Domain;

internal sealed record StockReservedDomainEvent(Guid SkuId, int AvailableStock) : DomainEvent;