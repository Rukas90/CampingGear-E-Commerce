namespace TrailStore.Inventory.Contracts;

public readonly record struct ItemChangedStock(Guid SkuId, int Stock);