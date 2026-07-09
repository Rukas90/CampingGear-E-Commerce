using TrailStore.Shared.Domain.Common;

namespace TrailStore.Payments.Domain;

public static class PaymentProblems
{
    public static readonly Problem OrderNotFound 
        = new("Order not found", "payment.order_not_found", "Payment order not found.");
}