using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Results;

public class OrderSummaryResult
{
    public required Id<Order> Id { get; init; }
    public required string Token { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required OrderStatus Status { get; init; }
    public required decimal Total { get; init; }
}