using FastEndpoints;
using TrailStore.Api.Products.Dto;
using TrailStore.Api.Products.Mapping;
using TrailStore.Domain.Products.Interfaces;
using TrailStore.Domain.Products.Specifications;

namespace TrailStore.Api.Products.Endpoints;

public class GetProductEndpoint(IProductsRepository productsRepository)
    : Endpoint<ProductRequest, ProductDetailDto>
{
    public override void Configure()
    {
        Get("/api/v1/products/{slug}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ProductRequest req, CancellationToken ct)
    {
        var product = await productsRepository.GetFullProductAsync(
            ProductSpecifications.Slug(req.Slug));

        if (product is null)
        {
            await new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Detail = $"Product was not found by slug '{req.Slug}'"
            }.ExecuteAsync(HttpContext);

            return;
        }

        var dto = product.ToDetailDto();

        Console.WriteLine(dto.Description);
        
        await Send.OkAsync(dto, ct);
    }
}