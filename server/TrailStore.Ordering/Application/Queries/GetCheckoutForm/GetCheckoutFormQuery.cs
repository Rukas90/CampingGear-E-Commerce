using TrailStore.Basket.Contracts.Session;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Ordering.Application.Queries.GetCheckoutForm;

public sealed record GetCheckoutFormQuery(ShoppingContextRef Ctx) : IQuery<CheckoutForm>;