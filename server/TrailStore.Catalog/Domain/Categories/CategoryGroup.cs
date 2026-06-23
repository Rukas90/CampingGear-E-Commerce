using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Categories;

public sealed class CategoryGroup : IModel<CategoryGroup>
{
    public required Id<CategoryGroup> Id { get; init; }
    public required string Name { get; init; }
    public required Slug Slug { get; init; }
    public int SortOrder { get; init; }

    public static CategoryGroup Create(string name, string slug, int sortOrder = 0)
    {
        return new CategoryGroup
        {
            Id = Id<CategoryGroup>.Part(slug).Build(),
            Name = name,
            Slug = Slug.Create(slug),
            SortOrder = sortOrder
        };
    }
}