using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public class Category : IModel<Category>
{
    public required Id<Category>      Id          { get; init; }
    public required Id<CategoryGroup> GroupId     { get; init; }
    public required string            Name        { get; init; }
    public          string            Description { get; init; } = string.Empty;
    public required string            Slug        { get; init; }
    public          string?           ImageUrl    { get; init; }

    public CategoryGroup        Group    { get; private set; } = null!;
    public ICollection<Product> Products { get; private set; } = [];
    
    public static Category Create(Id<CategoryGroup> groupId, string name, string slug, string description = "", string? imageUrl = null)
        => new()
        {
            Id          = Id<Category>.Part(slug).Build(),
            GroupId     = groupId,
            Name        = name,
            Slug        = slug,
            Description = description,
            ImageUrl    = imageUrl
        };
}