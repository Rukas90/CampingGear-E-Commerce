using TrailStore.Domain.Models;
 
namespace TrailStore.Seed.Data.Products.EnlightenedEquipment;
 
// ReSharper disable UnusedType.Global

public static class XWidePadStrap
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "XWide Pad Strap",
        slug:         "enlightened-equipment-xwide-pad-strap",
        brandId:      Brands.EnlightenedEquipment.Id,
        categoryId:   Categories.Quilts.Id,
        thumbnailUrl: "/products/enlightened-equipment-xwide-pad-strap-thumb.webp");
 
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "EE-XWPADSTRAP-STD",
            price: 8.00m,
            stock: 25,
            options: []),
    ];
}