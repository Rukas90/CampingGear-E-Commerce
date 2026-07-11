using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Queries.GetCheckoutForm;

public sealed record GetCheckoutFormQuery(Id<CartRef> CartId, Id<UserRef>? UserId) : IQuery<CheckoutForm>;