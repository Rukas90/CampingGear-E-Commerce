using TrailStore.Basket.Domain.Carts;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Basket.Application.Queries.GetSessionSummary;

public sealed record GetSessionSummaryQuery(CartSessionContext Ctx) : IQuery<ShoppingSessionSummary>;