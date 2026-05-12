using System.Security.Cryptography;
using System.Text;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class Sku : IModel<Sku>
{
    public required Id<Product> ProductId { get; init; }
    public required string Code { get; init; }
    public required decimal UnitPrice { get; init; }
    public required int Stock { get; set; }

    public ICollection<Option> Options { get; init; } = [];

    public OrderItem OrderItem { get; private set; } = null!;
    public Product Product { get; private set; } = null!;

    public string CodeHash =>
        Convert.ToHexString(MD5.HashData(Encoding.UTF8.GetBytes(Code)))[..10].ToLower();

    public required Id<Sku> Id { get; init; }

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
            Code = code,
            UnitPrice = price,
            Stock = stock,
            Options = options
        };
    }
}