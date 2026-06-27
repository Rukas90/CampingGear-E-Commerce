using TrailStore.Basket.Contracts.Session;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Application.Commands.UpdateCartItemQuantity;

public sealed record UpdateCartItemQuantityCommand(ShoppingContext ctx, Id<CartItem> ItemId, int NewQuantity) 
    : ICommand<Id<ShoppingSession>>;