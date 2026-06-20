using TrailStore.Catalog.Domain.Filters;
using TrailStore.Catalog.Domain.Products;

namespace TrailStore.Catalog.Application.Abstractions;

public interface IProductsQueryBuilder
{
    ProductsQuery Build(ProductsFilter filter);
}