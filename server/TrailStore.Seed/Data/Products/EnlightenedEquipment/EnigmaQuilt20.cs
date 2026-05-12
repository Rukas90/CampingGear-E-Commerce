using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.EnlightenedEquipment;

// ReSharper disable UnusedType.Global
public static class EnigmaQuilt20
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Enigma Quilt 20",
        "enlightened-equipment-enigma-quilt-20",
        brandId: Brands.EnlightenedEquipment.Id,
        categoryId: Categories.Quilts.Id,
        thumbnailUrl: "/products/enlightened-equipment-enigma-quilt-20-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ColorOption.Charcoal.Id,
            ["/products/enlightened-equipment-enigma-quilt-20-char.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.Navy.Id,
            ["/products/enlightened-equipment-enigma-quilt-20-nvy.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "EE-ENGQ20-CHAR-SLM-REG",
            398.00m,
            5,
            [ColorOption.Charcoal, GirthOptions.Slim, WidthOption.Regular]),

        Sku.Create(
            Product.Id,
            "EE-ENGQ20-CHAR-REG-REG",
            408.00m,
            7,
            [ColorOption.Charcoal, GirthOptions.Regular, WidthOption.Regular]),

        Sku.Create(
            Product.Id,
            "EE-ENGQ20-CHAR-REG-WD",
            418.00m,
            4,
            [ColorOption.Charcoal, GirthOptions.Regular, WidthOption.Wide]),

        Sku.Create(
            Product.Id,
            "EE-ENGQ20-CHAR-BRD-WD",
            434.00m,
            3,
            [ColorOption.Charcoal, GirthOptions.Broad, WidthOption.Wide]),

        Sku.Create(
            Product.Id,
            "EE-ENGQ20-NVY-SLM-REG",
            398.00m,
            6,
            [ColorOption.Navy, GirthOptions.Slim, WidthOption.Regular]),

        Sku.Create(
            Product.Id,
            "EE-ENGQ20-NVY-REG-REG",
            408.00m,
            8,
            [ColorOption.Navy, GirthOptions.Regular, WidthOption.Regular]),

        Sku.Create(
            Product.Id,
            "EE-ENGQ20-NVY-REG-WD",
            418.00m,
            5,
            [ColorOption.Navy, GirthOptions.Regular, WidthOption.Wide]),

        Sku.Create(
            Product.Id,
            "EE-ENGQ20-NVY-BRD-WD",
            434.00m,
            2,
            [ColorOption.Navy, GirthOptions.Broad, WidthOption.Wide])
    ];
}