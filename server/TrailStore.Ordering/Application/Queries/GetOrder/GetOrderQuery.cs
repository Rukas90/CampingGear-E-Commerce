using TrailStore.Ordering.Application.Results;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Queries.GetOrder;

public sealed record GetOrderQuery(Id<Order> Id) : IQuery<OrderDetailsResult>;