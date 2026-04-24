using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public class OptionGroup : IModel<OptionGroup>
{
    public required Id<OptionGroup> Id        { get; init; }
    public required string          Name      { get; init; }
    public required string          Slug      { get; init; }
    public          int             SortOrder { get; init; } = 0;
    
    public IReadOnlyList<Option> Options { get; private set; } = [];

    public static OptionGroup Create(Id<OptionGroup> id, string name, string slug, int sortOrder = 0)
        => new()
        {
            Id        = id,
            Name      = name,
            Slug      = slug,
            SortOrder = sortOrder
        };
    
    public static OptionGroup Create(string name, string slug, int sortOrder = 0)
        => new()
        {
            Id        = Id<OptionGroup>.Part(name).Build(),
            Name      = name,
            Slug      = slug,
            SortOrder = sortOrder
        };
}