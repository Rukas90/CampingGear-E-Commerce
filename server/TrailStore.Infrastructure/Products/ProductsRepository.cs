using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Enums;
using TrailStore.Domain.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Products;

public interface IProductsRepository
{
    Task<TResult?> GetByIdAsync<TResult>(
        Specification<Product> specification, Expression<Func<Product, TResult>> selector);
    
    Task<List<TResult>> ListAsync<TResult>(
        ProductsQuery query, Expression<Func<Product, TResult>> selector);
}
public sealed class ProductsRepository(AppDbContext context) : IProductsRepository
{
    public async Task<TResult?> GetByIdAsync<TResult>(
        Specification<Product> specification, Expression<Func<Product, TResult>> selector)
    {
        var queryable = context.Products.AsQueryable();

        return await queryable
            .Where(specification.ToExpression())
            .Select(selector)
            .FirstOrDefaultAsync();
    }
    public async Task<List<TResult>> ListAsync<TResult>(ProductsQuery query, Expression<Func<Product, TResult>> selector)
    {
        var queryable = context.Products.AsQueryable();

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
            .ToListAsync();
    }
    
    private static IQueryable<Product> GetOrderedQueryable(IQueryable<Product> query, SortBy sortBy)
    {
        return sortBy switch
        {
            SortBy.PriceAscending  => query.OrderBy(p => p.Skus.Min(s => s.UnitPrice)),
            SortBy.PriceDescending => query.OrderByDescending(p => p.Skus.Min(s => s.UnitPrice)),
            SortBy.TitleAscending  => query.OrderBy(p => p.Name),
            SortBy.TitleDescending => query.OrderByDescending(p => p.Name),
            //SortBy.BestSelling     => query.OrderByDescending(p => p.Skus.Sum(s => s.OrderCount)), // TODO e.g.
            _                      => query.OrderBy(p => p.Name)
        };;
    }
}