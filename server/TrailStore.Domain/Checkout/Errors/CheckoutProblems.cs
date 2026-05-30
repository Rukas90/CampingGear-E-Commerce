using TrailStore.Shared.Common;

namespace TrailStore.Domain.Checkout.Errors;

public class CheckoutProblems
{
    public static readonly Problem NoSession
        = new("Checkout Failed", "checkout.no_session", "Unable to start checkout. Please try again.");
    
    public static readonly Problem EmptyCart
        = new("Checkout Failed", "checkout.empty_cart", "Your cart is empty. Add items before checking out.");
}