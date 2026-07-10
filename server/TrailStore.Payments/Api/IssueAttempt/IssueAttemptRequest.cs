namespace TrailStore.Payments.Api.CreateAttempt;

public sealed class IssueAttemptRequest
{
    public Guid PaymentId { get; init; }
}