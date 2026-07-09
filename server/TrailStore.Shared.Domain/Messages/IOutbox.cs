namespace TrailStore.Shared.Domain.Messages;

public interface IOutbox : IOutboxWriter
{
    IOutboxMessages GetMessages();
    
    Task SaveAsync(CancellationToken ct);
}