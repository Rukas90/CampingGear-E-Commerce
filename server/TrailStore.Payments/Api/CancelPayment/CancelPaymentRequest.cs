namespace TrailStore.Payments.Api.CancelPayment;

public sealed class CancelPaymentRequest
{
    public required Guid PaymentId { get; init; }
}