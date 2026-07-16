using TrailStore.Basket.Domain.Carts;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Basket.Application.Queries.GetCartSummary;

public sealed record GetCartSummaryQuery(CartSessionContext Ctx) : IQuery<CartSummary>;