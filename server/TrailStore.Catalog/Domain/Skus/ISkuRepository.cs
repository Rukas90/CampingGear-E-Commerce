using System.Linq.Expressions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Skus;

public interface ISkuRepository
{
    Task<List<TResult>> ListAllAsync<TResult>(
        Specification<Sku> specification, Expression<Func<Sku, TResult>> selector, CancellationToken ct);
    
    Task<Sku?> FindByCodeAsync(SkuCode code, CancellationToken ct);
}