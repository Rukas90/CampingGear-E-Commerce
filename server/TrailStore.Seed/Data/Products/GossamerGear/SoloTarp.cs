using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Products.GossamerGear;

// ReSharper disable UnusedType.Global

public sealed class SoloTarp
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Solo Tarp",
        slug:         "gossamer-gear-solo-tarp",
        brandId:      Brands.GossamerGear.Id,
        categoryId:   Categories.Tents.Id,
        description:  "GOSSAMER GEAR Solo Tarp - is an ultralight minimalist backpacking tarp providing weather protection for you and your gear. Compact enough to fit in your pocket. Packed smaller than 1 liter Nalgene bottle. It sets up easily with two trekking poles or tied between two trees. The tarp is constructed from 10D Nylon SIL/UTS fabric, waterproof to at least 1800mm and has a catenary cut, allowing for a tight pitch and a trail weight of 213 g. It drys out really quick after rain. The tarp has a bug net loops at each end to guy out a bug net or bivy. You can pitch bug bivy, set up your Helinox camping chair, and cook in the rain while staying dry. It comes with a taped seam so that it's ready to go. Tapered design delivers a maximum space-to-weight ratio and better performance when the weather totally blows.",
        thumbnailUrl: "products/gossamer-gear-solo-tarp-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["products/gossamer-gear-solo-tarp-1.webp",
                        "products/gossamer-gear-solo-tarp-2.webp",
                        "products/gossamer-gear-solo-tarp-3.webp",
                        "products/gossamer-gear-solo-tarp-4.webp",
                        "products/gossamer-gear-solo-tarp-5.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "GG-SLOTARP-STD",
            price: 158.00m,
            stock: 9,
            options: []),
    ];
}