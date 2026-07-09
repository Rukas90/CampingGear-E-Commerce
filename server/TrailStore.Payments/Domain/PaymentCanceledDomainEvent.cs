using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Domain.Events;

namespace TrailStore.Payments.Domain;

public sealed record PaymentCanceledDomainEvent(Id<Payment> PaymentId, Guid ReferenceId) : DomainEvent;