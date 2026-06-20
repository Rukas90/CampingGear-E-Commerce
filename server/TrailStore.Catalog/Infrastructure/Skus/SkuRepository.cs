using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Catalog.Infrastructure.Database;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Catalog.Infrastructure.Skus;

[AppService<ISkuRepository>]
public class SkuRepository(CatalogDbContext context) : ISkuRepository
{
    public Task<List<TResult>> ListAllAsync<TResult>(
        Specification<Sku> specification, Expression<Func<Sku, TResult>> selector, CancellationToken ct)
    {
        return context.Skus.AsNoTracking()
            .Where(specification.ToExpression())
            .Select(selector)
            .ToListAsync(ct);
    }

    public Task<Sku?> FindByCodeAsync(SkuCode code, CancellationToken ct)
    {
        return context.Skus.AsNoTracking()
            .AsQueryable()
            .Where(s => s.Code == code)
            .FirstOrDefaultAsync(ct);
    }
}