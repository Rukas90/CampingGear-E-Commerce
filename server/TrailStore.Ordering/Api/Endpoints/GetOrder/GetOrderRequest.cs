using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Api.Endpoints.GetOrder;

public class GetOrderRequest
{
    public Id<Order> OrderId { get; init; }
}