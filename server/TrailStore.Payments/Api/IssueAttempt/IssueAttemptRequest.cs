namespace TrailStore.Payments.Api.IssueAttempt;

public sealed class IssueAttemptRequest
{
    public Guid PaymentId { get; init; }
}