namespace TrailStore.Shared.Domain.Events;

public abstract record DomainEvent : IEvent
{
    public Guid Id { get; init; } = Guid.NewGuid();
}