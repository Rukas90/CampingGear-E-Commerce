using TrailStore.Shared.Domain.Events;

namespace TrailStore.Ordering.Contracts.IntegrationEvents;

public sealed record OrderCreatedIntegrationEvent(Guid CartId, Guid? UserId) : IntegrationEvent;