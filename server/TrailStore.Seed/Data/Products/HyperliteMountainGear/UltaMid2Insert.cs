using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.HyperliteMountainGear;

// ReSharper disable UnusedType.Global
public static class UltaMid2Insert
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "UltaMid 2 Insert",
        "hyperlite-mountain-gear-ultamid-2-insert",
        brandId: Brands.HyperliteMountainGear.Id,
        categoryId: Categories.Tents.Id,
        description:
        "UltaMid 2 Insert with DCF11 Floor - is designed as four-wall UltaMid 2 Insert with no-see-um mesh ideal for backcountry multi-sport adventurers who want to keep the bugs at bay. Built to fit into the UltaMids, this product comes with a 100% waterproof, DCF11 bathtub floor that can provide you with significant protection should you be caught in a downpour. And fear not, water from condensation won't drip on you in the morning. The inserts were designed a bit smaller than the perimeter of the UltaMid, so the netting never touches the walls.",
        thumbnailUrl: "/products/hyperlite-mountain-gear-ultamid-2-insert-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/hyperlite-mountain-gear-ultamid-2-insert-1.webp",
                "/products/hyperlite-mountain-gear-ultamid-2-insert-2.webp",
                "/products/hyperlite-mountain-gear-ultamid-2-insert-3.webp",
                "/products/hyperlite-mountain-gear-ultamid-2-insert-4.webp",
                "/products/hyperlite-mountain-gear-ultamid-2-insert-5.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "HMG-ULTAMID2INS-STD",
            440.00m,
            6,
            [])
    ];
}