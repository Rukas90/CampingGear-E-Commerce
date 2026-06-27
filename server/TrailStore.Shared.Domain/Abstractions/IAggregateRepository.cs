using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Domain.Abstractions;

public interface IAggregateRepository<TEntity> : IReadRepository<TEntity>
    where TEntity : AggregateRoot<TEntity>
{
    TEntity Add(TEntity entity);

    void Delete(TEntity entity);
}