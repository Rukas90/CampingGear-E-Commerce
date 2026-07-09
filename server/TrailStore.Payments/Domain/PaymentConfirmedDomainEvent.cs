using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Domain.Events;

namespace TrailStore.Payments.Domain;

public sealed record PaymentConfirmedDomainEvent(Id<Payment> PaymentId, Guid ReferenceId) : DomainEvent;