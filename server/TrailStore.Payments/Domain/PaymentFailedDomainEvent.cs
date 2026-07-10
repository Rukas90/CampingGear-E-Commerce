using TrailStore.Shared.Domain.Events;

namespace TrailStore.Payments.Domain;

public sealed record PaymentFailedDomainEvent(Guid ReferenceId) : DomainEvent;