using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.EnlightenedEquipment;

// ReSharper disable UnusedType.Global

public sealed class EnigmaQuilt20
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Enigma Quilt 20",
        slug:         "enlightened-equipment-enigma-quilt-20",
        brandId:      Brands.EnlightenedEquipment.Id,
        categoryId:   Categories.Quilts.Id,
        thumbnailUrl: "products/enlightened-equipment-enigma-quilt-20-thumb.webp");

    [SeededEntity] 
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id, 
            optionId:  ColorOption.Charcoal.Id, 
            urls:      ["products/enlightened-equipment-enigma-quilt-20-char.webp"]),
        
        ProductImage.Create(
            productId: Product.Id, 
            optionId:  ColorOption.Navy.Id, 
            urls:      ["products/enlightened-equipment-enigma-quilt-20-nvy.webp"])
    ];
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "EE-ENGQ20-CHAR-SLM-REG",
            price: 398.00m,
            stock: 5,
            options: [ColorOption.Charcoal, GirthOptions.Slim, WidthOption.Regular]),

        Sku.Create(
            productId: Product.Id,
            code: "EE-ENGQ20-CHAR-REG-REG",
            price: 408.00m,
            stock: 7,
            options: [ColorOption.Charcoal, GirthOptions.Regular, WidthOption.Regular]),

        Sku.Create(
            productId: Product.Id,
            code: "EE-ENGQ20-CHAR-REG-WD",
            price: 418.00m,
            stock: 4,
            options: [ColorOption.Charcoal, GirthOptions.Regular, WidthOption.Wide]),

        Sku.Create(
            productId: Product.Id,
            code: "EE-ENGQ20-CHAR-BRD-WD",
            price: 434.00m,
            stock: 3,
            options: [ColorOption.Charcoal, GirthOptions.Broad, WidthOption.Wide]),

        Sku.Create(
            productId: Product.Id,
            code: "EE-ENGQ20-NVY-SLM-REG",
            price: 398.00m,
            stock: 6,
            options: [ColorOption.Navy, GirthOptions.Slim, WidthOption.Regular]),

        Sku.Create(
            productId: Product.Id,
            code: "EE-ENGQ20-NVY-REG-REG",
            price: 408.00m,
            stock: 8,
            options: [ColorOption.Navy, GirthOptions.Regular, WidthOption.Regular]),

        Sku.Create(
            productId: Product.Id,
            code: "EE-ENGQ20-NVY-REG-WD",
            price: 418.00m,
            stock: 5,
            options: [ColorOption.Navy, GirthOptions.Regular, WidthOption.Wide]),

        Sku.Create(
            productId: Product.Id,
            code: "EE-ENGQ20-NVY-BRD-WD",
            price: 434.00m,
            stock: 2,
            options: [ColorOption.Navy, GirthOptions.Broad, WidthOption.Wide]),
    ];
}