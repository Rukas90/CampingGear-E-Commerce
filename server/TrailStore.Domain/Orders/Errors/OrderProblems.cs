using TrailStore.Shared.Common;

namespace TrailStore.Domain.Orders.Errors;

public static class OrderProblems
{
    public static readonly Problem NotFound
        = new("Order Error", "order.not_found", "Order not found.");
}