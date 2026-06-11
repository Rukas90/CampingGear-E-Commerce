using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class StockReservation : IModel<StockReservation>
{
    public required Id<StockReservation> Id { get; init; }
    public required Id<Sku> SkuId { get; init; }
    public required int Quantity { get; init; }
    public required string ReferenceId { get; init; }
    public required DateTime ExpiryDate { get; init; }

    public static StockReservation Create(Id<Sku> skuId, int quantity, string ReferenceId, DateTime expiryDate)
        => new()
        {
            Id = Id<StockReservation>.New(),
            SkuId = skuId,
            Quantity = quantity,
            ReferenceId = ReferenceId,
            ExpiryDate = expiryDate
        };
}