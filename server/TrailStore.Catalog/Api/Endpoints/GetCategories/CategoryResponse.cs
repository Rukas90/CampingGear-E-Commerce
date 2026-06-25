namespace TrailStore.Catalog.Api.Endpoints.GetCategories;

public sealed class CategoryResponse
{
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required string GroupSlug { get; init; }
    public required string Slug { get; init; }
    public string? ImageUrl { get; init; }
}