namespace TrailStore.Payments.Application.Results;

public sealed class PaymentResult
{
    public required Guid Id { get; init; }
    public required string ClientSecret { get; init; }
    public required bool IsComplete { get; init; }
    public required int AttemptsRemaining { get; init; }
}