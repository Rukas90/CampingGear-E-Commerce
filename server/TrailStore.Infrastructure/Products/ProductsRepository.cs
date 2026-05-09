using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Enums;
using TrailStore.Domain.Models;
using TrailStore.Domain.Products;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Products;

[AppService<IProductsRepository>]
public sealed class ProductsRepository(AppDbContext context) : IProductsRepository
{
    public async Task<TResult?> SelectAsync<TResult>(
        Specification<Product> specification, Expression<Func<Product, TResult>> selector)
    {
        var queryable = context.Products.AsQueryable();

        return await queryable
            .Where(specification.ToExpression())
            .Select(selector)
            .FirstOrDefaultAsync();
    }
    
    public async Task<Product?> GetFullProductAsync(
        Specification<Product> specification)
    {
        return await context.Products
            .Include(product => product.Brand)
            .Include(product => product.Category)
            .Include(product => product.Reviews)
            .Include(product => product.Images).ThenInclude(image => image.Urls)
            .Include(product => product.Skus).ThenInclude(sku => sku.Options).ThenInclude(option => option.OptionGroup)
            .Where(specification.ToExpression())
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
            //SortBy.BestSelling     => query.OrderByDescending(p => p.Skus.Sum(s => s.OrderCount)), // TODO
            _                      => query.OrderBy(p => p.Name)
        };
    }
}