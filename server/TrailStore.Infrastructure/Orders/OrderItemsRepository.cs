using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Orders;

[AppService<IOrderItemsRepository>]
public class OrderItemsRepository(AppDbContext context) : IOrderItemsRepository
{
    public Task<List<TResult>> ListMostSoldCategoriesAsync<TResult>(int count, Expression<Func<Category, TResult>> selector)
    {
        return context.Categories
            .GroupJoin(
                context.OrderItems,
                c  => c.Id,
                oi => oi.Sku.Product.CategoryId,
                (c, items) => new
                {
                    Category  = c,
                    TotalSold = items.Sum(oi => (int?)oi.Quantity) ?? 0
                })
            .OrderByDescending(x => x.TotalSold)
            .Take(count)
            .Select(x => x.Category)
            .Select(selector)
            .ToListAsync();
    }
}