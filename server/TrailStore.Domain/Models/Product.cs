using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public class Product : IModel<Product>
{
    public required Id<Product>        Id            { get; init; }
    public required string             Name          { get; init; }
    public string                      Description   { get; init; } = string.Empty;
    public required string             Slug          { get; init; }
    public required Id<Category>       CategoryId    { get; init; }
    public required Id<Brand>          BrandId       { get; init; }
    
    public ICollection<Review> Reviews  { get; private set; } = [];
    public ICollection<Sku>    Skus     { get; private set; } = [];
    public Category            Category { get; private set; } = null!;
    public Brand               Brand    { get; private set; } = null!;
    
    public static Product Create(
        Id<Product>  id,
        string       name, 
        string       slug, 
        Id<Category> categoryId,
        Id<Brand>    brandId,
        string       description = "")
        => new()
        {
            Id          = id,
            Name        = name,
            Slug        = slug,
            Description = description,
            CategoryId  = categoryId,
            BrandId     = brandId,
        };
    
    public static Product Create(
        string       name, 
        string       slug, 
        Id<Category> categoryId,
        Id<Brand>    brandId,
        string       description = "")
        => new()
        {
            Id          = Id<Product>.Part(slug).Build(),
            Name        = name,
            Slug        = slug,
            Description = description,
            CategoryId  = categoryId,
            BrandId     = brandId,
        };
}