using FastEndpoints;
using TrailStore.Api.Categories.Dto;
using TrailStore.Api.Categories.Mapping;
using TrailStore.Domain.Orders.Interfaces;

namespace TrailStore.Api.Categories.Endpoints;

public class GetTopCategoriesEndpoint(IOrderItemsRepository orderItemsRepository)
    : Endpoint<TopCategoriesRequest, IEnumerable<CategoryDto>>
{
    public override void Configure()
    {
        Get("/api/v1/categories/top");
        AllowAnonymous();
    }

    public override async Task<IEnumerable<CategoryDto>> ExecuteAsync(
        TopCategoriesRequest req, CancellationToken ct)
    {
        return await orderItemsRepository.ListMostSoldCategoriesAsync(
            req.Count, CategoryMappingSelectors.ToDto, ct);
    }
}