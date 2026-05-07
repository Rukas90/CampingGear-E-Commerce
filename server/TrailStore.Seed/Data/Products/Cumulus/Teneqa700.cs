using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Cumulus;

// ReSharper disable UnusedType.Global

public static class Teneqa700
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Teneqa 700",
        slug:         "cumulus-teneqa-700",
        brandId:      Brands.Cumulus.Id,
        categoryId:   Categories.SleepingBags.Id,
        thumbnailUrl: "/products/cumulus-teneqa-700-thumb.webp");
    
    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["/products/cumulus-teneqa-700-1.webp"])
    ];
    
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