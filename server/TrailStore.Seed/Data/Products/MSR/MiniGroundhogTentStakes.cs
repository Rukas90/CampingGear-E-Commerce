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
        "MSR Mini-Groundhog™ Tent Stakes - lightweight, compact Y-beam tent stakes.\nThis smaller, lighter version of MSR popular Groundhog™ tent stake saves weight while offering the reliable performance of the original. The proven Y-beam design penetrates and holds in medium to firm soil, while the 7000-series aluminum provides years of strength and durability. A reflective pull loop allows for easy removal. Sold as a kit of 6 stakes. Weighing only 10 grams per peg they are almost 40% lighter than the standard Groundhog stakes. For those backpackers counting grams these stakes are advertised at 9,9 g (0.35 ounces) each. For six stakes, you'd get less than 60g (2.1 ounces).",
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