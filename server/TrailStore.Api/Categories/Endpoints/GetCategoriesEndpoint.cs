using FastEndpoints;
using TrailStore.Api.Categories.Dto;
using TrailStore.Api.Categories.Mapping;
using TrailStore.Domain.Categories.Interfaces;

namespace TrailStore.Api.Categories.Endpoints;

public class GetCategoriesEndpoint(ICategoriesRepository categoriesRepository)
    : EndpointWithoutRequest<IEnumerable<CategoryDto>>
{
    public override void Configure()
    {
        Get("/api/v1/categories");
        AllowAnonymous();
    }

    public override async Task<IEnumerable<CategoryDto>> ExecuteAsync(CancellationToken ct)
    {
        return (await categoriesRepository.ListAllCategoriesAsync(ct)).ToDto();
    }
}