using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Options;

public class OptionGroup : AggregateRoot<OptionGroup>
{
    public required string Name { get; init; }
    public required Slug Slug { get; init; }
    public int SortOrder { get; init; } = 0;
    
    private readonly List<Option> _options = [];
    public IReadOnlyList<Option> Options => _options;
    
    public static OptionGroup Create(string name, string slug, int sortOrder = 0)
    {
        return new OptionGroup
        {
            Id = Id<OptionGroup>.Part(slug).Build(),
            Name = name,
            Slug = Slug.Create(slug),
            SortOrder = sortOrder
        };
    }
}