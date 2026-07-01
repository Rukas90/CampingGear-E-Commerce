namespace TrailStore.Shared.Domain.Events;

public interface IHasDomainEvents
{
    public IReadOnlyList<DomainEvent> DomainEvents { get; }

    void ClearDomainEvents();
}