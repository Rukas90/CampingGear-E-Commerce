namespace TrailStore.Shared.Domain.Events;

public interface IEventHandler<in TEvent> : IEvent
{
    Task HandleAsync(TEvent evt, CancellationToken ct);
}