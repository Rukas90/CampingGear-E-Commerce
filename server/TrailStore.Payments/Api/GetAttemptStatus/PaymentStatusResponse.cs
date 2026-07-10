using TrailStore.Payments.Domain;

namespace TrailStore.Payments.Api.GetAttemptStatus;

public class PaymentStatusResponse
{
    public PaymentStatus Status { get; init; }
}