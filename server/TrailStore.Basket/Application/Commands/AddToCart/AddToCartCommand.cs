using TrailStore.Basket.Domain.Carts;
using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Application.Commands.AddToCart;

public sealed record AddToCartCommand(
    Id<Cart>? cartId, Id<UserRef>? userId, Id<SkuRef> SkuId, int Quantity) : ICommand<Id<Cart>>;