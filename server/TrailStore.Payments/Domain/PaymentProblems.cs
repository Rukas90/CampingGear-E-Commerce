using TrailStore.Shared.Domain.Common;

namespace TrailStore.Payments.Domain;

public static class PaymentProblems
{
    public static readonly Problem PaymentAlreadyHasAttempt
        = new("Payment has attempt", "payment.has_attempt", "Payment already has an active attempt.");
    
    public static readonly Problem PaymentAlreadyComplete
        = new("Payment is completed", "payment.already_complete", "Cannot issue new attempt for a completed payment.");
    
    public static readonly Problem NotFound 
        = new("Not found", "payment.not_found", "Payment not found.");
}