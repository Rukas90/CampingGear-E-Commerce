namespace TrailStore.Payments.Api.GetPayment;

public sealed class PaymentResponse
{
    public required Guid PaymentId { get; init; }
    public required string ClientSecret { get; init; }
    public required bool IsComplete { get; init; }
    public required int AttemptsRemaining { get; init; }
}