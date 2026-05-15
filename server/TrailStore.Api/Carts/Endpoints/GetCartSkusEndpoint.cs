using FastEndpoints;
using TrailStore.Api.Carts.Dto;
using TrailStore.Api.Carts.Mapping;
using TrailStore.Domain.Skus.Interfaces;
using TrailStore.Domain.Skus.Specifications;

namespace TrailStore.Api.Carts.Endpoints;

public class GetCartSkusEndpoint(ISkuRepository skuRepository) 
    : Endpoint<CartSkusRequest, IEnumerable<CartSkusDto>>
{
    public override void Configure()
    {
        Get("/api/v1/cart/skus");
        AllowAnonymous();
    }

    public override async Task<IEnumerable<CartSkusDto>> ExecuteAsync(CartSkusRequest req, CancellationToken ct)
    {
        return await skuRepository.ListAllAsync(
            SkuSpecificationBuilder.BuildFromCodes(req.Codes), 
            selector: CartMappingSelectors.ToCartSkuDto(), ct);
    }
}