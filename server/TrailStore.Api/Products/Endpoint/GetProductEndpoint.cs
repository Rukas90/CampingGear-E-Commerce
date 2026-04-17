using FastEndpoints;
using TrailStore.Api.Products.Dto;
using TrailStore.Api.Products.Mapping;
using TrailStore.Domain.Products;
using TrailStore.Infrastructure.Products;

namespace TrailStore.Api.Products.Endpoint;

public class GetProductEndpoint(IProductsRepository productsRepository) 
    : Endpoint<ProductRequest, ProductDetailDto>
{
    public override void Configure()
    {
        Get("/api/v1/product/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(ProductRequest req, CancellationToken ct)
    {
        var result = await productsRepository.GetByIdAsync(
            specification: ProductSpecifications.Id(req.Id ),
            selector:      ProductMappingExpressions.ToDetailDto());

        if (result is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        await Send.OkAsync(result, ct);
    }
}