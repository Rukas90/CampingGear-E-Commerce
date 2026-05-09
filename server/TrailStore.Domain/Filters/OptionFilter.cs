using TrailStore.Domain.Models;

namespace TrailStore.Domain.Filters;

public class OptionFilter : FilterValue
{
    public required int SortOrder    { get; init; }
    public PreviewType? PreviewType  { get; init; }
    public string?      PreviewValue { get; init; }
}