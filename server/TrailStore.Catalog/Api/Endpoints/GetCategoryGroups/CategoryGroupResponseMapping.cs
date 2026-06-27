using TrailStore.Catalog.Application.Results;

namespace TrailStore.Catalog.Api.Endpoints.GetCategoryGroups;

public static class CategoryGroupResponseMapping
{
    public static CategoryGroupResponse[] ToResponses(this ICollection<CategoryGroupResult> groups)
        => groups.Select(ToResponse).ToArray();

    public static CategoryGroupResponse ToResponse(this CategoryGroupResult group)
    {
        return new CategoryGroupResponse
        {
            Name = group.Name,
            Slug = group.Slug,
            SortOrder = group.SortOrder
        };
    }
}