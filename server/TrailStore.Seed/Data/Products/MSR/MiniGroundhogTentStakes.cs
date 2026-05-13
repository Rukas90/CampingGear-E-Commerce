using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.MSR;

// ReSharper disable UnusedType.Global
public static class MiniGroundhogTentStakes
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Mini-Groundhog Tent Stakes",
        "msr-mini-groundhog-tent-stakes",
        brandId: Brands.MSR.Id,
        categoryId: Categories.Accessories.Id,
        description:
        """
        The MSR Mini Groundhog is the lighter sibling of the iconic Groundhog stake, built for ultralight backpackers who want proven performance without the extra grams.
        
        It carries over the same trusted Y-beam design that holds firm in medium to firm soil, shrunk down to 15cm (6 in) and 9g per stake — making it a meaningful weight saving over the standard Groundhog. Machined from 7000-series aluminum for long-term durability. A reflective pull loop makes retrieval quick and easy. Sold as a kit of 6 stakes.
        
        The go-to stake upgrade for anyone counting grams on a thru-hike or fast-and-light trip without wanting to compromise on hold.
        """,
        thumbnailUrl: "/products/msr-mini-groundhog-tent-stakes-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ["/products/msr-mini-groundhog-tent-stakes-1.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "MSR-MINIGRDHGSTK-STD",
            23.00m,
            2,
            [])
    ];
}