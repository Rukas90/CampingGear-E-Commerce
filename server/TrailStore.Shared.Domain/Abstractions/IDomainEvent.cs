namespace TrailStore.Shared.Domain.Abstractions;

public interface IDomainEvent
{
    Guid Id { get; }
    DateTime OccurredAt { get; }
}