using TrailStore.Shared.Domain.Events;

namespace TrailStore.Payments.Contracts.IntegrationEvents;

public sealed record PaymentRefundedIntegrationEvent(Guid PaymentId) : IntegrationEvent;