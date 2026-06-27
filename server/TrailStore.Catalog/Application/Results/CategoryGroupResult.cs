namespace TrailStore.Catalog.Application.Results;

public sealed class CategoryGroupResult
{
    public required string Name { get; init; }
    public required string Slug { get; init; }
    public required int SortOrder { get; init; }
}