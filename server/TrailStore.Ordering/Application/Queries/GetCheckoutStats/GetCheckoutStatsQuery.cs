using TrailStore.Basket.Contracts.Carts;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Queries.GetCheckoutStats;

public sealed record GetCheckoutStatsQuery(Id<CartRef> CartId) : IQuery<CheckoutStats>;