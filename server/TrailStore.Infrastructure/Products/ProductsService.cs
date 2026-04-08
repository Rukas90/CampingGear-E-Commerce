using TrailStore.Domain.Models;
using TrailStore.Domain.Products;

namespace TrailStore.Infrastructure.Products;

public class ProductsService : IProductsService
{
    public async Task<List<Product>> QueryProducts(ProductsFilter filter)
    {
        return [];
    }
}