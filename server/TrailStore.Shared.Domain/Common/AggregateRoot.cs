using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Shared.Domain.Common;

public abstract class AggregateRoot<TModel> : IModel<TModel>
{
    public Id<TModel> Id { get; set; }

    private readonly List<IDomainEvent> domainEvents = [];
    public IReadOnlyList<IDomainEvent> DomainEvents => domainEvents;

    protected void RaiseDomainEvent(IDomainEvent domainEvent) =>
        domainEvents.Add(domainEvent);

    public void ClearDomainEvents() => domainEvents.Clear();
}