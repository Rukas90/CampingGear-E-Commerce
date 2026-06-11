using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class Sku : IModel<Sku>
{
    public required Id<Sku> Id { get; init; }
    public required Id<Product> ProductId { get; init; }
    public required string Code { get; init; }
    public required decimal UnitPrice { get; init; }
    public required int Stock { get; set; }
    public int Reserved { get; private set; }

    public ICollection<Option> Options { get; init; } = [];
    public Product Product { get; private set; } = null!;
    
    public int AvailableStock => Stock - Reserved;
    
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
            Code = code.ToUpperInvariant(),
            UnitPrice = price,
            Stock = stock,
            Reserved = 0,
            Options = options
        };
    }

    public void Reserve(int quantity)
    {
        if (AvailableStock < quantity)
        {
            throw new InvalidOperationException("Cannot reserve more than the available stock.");
        }
        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than zero");
        }
        
        Reserved += quantity;
    }
}