using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Events;

namespace TrailStore.Shared.Domain.Common;

public abstract class AggregateRoot<TModel> : IModel<TModel>, IHasDomainEvents
{
    public Id<TModel> Id { get; set; }

    private readonly List<DomainEvent> domainEvents = [];
    public IReadOnlyList<DomainEvent> DomainEvents => domainEvents;

    protected void RaiseDomainEvent(DomainEvent domainEvent) =>
        domainEvents.Add(domainEvent);

    public void ClearDomainEvents() => 
        domainEvents.Clear();
}