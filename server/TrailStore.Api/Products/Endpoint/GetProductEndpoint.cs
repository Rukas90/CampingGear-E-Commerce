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
        Get("/api/v1/products/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(ProductRequest req, CancellationToken ct)
    {
        var result = await productsRepository.GetByIdAsync(
            specification: ProductSpecifications.Id(req.Id ),
            selector:      ProductMappingSelectors.ToDetailDto());

        if (result is null)
        {
            await new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Detail = $"Product was not found by id '{req.Id.ToString()}'"
            }.ExecuteAsync(HttpContext);
            
            return;
        }
        await Send.OkAsync(result, ct);
    }
}