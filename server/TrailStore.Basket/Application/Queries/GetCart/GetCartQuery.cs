using TrailStore.Basket.Application.Results;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Application.Queries.GetCart;

public sealed record GetCartQuery(Id<Cart>? cartId, Id<UserRef>? userId) : IQuery<CartResult>;