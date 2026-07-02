using TrailStore.Ordering.Application.Results;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Ordering.Application.Queries.GetOrder;

public sealed record GetOrderQuery(string Token) : IQuery<OrderSummary>;