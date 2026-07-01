namespace TrailStore.Shared.Domain.Events;

public abstract record IntegrationEvent : IEvent
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
}