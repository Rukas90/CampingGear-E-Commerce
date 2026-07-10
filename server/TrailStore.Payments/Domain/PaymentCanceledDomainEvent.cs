using TrailStore.Shared.Domain.Events;

namespace TrailStore.Payments.Domain;

public sealed record PaymentCanceledDomainEvent(Guid ReferenceId) : DomainEvent;