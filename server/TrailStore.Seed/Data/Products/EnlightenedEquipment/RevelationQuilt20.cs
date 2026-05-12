using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.EnlightenedEquipment;

// ReSharper disable UnusedType.Global
public static class RevelationQuilt20
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Revelation Quilt 20",
        "enlightened-equipment-revelation-quilt-20",
        brandId: Brands.EnlightenedEquipment.Id,
        categoryId: Categories.Quilts.Id,
        thumbnailUrl: "/products/enlightened-equipment-revelation-quilt-20-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ColorOption.Orange.Id,
            ["/products/enlightened-equipment-revelation-quilt-20-org.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.Navy.Id,
            ["/products/enlightened-equipment-revelation-quilt-20-nvy.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.Forest.Id,
            ["/products/enlightened-equipment-revelation-quilt-20-for.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "EE-REV20-ORG-LW",
            424.00m,
            5,
            [ColorOption.Orange, HeightOption.Tall, WidthOption.Wide]),

        Sku.Create(
            Product.Id,
            "EE-REV20-ORG-SR",
            388.00m,
            8,
            [ColorOption.Orange, HeightOption.Short, WidthOption.Regular]),

        Sku.Create(
            Product.Id,
            "EE-REV20-ORG-RR",
            398.00m,
            6,
            [ColorOption.Orange, HeightOption.Regular, WidthOption.Regular]),

        Sku.Create(
            Product.Id,
            "EE-REV20-ORG-RW",
            408.00m,
            3,
            [ColorOption.Orange, HeightOption.Regular, WidthOption.Wide]),

        Sku.Create(
            Product.Id,
            "EE-REV20-NVY-LW",
            424.00m,
            4,
            [ColorOption.Navy, HeightOption.Tall, WidthOption.Wide]),

        Sku.Create(
            Product.Id,
            "EE-REV20-NVY-SR",
            388.00m,
            7,
            [ColorOption.Navy, HeightOption.Short, WidthOption.Regular]),

        Sku.Create(
            Product.Id,
            "EE-REV20-NVY-RR",
            398.00m,
            9,
            [ColorOption.Navy, HeightOption.Regular, WidthOption.Regular]),

        Sku.Create(
            Product.Id,
            "EE-REV20-NVY-RW",
            408.00m,
            2,
            [ColorOption.Navy, HeightOption.Regular, WidthOption.Wide]),

        Sku.Create(
            Product.Id,
            "EE-REV20-FOR-LW",
            424.00m,
            0,
            [ColorOption.Forest, HeightOption.Tall, WidthOption.Wide]),

        Sku.Create(
            Product.Id,
            "EE-REV20-FOR-SR",
            388.00m,
            5,
            [ColorOption.Forest, HeightOption.Short, WidthOption.Regular]),

        Sku.Create(
            Product.Id,
            "EE-REV20-FOR-RR",
            398.00m,
            11,
            [ColorOption.Forest, HeightOption.Regular, WidthOption.Regular]),

        Sku.Create(
            Product.Id,
            "EE-REV20-FOR-RW",
            408.00m,
            3,
            [ColorOption.Forest, HeightOption.Regular, WidthOption.Wide])
    ];
}