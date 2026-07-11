using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Commands.UpdateShipping;

public sealed record UpdateShippingAddressCommand(
    Id<CartRef> CartId, Id<UserRef>? UserId, ShippingAddress Address): ICommand<CheckoutShipping>;