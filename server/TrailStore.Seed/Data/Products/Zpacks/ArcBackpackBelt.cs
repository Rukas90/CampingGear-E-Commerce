using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global

public static class ArcBackpackBelt
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Arc Backpack Belt",
        slug:         "zpacks-arc-backpack-belt",
        brandId:      Brands.Zpacks.Id,
        categoryId:   Categories.CareProtection.Id,
        description:  "Zpacks Arc backpacks feature a removable and interchangeable belt. This is a useful feature if you lose or gain weight, or if the pack is transferred to a different size person. If the belt wears out before the rest of the pack you could replace it.",
        thumbnailUrl: "/products/zpacks-arc-backpack-belt-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["/products/zpacks-arc-backpack-belt-1.webp",
                        "/products/zpacks-arc-backpack-belt-2.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "ZP-ARCBLT-SM",
            price: 79.00m,
            stock: 8,
            options: [SizeOption.Small]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-ARCBLT-MD",
            price: 79.00m,
            stock: 11,
            options: [SizeOption.Medium]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-ARCBLT-LG",
            price: 79.00m,
            stock: 6,
            options: [SizeOption.Large]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-ARCBLT-XL",
            price: 79.00m,
            stock: 3,
            options: [SizeOption.XL]),
    ];
}