using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Cumulus;

public sealed class Teneqa850
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:       "Teneqa 850",
        slug:       "cumulus-teneqa-850",
        brandId:    Brands.Cumulus.Id,
        categoryId: Categories.SleepingBags.Id);
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "CLMS-TENEQA850-LFT",
            price: 565.00m,
            stock: 0,
            options: [ZipOption.Left]),
        
        Sku.Create(
            productId: Product.Id,
            code: "CLMS-TENEQA850-RGT",
            price: 565.00m,
            stock: 0,
            options: [ZipOption.Right]),
    ];
}