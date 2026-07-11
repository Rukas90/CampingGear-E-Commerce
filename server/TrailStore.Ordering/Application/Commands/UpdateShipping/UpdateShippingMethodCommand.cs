using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Commands.UpdateShipping;

public sealed record UpdateShippingMethodCommand(
    Id<CartRef> CartId, Id<UserRef>? UserId, Id<ShippingMethod> ShippingMethodId) : ICommand;