using TrailStore.Shared.Domain.Events;

namespace TrailStore.Payments.Contracts.IntegrationEvents;

public sealed record PaymentSucceededIntegrationEvent(Guid PaymentId, Guid ReferenceId) : IntegrationEvent;