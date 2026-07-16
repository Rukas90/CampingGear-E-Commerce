using TrailStore.Catalog.Domain.Categories;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Shared.Domain.Common;

// ReSharper disable CollectionNeverUpdated.Local

namespace TrailStore.Catalog.Domain.Products;

public class Product : AggregateRoot<Product>
{
    public required string Name { get; init; }
    public string Description { get; init; } = string.Empty;
    public required Slug Slug { get; init; }
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
            Slug = Slug.Create(slug),
            Description = description,
            CategoryId = categoryId,
            BrandId = brandId,
            ThumbnailUrl = thumbnailUrl
        };
    }

    public Result UpdateStock(Id<Sku> skuId, int newStock)
    {
        var sku = FindSku(skuId);

        if (sku is null)
        {
            return ProductProblems.SkuNotFound(Name, skuId);
        }

        if (newStock < 0)
        {
            return ProductProblems.InvalidSkuStock(newStock);
        }
        
        sku.Stock = newStock;

        return Result.Ok();
    }
    
    public string? GetThumbnailUrl(Id<Sku> skuId)
    {
        var sku = FindSku(skuId);

        if (sku is null)
        {
            return null;
        }

        var imageOption = sku.Options.FirstOrDefault(option =>
            Images.Any(image => image.OptionId == option.Id));
            
        var productImage = imageOption is not null
            ? Images.FirstOrDefault(img => img.OptionId == imageOption.Id)
            : null;

        var url = productImage?.Urls
            .OrderBy(u => u.SortOrder)
            .FirstOrDefault()?.Url;
        
        return url ?? ThumbnailUrl;
    }

    private Sku? FindSku(Id<Sku> skuId)
        => Skus.FirstOrDefault(sku => sku.Id == skuId);
}