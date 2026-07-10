using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Payments.Application.Results;

public sealed class PaymentAttemptResult
{
    public required Id<PaymentAttempt> Id { get; init; }
}