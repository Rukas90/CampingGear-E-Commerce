using TrailStore.Domain.Models;
using TrailStore.Domain.Products;

namespace TrailStore.Infrastructure.Products;

public class ProductsService(IProductsRepository repository) : IProductsService
{
    public const int PRODUCTS_QUERY_PAGE_SIZE = 20;
    
    public Task<List<Product>> QueryProducts(ProductsFilter filter)
    {
        return repository.ListAsync(new ProductsQuery
        {
            Specification = ProductsSpecificationBuilder.Build(filter),
            SortBy        = filter.SortBy,
            Page          = filter.Page,
            PageSize      = PRODUCTS_QUERY_PAGE_SIZE
        });
    }
}