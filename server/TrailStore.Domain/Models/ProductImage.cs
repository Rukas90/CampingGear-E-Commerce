using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public class ProductImage : IModel<ProductImage>
{
    public Id<ProductImage>    Id        { get; init; }
    public Id<Product>         ProductId { get; init; }
    public Id<Option>?         OptionId  { get; init; }
    
    public ICollection<ProductImageUrl> Urls    { get; private set; } = [];
    public Product                      Product { get; private set; } = null!;
    
    public static ProductImage Create(
        Id<ProductImage>    id,
        Id<Product>         productId, 
        Id<Option>?         optionId, 
        ICollection<string> urls)
        => new()
        {
            Id           = id,
            ProductId    = productId,
            OptionId     = optionId,
            Urls         = urls.Select((url, i) => ProductImageUrl.Create(id, url, sortOrder: i)).ToList()
        };

    public static ProductImage Create(
        Id<Product>         productId,
        Id<Option>          optionId,
        ICollection<string> urls)
    {
        var id = Id<ProductImage>.Part(productId).Part(optionId).Build();
        
        return new ProductImage
        {
            Id           = id,
            ProductId    = productId,
            OptionId     = optionId,
            Urls         = urls.Select((url, i) => ProductImageUrl.Create(id, url, sortOrder: i)).ToList()
        };
    }
    
    public static ProductImage Create(
        Id<Product>         productId,
        ICollection<string> urls)
    {
        var id = Id<ProductImage>.Part(productId).Part("Standard").Build();
        
        return new ProductImage
        {
            Id           = id,
            ProductId    = productId,
            OptionId     = null,
            Urls         = urls.Select((url, i) => ProductImageUrl.Create(id, url, sortOrder: i)).ToList()
        };
    }
}