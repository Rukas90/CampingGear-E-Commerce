namespace TrailStore.Catalog.Application.Results;

public sealed class CategoryResult
{
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required string GroupSlug { get; init; }
    public required string Slug { get; init; }
    public string? ImageUrl { get; init; }
}