using TrailStore.Domain.Models;
 
namespace TrailStore.Seed.Data.Products.EnlightenedEquipment;
 
// ReSharper disable UnusedType.Global

public sealed class XWidePadStrap
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:       "XWide Pad Strap",
        slug:       "enlightened-equipment-xwide-pad-strap",
        brandId:    Brands.EnlightenedEquipment.Id,
        categoryId: Categories.Quilts.Id);
 
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