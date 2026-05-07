using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Products.HyperliteMountainGear;

// ReSharper disable UnusedType.Global

public sealed class GroundCloth
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Ground Cloth",
        slug:         "hyperlite-mountain-gear-ground-cloth",
        brandId:      Brands.HyperliteMountainGear.Id,
        categoryId:   Categories.Accessories.Id,
        description:  "HMG Ground Cloth - is ultimate, super lightweight Ground Cloth for minimalist overnight backpackers who like to sleep under the stars, but who still want foolproof protection for their gear from moisture, mud and dirt. Ideal for goal-oriented adventurers constantly on the move and in need of fast protection from inclement weather. It's sizeable at 244cm x 132cm (96\" X 52\") but weighs less than an iPhone. Pair it with HMG Flat Tarp, Echo Tarp or UltaMids (if not using the respective inserts) for optimal ultralight multi-sport travel.",
        thumbnailUrl: "/products/hyperlite-mountain-gear-ground-cloth-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["/products/hyperlite-mountain-gear-ground-cloth-1.webp",
                        "/products/hyperlite-mountain-gear-ground-cloth-2.webp",
                        "/products/hyperlite-mountain-gear-ground-cloth-3.webp",
                        "/products/hyperlite-mountain-gear-ground-cloth-4.webp",
                        "/products/hyperlite-mountain-gear-ground-cloth-5.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "HMG-GRNDCLTH-STD",
            price: 231.00m,
            stock: 0,
            options: []),
    ];
}