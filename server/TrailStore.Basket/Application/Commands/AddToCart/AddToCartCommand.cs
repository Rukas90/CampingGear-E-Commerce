using TrailStore.Basket.Contracts.Session;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Application.Commands.AddToCart;

public sealed record AddToCartCommand(
    ShoppingContext Ctx, Id<SkuRef> SkuId, int Quantity) : ICommand<Id<ShoppingSession>>;