using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public class CategoryGroup : IModel<CategoryGroup>
{
    public          Id<CategoryGroup> Id        { get; init; }
    public required string            Name      { get; init; }
    public required string            Slug      { get; init; }
    public          int               SortOrder { get; init; }
    
    public ICollection<Category> Categories { get; private set; } = [];
    
    public static CategoryGroup Create(string name, string slug, int sortOrder = 0)
        => new()
        {
            Id        = Id<CategoryGroup>.Part(slug).Build(),
            Name      = name,
            Slug      = slug,
            SortOrder = sortOrder
        }; 
}