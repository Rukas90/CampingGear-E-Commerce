using TrailStore.Shared.Domain.Events;

namespace TrailStore.Payments.Contracts.IntegrationEvents;

public sealed record PaymentCanceledIntegrationEvent(Guid PaymentId, Guid ReferenceId) : IntegrationEvent;