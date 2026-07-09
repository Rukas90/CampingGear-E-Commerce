using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Domain.Messages;

namespace TrailStore.Shared.Infrastructure.Outbox;

public class OutboxMessages(DbSet<OutboxMessage> messages) : IOutboxMessages
{
    public Task<OutboxMessage[]> QueryUnprocessed(int takeCount = 20, CancellationToken ct = default)
        => messages
            .Where(m => m.ProcessedAt == null)
            .OrderBy(m => m.OccurredAt)
            .Take(takeCount)
            .ToArrayAsync(ct);
}