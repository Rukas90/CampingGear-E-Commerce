using System.Linq.Expressions;
using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Products;

public interface IProductsRepository
{
    Task<TResult?> GetByIdAsync<TResult>(
        Specification<Product> specification, Expression<Func<Product, TResult>> selector);
    
    Task<List<TResult>> ListAsync<TResult>(
        ProductsQuery query, Expression<Func<Product, TResult>> selector);
}