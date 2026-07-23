using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Domain.Messages;

namespace TrailStore.Shared.Infrastructure.Outbox;

public interface IOutbox
{
    DbSet<OutboxMessage> Messages { get; }
    
    void AddMessage<TEvent>(TEvent evt) where TEvent : IntegrationEvent
        => Messages.Add(OutboxMessage.Create(evt));
    
    IOutboxMessages GetMessages()
        => new OutboxMessages(Messages);
    
    Task SaveAsync(CancellationToken ct);
}