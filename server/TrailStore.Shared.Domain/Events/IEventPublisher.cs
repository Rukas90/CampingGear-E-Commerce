namespace TrailStore.Shared.Domain.Events;

public interface IEventPublisher
{
    Task PublishAsync<TEvent>(TEvent evt, CancellationToken ct) where TEvent : IEvent;
}