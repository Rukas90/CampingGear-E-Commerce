namespace TrailStore.Shared.Domain.Messages;

public interface IOutboxMessages
{
    Task<OutboxMessage[]> QueryUnprocessed(int takeCount = 20, CancellationToken ct = default);
}