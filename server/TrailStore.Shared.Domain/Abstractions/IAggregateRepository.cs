using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Domain.Abstractions;

public interface IAggregateRepository<TEntity> where TEntity : AggregateRoot<TEntity>
{
    Task<TEntity?> FindAsync(Id<TEntity> id, CancellationToken ct);

    void Add(TEntity entity);

    void Delete(TEntity entity);
}