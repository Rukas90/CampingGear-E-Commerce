using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Cumulus;

// ReSharper disable UnusedType.Global

public static class LiteLine300
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Lite Line 300",
        slug:         "cumulus-lite-line-300",
        brandId:      Brands.Cumulus.Id,
        categoryId:   Categories.SleepingBags.Id,
        thumbnailUrl: "/products/cumulus-lite-line-300-thumb.webp");
    
    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["/products/cumulus-lite-line-300-1.webp",
                        "/products/cumulus-lite-line-300-2.webp",
                        "/products/cumulus-lite-line-300-3.webp",
                        "/products/cumulus-lite-line-300-4.webp"])
    ];
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "CLMS-LITELINE300-LFT",
            price: 316.00m,
            stock: 2,
            options: [ZipOption.Left]),
        
        Sku.Create(
            productId: Product.Id,
            code: "CLMS-LITELINE300-RGT",
            price: 316.00m,
            stock: 0,
            options: [ZipOption.Right]),
    ];
}