using FastEndpoints;
using TrailStore.Api.Mapping;
using TrailStore.Api.Products.Dto;
using TrailStore.Domain.Models;
using TrailStore.Domain.Products;

namespace TrailStore.Api.Products.Endpoints;

public class GetProductsEndpoint(IProductsService productsService) 
    : Endpoint<ProductsRequest, List<Product>>
{
    public override void Configure()
    {
        Get("product");
        AllowAnonymous();
    }
    public override async Task<List<Product>> ExecuteAsync(ProductsRequest req, CancellationToken ct)
    {
        var products = await productsService.QueryProducts(req.MapToFilter());
        return products; //products.MapToResponseDto();
    }
}