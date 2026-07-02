using TrailStore.Catalog.Domain.Options;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Skus;

public class Sku : IModel<Sku>
{
    public required Id<Sku> Id { get; init; }
    public required Id<Product> ProductId { get; init; }
    public required SkuCode Code { get; init; }
    public required decimal UnitPrice { get; init; }
    public required int Stock { get; set; }

    public ICollection<Option> Options { get; init; } = [];
    public Product Product { get; private set; } = null!;
    
    public string VariantLine => string.Join(", ", Options.Select(option => $"{option.OptionGroup.Name}: {option.Name}"));
    
    public static Sku Create(
        Id<Product> productId,
        string code,
        decimal price,
        int stock,
        ICollection<Option> options)
    {
        return new Sku
        {
            Id = Id<Sku>.Part(code).Build(),
            ProductId = productId,
            Code = SkuCode.Create(code),
            UnitPrice = price,
            Stock = stock,
            Options = options
        };
    }
}