using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Skus;

public interface ISkuRepository
{ 
    Task<List<TResult>> ListAllAsync<TResult>(
        Specification<Sku> specification, Expression<Func<Sku, TResult>> selector);
}

public class SkuRepository(AppDbContext context) : ISkuRepository
{
    public Task<List<TResult>> ListAllAsync<TResult>(
        Specification<Sku> specification, Expression<Func<Sku, TResult>> selector)
    {
        return context.Skus
            .Where(specification.ToExpression())
            .Select(selector)
            .ToListAsync();
    }
}