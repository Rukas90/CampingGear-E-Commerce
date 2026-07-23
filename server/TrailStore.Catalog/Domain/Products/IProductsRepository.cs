using System.Linq.Expressions;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Products;

public interface IProductsRepository : IAggregateRepository<Product>
{
    Task<Product?> FindBySkuAsync(Id<Sku> skuId, CancellationToken ct);
    
    Task<List<Product>> FindAllFromSkuIdsAsync(IEnumerable<Id<Sku>> skuIds, CancellationToken ct);
    
    Task<Id<Product>?> GetIdFromSlug(Slug productSlug, CancellationToken ct);
    
    Task<Product?> GetFullProductAsync(Slug slug, CancellationToken ct);

    Task<List<TResult>> ListAsync<TResult>(
        ProductsQuery query, Expression<Func<Product, TResult>> selector, CancellationToken ct);
}