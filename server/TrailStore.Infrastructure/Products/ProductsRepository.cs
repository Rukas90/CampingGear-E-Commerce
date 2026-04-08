using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Enums;
using TrailStore.Domain.Models;
using TrailStore.Infrastructure.Data;

namespace TrailStore.Infrastructure.Products;

public interface IProductsRepository
{
    Task<List<Product>> ListAsync(ProductsQuery query);
}
public sealed class ProductsRepository(AppDbContext context) : IProductsRepository
{
    public async Task<List<Product>> ListAsync(ProductsQuery query)
    {
        var queryable = context.Products.AsQueryable();

        if (query.Specification is not null)
        {
            queryable = queryable.Where(query.Specification.ToExpression());
        }
        
        queryable = GetOrderedQueryable(queryable, query.SortBy);
        
        return await queryable
            .Skip(query.Page * query.PageSize)
            .Take(query.PageSize)
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