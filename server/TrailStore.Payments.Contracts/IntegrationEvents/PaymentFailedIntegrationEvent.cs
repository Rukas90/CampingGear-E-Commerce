using TrailStore.Shared.Domain.Events;

namespace TrailStore.Payments.Contracts.IntegrationEvents;

public sealed record PaymentFailedIntegrationEvent(bool WasCanceled, Guid ReferenceId) : IntegrationEvent;