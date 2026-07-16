using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Catalog.Infrastructure.Database;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Catalog.Infrastructure.Skus;

[AppService<ISkuRepository>]
public class SkuRepository(CatalogDbContext _context) : ReadRepository<Sku, CatalogDbContext>(_context), ISkuRepository
{
    public Task<List<TResult>> ListAllAsync<TResult>(
        Specification<Sku> specification, Expression<Func<Sku, TResult>> selector, CancellationToken ct)
        => ReadQuery.AsNoTracking()
            .Where(specification.ToExpression())
            .Select(selector)
            .ToListAsync(ct);

    public Task<List<Sku>> ListAllAsync(Specification<Sku> specification, CancellationToken ct)
        => ReadQuery.AsNoTracking()
            .Where(specification.ToExpression())
            .ToListAsync(ct);

    public Task<Sku?> FindByCodeAsync(SkuCode code, CancellationToken ct)
        => ReadQuery.AsNoTracking()
            .AsQueryable()
            .Where(s => s.Code == code)
            .FirstOrDefaultAsync(ct);

    protected override IQueryable<Sku> BuildAggregateQuery(DbSet<Sku> set)
        => set
            .Include(sku => sku.Options)
            .ThenInclude(option => option.OptionGroup)
            .Include(sku => sku.Product)
            .ThenInclude(product => product.Brand)
            .Include(sku => sku.Product)
            .ThenInclude(product => product.Category)
            .Include(sku => sku.Product)
            .ThenInclude(product => product.Images)
            .ThenInclude(image => image.Urls);
}