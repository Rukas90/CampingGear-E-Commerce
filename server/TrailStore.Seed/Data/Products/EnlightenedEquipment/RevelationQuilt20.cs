using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.EnlightenedEquipment;

// ReSharper disable UnusedType.Global

public static class RevelationQuilt20
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Revelation Quilt 20",
        slug:         "enlightened-equipment-revelation-quilt-20",
        brandId:      Brands.EnlightenedEquipment.Id,
        categoryId:   Categories.Quilts.Id,
        thumbnailUrl: "/products/enlightened-equipment-revelation-quilt-20-thumb.webp");
    
    [SeededEntity] 
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id, 
            optionId:  ColorOption.Orange.Id, 
            urls:      ["/products/enlightened-equipment-revelation-quilt-20-org.webp"]),
        
        ProductImage.Create(
            productId: Product.Id, 
            optionId:  ColorOption.Navy.Id, 
            urls:      ["/products/enlightened-equipment-revelation-quilt-20-nvy.webp"]),
        
        ProductImage.Create(
            productId: Product.Id, 
            optionId:  ColorOption.Forest.Id, 
            urls:      ["/products/enlightened-equipment-revelation-quilt-20-for.webp"])
    ];
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "EE-REV20-ORG-LW",
            price: 424.00m,
            stock: 5,
            options: [ColorOption.Orange, HeightOption.Tall, WidthOption.Wide]),
 
        Sku.Create(
            productId: Product.Id,
            code: "EE-REV20-ORG-SR",
            price: 388.00m,
            stock: 8,
            options: [ColorOption.Orange, HeightOption.Short, WidthOption.Regular]),
 
        Sku.Create(
            productId: Product.Id,
            code: "EE-REV20-ORG-RR",
            price: 398.00m,
            stock: 6,
            options: [ColorOption.Orange, HeightOption.Regular, WidthOption.Regular]),
 
        Sku.Create(
            productId: Product.Id,
            code: "EE-REV20-ORG-RW",
            price: 408.00m,
            stock: 3,
            options: [ColorOption.Orange, HeightOption.Regular, WidthOption.Wide]),
 
        Sku.Create(
            productId: Product.Id,
            code: "EE-REV20-NVY-LW",
            price: 424.00m,
            stock: 4,
            options: [ColorOption.Navy, HeightOption.Tall, WidthOption.Wide]),
 
        Sku.Create(
            productId: Product.Id,
            code: "EE-REV20-NVY-SR",
            price: 388.00m,
            stock: 7,
            options: [ColorOption.Navy, HeightOption.Short, WidthOption.Regular]),
 
        Sku.Create(
            productId: Product.Id,
            code: "EE-REV20-NVY-RR",
            price: 398.00m,
            stock: 9,
            options: [ColorOption.Navy, HeightOption.Regular, WidthOption.Regular]),
 
        Sku.Create(
            productId: Product.Id,
            code: "EE-REV20-NVY-RW",
            price: 408.00m,
            stock: 2,
            options: [ColorOption.Navy, HeightOption.Regular, WidthOption.Wide]),
 
        Sku.Create(
            productId: Product.Id,
            code: "EE-REV20-FOR-LW",
            price: 424.00m,
            stock: 0,
            options: [ColorOption.Forest, HeightOption.Tall, WidthOption.Wide]),
 
        Sku.Create(
            productId: Product.Id,
            code: "EE-REV20-FOR-SR",
            price: 388.00m,
            stock: 5,
            options: [ColorOption.Forest, HeightOption.Short, WidthOption.Regular]),
 
        Sku.Create(
            productId: Product.Id,
            code: "EE-REV20-FOR-RR",
            price: 398.00m,
            stock: 11,
            options: [ColorOption.Forest, HeightOption.Regular, WidthOption.Regular]),
 
        Sku.Create(
            productId: Product.Id,
            code: "EE-REV20-FOR-RW",
            price: 408.00m,
            stock: 3,
            options: [ColorOption.Forest, HeightOption.Regular, WidthOption.Wide]),
    ];
}