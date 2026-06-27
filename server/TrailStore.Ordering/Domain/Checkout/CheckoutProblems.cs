using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Domain.Validation;

namespace TrailStore.Ordering.Domain.Checkout;

public class CheckoutProblems
{
    public static readonly Problem NoSession
        = new("Checkout Failed", "checkout.no_session", "Unable to start checkout. Please try again.");
    
    public static readonly Problem EmptyCart
        = new("Checkout Failed", "checkout.empty_cart", "Your cart is empty. Add items before checking out.");
    
    public static readonly Problem IncompleteShippingAddress
        = new("Checkout Failed", "checkout.incomplete_shipping_address", "Please complete your shipping address before proceeding.");

    public static readonly Problem NoShippingMethodAvailable
        = new("Checkout Failed", "checkout.no_shipping_method", "No shipping methods are available for your address.");

    public static readonly Problem InvalidShippingMethod
        = new("Checkout Failed", "checkout.invalid_shipping_method", "The selected shipping method is not available for your address.");
    
    public static Problem IncompleteCheckout(ValidationState state)
        => new ValidationProblem(state, "checkout.incomplete");
}