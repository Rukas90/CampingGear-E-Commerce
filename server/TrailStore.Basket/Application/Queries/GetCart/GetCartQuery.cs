using TrailStore.Basket.Application.Results;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Basket.Application.Queries.GetCart;

public sealed record GetCartQuery(ShoppingContext ctx) : IQuery<CartResult>;