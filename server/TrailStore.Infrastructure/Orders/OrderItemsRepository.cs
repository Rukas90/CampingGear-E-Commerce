using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Models;
using TrailStore.Infrastructure.Data;

namespace TrailStore.Infrastructure.Orders;

public class OrderItemsRepository(AppDbContext context) : IOrderItemsRepository
{
    public Task<List<TResult>> ListMostSoldCategoriesAsync<TResult>(int count, Expression<Func<Category, TResult>> selector)
    {
        var queryable = context.OrderItems.AsQueryable();

        return queryable
            .GroupBy(oi => oi.Sku.Product.CategoryId)
            .Select(g => new
            {
                CategoryId = g.Key,
                TotalSold = g.Sum(oi => oi.Quantity)
            })
            .OrderByDescending(x => x.TotalSold)
            .Take(count)
            .Join(
                context.Categories,
                x => x.CategoryId,
                c => c.Id,
                (_, c) => c)
            .Select(selector)
            .ToListAsync();
    }
}