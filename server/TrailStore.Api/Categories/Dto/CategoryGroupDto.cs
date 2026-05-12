namespace TrailStore.Api.Categories.Dto;

public class CategoryGroupDto
{
    public required string Name { get; init; }
    public required string Slug { get; init; }
    public required int SortOrder { get; init; }
}