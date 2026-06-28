using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Basket.Application.Queries.GetSessionSummary;

public sealed record GetSessionSummaryQuery(ShoppingContext Ctx) : IQuery<ShoppingSessionSummary>;