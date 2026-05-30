using TrailStore.Shared.Common;

namespace TrailStore.Domain.Orders.Errors;

public static class OrderProblems
{
    public static readonly Problem IntentNotFound
        = new("Order Error", "order.intent_not_found", "Intent not found.");
}