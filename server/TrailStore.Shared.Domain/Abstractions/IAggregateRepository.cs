using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Domain.Abstractions;

public interface IAggregateRepository<TEntity> : IReadRepository<TEntity>
    where TEntity : AggregateRoot<TEntity>
{
    TEntity Add(TEntity entity);
    
    Task<TEntity?> FindReadOnlyAsync(Id<TEntity> id, CancellationToken ct);

    void Delete(TEntity entity);
}