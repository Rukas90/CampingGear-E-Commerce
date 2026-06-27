using TrailStore.Catalog.Application.Results;
using TrailStore.Catalog.Domain.Categories;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Catalog.Application.Queries.GetCategories;

[AppService<GetCategoryGroupsQueryHandler>]
public sealed class GetCategoryGroupsQueryHandler(ICategoryGroupsRepository categoryGroupsRepository)
    : IQueryWithoutRequestHandler<CategoryGroupResult[]>
{
    public async Task<Result<CategoryGroupResult[]>> Handle(CancellationToken ct)
    {
        var groups = await categoryGroupsRepository.ListAsync(ct);

        return groups.Select(group => new CategoryGroupResult
        {
            Name = group.Name,
            Slug = group.Slug,
            SortOrder = group.SortOrder,
        }).ToArray();
    }
}