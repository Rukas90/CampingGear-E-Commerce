using System.Linq.Expressions;
using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Products.Specifications;

public class PriceSpecification(decimal min, decimal max) : ISpecification<Product>
{
    public Expression<Func<Product, bool>> ToExpression() => 
        product => product.Skus.Any(sku => sku.UnitPrice >= min && sku.UnitPrice <= max); 
}