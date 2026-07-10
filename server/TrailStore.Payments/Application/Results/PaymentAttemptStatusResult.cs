using TrailStore.Payments.Domain;

namespace TrailStore.Payments.Application.Results;

public sealed class PaymentAttemptStatusResult
{
    public required PaymentStatus Status { get; init; }
}