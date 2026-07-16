using TrailStore.Ordering.Domain.Orders;

namespace TrailStore.Ordering.Api.Orders;

public sealed class OrderSummaryResponse
{
    public required Guid Id { get; init; }
    public required string Token { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required OrderStatus Status { get; init; }
    public required decimal Total { get; init; }
}