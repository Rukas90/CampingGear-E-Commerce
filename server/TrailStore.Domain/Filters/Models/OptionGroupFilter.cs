namespace TrailStore.Domain.Filters.Models;

public class OptionGroupFilter
{
    public required string Name { get; init; }
    public required string Slug { get; init; }
    public int SortOrder { get; init; }
    public OptionFilter[] Options { get; init; } = [];
}