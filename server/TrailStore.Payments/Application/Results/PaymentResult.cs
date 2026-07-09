namespace TrailStore.Payments.Application.Results;

public sealed class PaymentResult
{
    public required string ClientSecret { get; init; }
}