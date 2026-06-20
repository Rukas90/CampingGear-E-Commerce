using TrailStore.Catalog.Domain.Categories;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Shared.Domain.Common;

// ReSharper disable CollectionNeverUpdated.Local

namespace TrailStore.Catalog.Domain.Products;

public class Product : AggregateRoot<Product>
{
    public required string Name { get; init; }
    public string Description { get; init; } = string.Empty;
    public required string Slug { get; init; }
    public required Id<Category> CategoryId { get; init; }
    public required Id<Brand> BrandId { get; init; }
    public string? ThumbnailUrl { get; init; }

    public Brand Brand { get; init; } = null!;
    public Category Category { get; init; } = null!;
    public ICollection<ProductImage> Images { get; private set; } = [];
    
    private readonly List<Sku> _skus = [];
    public IReadOnlyList<Sku> Skus => _skus;

    public static Product Create(
        string name,
        string slug,
        Id<Category> categoryId,
        Id<Brand> brandId,
        string description = "",
        string thumbnailUrl = "")
    {
        return new Product
        {
            Id = Id<Product>.Part(slug).Build(),
            Name = name,
            Slug = slug,
            Description = description,
            CategoryId = categoryId,
            BrandId = brandId,
            ThumbnailUrl = thumbnailUrl
        };
    }
}