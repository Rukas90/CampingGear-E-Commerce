using System.Linq.Expressions;
using TrailStore.Domain.Products.Models;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Products.Interfaces;

public interface IProductsRepository
{
    Task<TResult?> SelectAsync<TResult>(
        Specification<Product> specification, Expression<Func<Product, TResult>> selector);

    Task<Product?> GetFullProductAsync(
        Specification<Product> specification);

    Task<List<TResult>> ListAsync<TResult>(
        ProductsQuery query, Expression<Func<Product, TResult>> selector);
}