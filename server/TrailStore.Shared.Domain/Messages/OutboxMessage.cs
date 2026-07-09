using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Domain.Messages;

public sealed class OutboxMessage : AggregateRoot<OutboxMessage>
{
    public required string Type { get; init; }
    public required string Payload { get; init; }
    public required DateTime OccurredAt { get; init; }
    public DateTime? ProcessedAt { get; set; }
    public int RetryCount { get; set; }
    public string? LastError { get; set; }
    
    public void MarkAsProcessed()
    {
        ProcessedAt = DateTime.UtcNow;
    }

    public void MarkAsFailed(string error)
    {
        RetryCount++;
        LastError = error;
    }
}