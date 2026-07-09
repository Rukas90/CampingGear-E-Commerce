using System.Text.Json;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Domain.Events;

namespace TrailStore.Shared.Domain.Messages;

public sealed class OutboxMessage : IModel<OutboxMessage>
{
    public Id<OutboxMessage> Id { get; init; }
    public required string Type { get; init; }
    public required string Payload { get; init; }
    public required DateTime OccurredAt { get; init; }
    public DateTime? ProcessedAt { get; set; }
    public int RetryCount { get; set; }
    public string? LastError { get; set; }

    public static OutboxMessage Create(IntegrationEvent evt)
        => new()
        {
            Id = Id<OutboxMessage>.New(),
            Type = evt.GetType().AssemblyQualifiedName!,
            Payload = JsonSerializer.Serialize(evt, evt.GetType()),
            OccurredAt = DateTime.UtcNow
        };
    
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