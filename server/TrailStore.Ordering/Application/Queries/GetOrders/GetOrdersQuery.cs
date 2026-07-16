using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Application.Results;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Queries.GetOrders;

public sealed record GetOrdersQuery(Id<UserRef>? UserId) : IQuery<OrderSummaryResult[]>;