using TrailStore.Basket.Domain.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Application.Commands.UpdateCartItemQuantity;

public sealed record UpdateCartItemQuantityCommand(
    Id<Cart>? cartId, Id<UserRef>? userId, Id<CartItem> ItemId, int NewQuantity) : ICommand<Id<Cart>>;