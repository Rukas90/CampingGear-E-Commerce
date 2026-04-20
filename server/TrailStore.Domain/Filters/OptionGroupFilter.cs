namespace TrailStore.Domain.Filters;

public class OptionGroupFilter : FilterValue
{
    public int            SortOrder { get; init; }
    public OptionFilter[] Options   { get; init; } = [];
}