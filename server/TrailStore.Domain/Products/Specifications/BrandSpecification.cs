using System.Linq.Expressions;
using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Products.Specifications;

public class BrandSpecification(string slug) : ISpecification<Product>
{
    public Expression<Func<Product, bool>> ToExpression() => 
        product => product.Brand.Slug == slug; 
}