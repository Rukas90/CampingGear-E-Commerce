namespace TrailStore.Domain.Filters.Models;

public class FilterValue
{
    public required string Name { get; init; }
    public required string Slug { get; init; }
    public required int Count { get; init; }
}