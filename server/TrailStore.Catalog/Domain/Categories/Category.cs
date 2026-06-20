using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Categories;

public sealed class Category : IModel<Category>
{
    public required Id<Category> Id { get; init; }
    public required Id<CategoryGroup> GroupId { get; init; }
    public required string Name { get; init; }
    public string Description { get; init; } = string.Empty;
    public required string Slug { get; init; }
    public string? ImageUrl { get; init; }
    
    public static Category Create(
        Id<CategoryGroup> groupId, string name, string slug, string description = "", string? imageUrl = null)
    {
        return new Category
        {
            Id = Id<Category>.Part(slug).Build(),
            GroupId = groupId,
            Name = name,
            Slug = slug,
            Description = description,
            ImageUrl = imageUrl
        };
    }
}