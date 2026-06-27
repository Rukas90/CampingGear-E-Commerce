namespace TrailStore.Catalog.Api.Endpoints.GetCategoryGroups;

public class CategoryGroupResponse
{
    public required string Name { get; init; }
    public required string Slug { get; init; }
    public required int SortOrder { get; init; }
}