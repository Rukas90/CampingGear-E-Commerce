using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Catalog.Infrastructure.Database;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Catalog.Infrastructure.Products;

[AppService<IProductsRepository>]
public sealed class ProductsRepository(CatalogDbContext _context) 
    : AggregateRepository<Product, CatalogDbContext>(_context), IProductsRepository
{
    public Task<Product?> FindBySkuAsync(Id<Sku> skuId, CancellationToken ct)
        => AggregateWriteQuery
            .Where(product => product.Skus.Any(sku => sku.Id == skuId))
            .SingleOrDefaultAsync(ct);

    public Task<Id<Product>?> GetIdFromSlug(Slug productSlug, CancellationToken ct)
        => ReadQuery
            .Where(product => product.Slug == productSlug)
            .Select(product => (Id<Product>?)product.Id)
            .SingleOrDefaultAsync(ct);

    public async Task<Product?> GetFullProductAsync(Slug slug, CancellationToken ct)
    {
        return await AggregateReadQuery 
            .Where(product => product.Slug == slug)
            .FirstOrDefaultAsync(ct);
    }

    public async Task<List<TResult>> ListAsync<TResult>(ProductsQuery query,
        Expression<Func<Product, TResult>> selector, CancellationToken ct)
    {
        var queryable = ReadQuery.AsQueryable();

        if (query.Specification is not null)
        {
            queryable = queryable.Where(query.Specification.ToExpression());
        }
        
        queryable = GetOrderedQueryable(queryable, query.SortBy);
        
        queryable = query.Pagination
            ? queryable.Skip(query.Page * query.PageSize).Take(query.PageSize)
            : queryable;

        return await queryable
            .Select(selector)
            .ToListAsync(ct);
    }

    private static IQueryable<Product> GetOrderedQueryable(IQueryable<Product> query, ProductsSortBy sortBy)
    {
        return sortBy switch
        {
            ProductsSortBy.PriceAscending => query.OrderBy(p => p.Skus.Min(s => s.UnitPrice)),
            ProductsSortBy.PriceDescending => query.OrderByDescending(p => p.Skus.Min(s => s.UnitPrice)),
            ProductsSortBy.TitleAscending => query.OrderBy(p => p.Name),
            ProductsSortBy.TitleDescending => query.OrderByDescending(p => p.Name),
            _ => query.OrderBy(p => p.Name)
        };
    }

    protected override IQueryable<Product> BuildAggregateQuery(DbSet<Product> set)
        => set
            .Include(product => product.Brand)
            .Include(product => product.Category)
            .Include(product => product.Images)
            .ThenInclude(image => image.Urls)
            .Include(product => product.Skus)
            .ThenInclude(sku => sku.Options).ThenInclude(option => option.OptionGroup);
}