using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.HyperliteMountainGear;

// ReSharper disable UnusedType.Global

public static class BugBivy
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Bug Bivy",
        slug:         "hyperlite-mountain-gear-bug-bivy",
        brandId:      Brands.HyperliteMountainGear.Id,
        categoryId:   Categories.BivysLiners.Id,
        thumbnailUrl: "/products/hyperlite-mountain-gear-bug-bivy-thumb.webp");

    [SeededEntity] 
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id, 
            urls:      ["/products/hyperlite-mountain-gear-bug-bivy-1.webp", 
                        "/products/hyperlite-mountain-gear-bug-bivy-2.webp"])
    ];
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "HMG-BUGBIVY-REG",
            price: 272.00m,
            stock: 6,
            options: [SizeOption.Regular]),

        Sku.Create(
            productId: Product.Id,
            code: "HMG-BUGBIVY-LG",
            price: 272.00m,
            stock: 4,
            options: [SizeOption.Large]),
    ];
}