using FastEndpoints;
using TrailStore.Api.Categories.Dto;
using TrailStore.Api.Categories.Mapping;
using TrailStore.Domain.Categories;

namespace TrailStore.Api.Categories.Endpoints;

public class GetCategoryGroupsEndpoint(ICategoriesRepository categoriesRepository) 
    : EndpointWithoutRequest<IEnumerable<CategoryGroupDto>>
{
    public override void Configure()
    {
        Get("/api/v1/category/groups");
        AllowAnonymous();
    }

    public override async Task<IEnumerable<CategoryGroupDto>> ExecuteAsync(CancellationToken ct)
    {
        return (await categoriesRepository.ListAllCategoryGroupsAsync()).ToDto();
    }
}