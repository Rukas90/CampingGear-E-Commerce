using System.Linq.Expressions;
using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Products.Specifications;

public class OutOfStockSpecification : ISpecification<Product>
{
    public Expression<Func<Product, bool>> ToExpression() => 
        product => product.Skus.All(sku => sku.Stock <= 0); 
}