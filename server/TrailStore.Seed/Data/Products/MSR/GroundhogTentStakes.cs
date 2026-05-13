using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.MSR;

// ReSharper disable UnusedType.Global
public static class GroundhogTentStakes
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Groundhog Tent Stakes",
        "msr-groundhog-tent-stakes",
        brandId: Brands.MSR.Id,
        categoryId: Categories.Accessories.Id,
        description:
        """
        The MSR Groundhog is one of the most trusted tent stakes in backpacking, built for reliability across a wide range of soil conditions.
        
        Its three-sided Y-beam design cuts into the ground cleanly and holds firm in everything from packed dirt to softer terrain. Machined from 7000-series aluminum, each stake weighs just 14g (0.49 oz) at 19cm (7.5 in) long — light enough for a fast-and-light kit, tough enough to last for years.
        
        A notched top secures guy lines without slipping, and the reflective pull loop makes retrieval easy even after dark. Sold as a kit of 6 stakes.
        
        If you want a stake you can trust without thinking about it, the Groundhog is the benchmark everything else gets compared to.
        """,
        thumbnailUrl: "/products/msr-groundhog-tent-stakes-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ["/products/msr-groundhog-tent-stakes-1.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "MSR-GRDHGSTK-STD",
            27.00m,
            18,
            [])
    ];
}