using TrailStore.Basket.Domain.Carts;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Application.Commands.DeleteFromCart;

public sealed record DeleteFromCartCommand(ShoppingContext ctx, Id<CartItem> ItemId) : ICommand<Id<ShoppingSession>>;