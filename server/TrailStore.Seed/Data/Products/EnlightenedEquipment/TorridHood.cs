using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;
 
namespace TrailStore.Seed.Data.Products.EnlightenedEquipment;
 
// ReSharper disable UnusedType.Global
 
public static class TorridHood
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Torrid Hood",
        slug:         "enlightened-equipment-torrid-hood",
        brandId:      Brands.EnlightenedEquipment.Id,
        categoryId:   Categories.Quilts.Id,
        thumbnailUrl: "/products/enlightened-equipment-torrid-hood-thumb.webp");
 
    [SeededEntity] 
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id, 
            urls:      ["/products/enlightened-equipment-torrid-hood-1.webp"])
    ];
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "EE-TRRHOOD-SM",
            price: 79.00m,
            stock: 6,
            options: [SizeOption.Small]),
 
        Sku.Create(
            productId: Product.Id,
            code: "EE-TRRHOOD-MD",
            price: 79.00m,
            stock: 8,
            options: [SizeOption.Medium]),
 
        Sku.Create(
            productId: Product.Id,
            code: "EE-TRRHOOD-LG",
            price: 79.00m,
            stock: 4,
            options: [SizeOption.Large]),
    ];
}