using System.Linq.Expressions;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Skus.Interfaces;

public interface ISkuRepository
{
    Task<List<TResult>> ListAllAsync<TResult>(
        Specification<Sku> specification, Expression<Func<Sku, TResult>> selector);
}