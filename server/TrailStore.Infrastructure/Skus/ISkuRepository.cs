using System.Linq.Expressions;
using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Skus;

public interface ISkuRepository
{ 
    Task<List<TResult>> ListAllAsync<TResult>(
        Specification<Sku> specification, Expression<Func<Sku, TResult>> selector);
}