using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Domain.Abstractions;

public interface IReadRepository<TEntity> where TEntity : class, IModel<TEntity>
{
    Task<TEntity?> FindAsync(Id<TEntity> id, CancellationToken ct);
}