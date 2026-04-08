using TrailStore.Domain.Models;

namespace TrailStore.Domain.Products;

public interface IProductsService
{
    public Task<List<Product>> QueryProducts(ProductsFilter filter);
}