using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Application.Commands.AddToCart;

public sealed record AddToCartCommand(
    ShoppingContext ctx, Guid SkuId, int Quantity) : ICommand<Id<ShoppingSession>>;