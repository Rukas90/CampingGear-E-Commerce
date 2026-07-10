using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Results;

public sealed record OrderCreatedResult(Id<Order> OrderId);