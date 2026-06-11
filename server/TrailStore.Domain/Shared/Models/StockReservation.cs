using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class StockReservation : IModel<StockReservation>, IEntityExpirable, IEntityCreatable
{
    public required Id<StockReservation> Id { get; init; }
    public required Id<Sku> SkuId { get; init; }
    public required int Quantity { get; init; }
    public required string ReferenceId { get; init; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }

    public static StockReservation Create(Id<Sku> skuId, int quantity, string ReferenceId, TimeSpan expireTime)
        => new()
        {
            Id = Id<StockReservation>.New(),
            SkuId = skuId,
            Quantity = quantity,
            ReferenceId = ReferenceId,
            ExpiresAt = DateTime.UtcNow.Add(expireTime)
        };
}