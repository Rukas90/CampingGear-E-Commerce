using TrailStore.Catalog.Application.Results;
using TrailStore.Catalog.Domain.Categories;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Catalog.Application.Queries.GetCategories;

[AppService<GetAllCategoriesQueryHandler>]
public sealed class GetAllCategoriesQueryHandler(ICategoryRepository categoriesRepository)
    : IQueryWithoutRequestHandler<CategoryResult[]>
{
    public async Task<Result<CategoryResult[]>> Handle(CancellationToken ct)
    {
        var categories = await categoriesRepository.ListAllCategoriesAsync(ct);

        return categories.Select(category => new CategoryResult
        {
            Name = category.Name,
            Description = category.Description,
            GroupSlug = category.Group.Slug,
            ImageUrl = category.ImageUrl,
            Slug = category.Slug
        }).ToArray();
    }
}