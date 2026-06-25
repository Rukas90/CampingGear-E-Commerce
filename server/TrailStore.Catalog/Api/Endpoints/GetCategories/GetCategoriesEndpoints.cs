using FastEndpoints;
using TrailStore.Catalog.Domain.Categories;

namespace TrailStore.Catalog.Api.Endpoints.GetCategories;

public sealed class GetCategoriesEndpoints(ICategoryRepository categoriesRepository)
    : EndpointWithoutRequest<CategoryResponse[]>
{
    public override void Configure()
    {
        Get("/api/v1/categories");
        AllowAnonymous();
    }
    
    public override async Task<CategoryResponse[]> ExecuteAsync(CancellationToken ct)
    {
        return (await categoriesRepository.ListAllCategoriesAsync(ct)).ToResponses();
    }
}