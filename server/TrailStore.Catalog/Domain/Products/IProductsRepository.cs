using System.Linq.Expressions;
using TrailStore.Catalog.Domain.Filters;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Catalog.Domain.Products;

public interface IProductsRepository : IAggregateRepository<Product>
{
    Task<Product?> GetFullProductAsync(string slug, CancellationToken ct);

    Task<List<TResult>> ListAsync<TResult>(
        ProductsQuery query, Expression<Func<Product, TResult>> selector, CancellationToken ct);
}