using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Products.Deuter;

public sealed class AircontactPro7510
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:       "Aircontact Pro 75+10",
        slug:       "deuter-aircontact-pro-75-10",
        brandId:    Brands.Deuter.Id,
        categoryId: Categories.Backpacks.Id);
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "DEUT-AIRCTPRO7510-STD",
            price: 420.00m,
            stock: 4,
            options: []),
    ];
}