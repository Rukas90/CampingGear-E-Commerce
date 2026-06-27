using TrailStore.Basket.Contracts.Session;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Contracts.Carts;

public sealed record CartValidationStatusResult(
    Id<ShoppingSessionRef> SessionId, bool CartEmpty);