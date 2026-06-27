using TrailStore.Basket.Contracts.Session;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Ordering.Application.Queries.GetCheckoutStats;

public sealed record GetCheckoutStatsQuery(ShoppingContextRef Ctx) 
    : IQuery<CheckoutStats>;