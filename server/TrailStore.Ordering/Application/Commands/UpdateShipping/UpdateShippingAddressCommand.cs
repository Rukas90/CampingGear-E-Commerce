using TrailStore.Basket.Contracts.Session;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Ordering.Application.Commands.UpdateShipping;

public sealed record UpdateShippingAddressCommand(
    ShoppingContextRef Ctx, ShippingAddress Address): ICommand<CheckoutShipping>;