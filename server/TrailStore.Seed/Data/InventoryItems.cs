using TrailStore.Catalog.Domain.Skus;
using TrailStore.Inventory.Domain;
using TrailStore.Seed.Common;

namespace TrailStore.Seed.Data;

public static class InventoryItems
{
    [SeededEntity] public static readonly List<InventoryItem> All = GenerateAll();

    private static List<InventoryItem> GenerateAll()
    {
        var skus = SeedRunner.Discover<Sku>(SeedMarker.Reference).ToArray();
        return skus.Select(sku => InventoryItem.Create(sku.Id, sku.Stock, 0)).ToList();
    }
}