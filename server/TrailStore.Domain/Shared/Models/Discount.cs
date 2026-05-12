using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public enum DiscountType
{
    Percentage,
    FixedAmount
}

public class Discount : IModel<Discount>
{
    public required Id<Discount> Id { get; init; }
    public required Id<Sku> SkuId { get; init; }
    public required DiscountType Type { get; init; }
    public required decimal Value { get; init; }
    public DateTime? StartsAt { get; init; }
    public DateTime? EndsAt { get; init; }
    public bool IsActive { get; init; } = true;

    public Sku Sku { get; private set; } = null!;
}