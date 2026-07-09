using TrailStore.Shared.Domain.Events;

namespace TrailStore.Shared.Domain.Messages;

public interface IOutboxWriter
{
    void Enqueue<TEvent>(TEvent evt) where TEvent : IntegrationEvent;
}