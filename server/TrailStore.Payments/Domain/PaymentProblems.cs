using Stripe;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Payments.Domain;

public static class PaymentProblems
{
    public static readonly Problem PaymentAlreadyHasAttempt
        = new("Payment has attempt", "payment.has_attempt", "Payment already has an active attempt.");
    
    public static readonly Problem PaymentAlreadyComplete
        = new("Payment is completed", "payment.already_complete", "Cannot issue new attempt for a completed payment.");
    
    public static readonly Problem PaymentCanceled
        = new("Payment is canceled", "payment.canceled", "Cannot issue new attempt for a canceled payment.");
    
    public static readonly Problem OutOfAttempts
        = new("Out of attempts", "payment.out_of_attempts", "Cannot issue new attempt. Payment is out of attempts.");
    
    public static readonly Problem NotFound 
        = new("Not found", "payment.not_found", "Payment not found.");
    
    public static Problem StripeError(string message) 
        => new("Stripe error", "payment.stripe_error", message);
}