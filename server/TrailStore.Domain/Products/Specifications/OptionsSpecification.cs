using System.Linq.Expressions;
using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Products.Specifications;

public class OptionsSpecification(IReadOnlyList<OptionFilter> options) : ISpecification<Product>
{
    public Expression<Func<Product, bool>> ToExpression() =>
        product => product.Skus.Any(sku =>
            sku.Options.Any(skuOption =>
                options.Any(option =>
                    option.GroupSlug == skuOption.OptionGroup.Slug &&
                    option.ValueSlug == skuOption.Slug)));
}