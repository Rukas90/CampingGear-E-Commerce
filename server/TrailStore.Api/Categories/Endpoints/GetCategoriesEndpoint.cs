using FastEndpoints;
using TrailStore.Api.Categories.Dto;
using TrailStore.Api.Categories.Mapping;
using TrailStore.Infrastructure.Categories;

namespace TrailStore.Api.Categories.Endpoints;

public class GetCategoriesEndpoint(ICategoriesRepository categoriesRepository) 
    : EndpointWithoutRequest<IEnumerable<CategoryDto>>
{
    public override void Configure()
    {
        Get("/api/v1/category");
        AllowAnonymous();
    }

    public override async Task<IEnumerable<CategoryDto>> ExecuteAsync(CancellationToken ct)
    {
        var categories = await categoriesRepository.ListAllAsync();
        return categories.ToDto();
    }
}