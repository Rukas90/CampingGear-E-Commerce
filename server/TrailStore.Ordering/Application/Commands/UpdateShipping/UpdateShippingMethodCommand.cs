using TrailStore.Basket.Contracts.Session;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Commands.UpdateShipping;

public sealed record UpdateShippingMethodCommand(
    ShoppingContextRef Ctx, Id<ShippingMethod> ShippingMethodId) : ICommand;