using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Cumulus;

public sealed class Teneqa700
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:       "Teneqa 700",
        slug:       "cumulus-teneqa-700",
        brandId:    Brands.Cumulus.Id,
        categoryId: Categories.SleepingBags.Id);
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "CLMS-TENEQA700-LFT",
            price: 515.00m,
            stock: 0,
            options: [ZipOption.Left]),
        
        Sku.Create(
            productId: Product.Id,
            code: "CLMS-TENEQA700-RGT",
            price: 515.00m,
            stock: 0,
            options: [ZipOption.Right]),
    ];
}