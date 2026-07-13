using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Domain.Validation;

namespace TrailStore.Ordering.Domain.Checkout;

public class CheckoutProblems
{
    public static readonly Problem NoSession
        = new("Checkout failed", "checkout.no_session", "Unable to start checkout. Please try again.");
    
    public static readonly Problem EmptyCart
        = new("Checkout failed", "checkout.empty_cart", "Your cart is empty. Add items before checking out.");
    
    public static readonly Problem IncompleteShippingAddress
        = new("Checkout failed", "checkout.incomplete_shipping_address", "Please complete your shipping address before proceeding.");

    public static readonly Problem NoShippingMethodAvailable
        = new("Checkout failed", "checkout.no_shipping_method", "No shipping methods are available for your address.");

    public static readonly Problem InvalidShippingMethod
        = new("Checkout failed", "checkout.invalid_shipping_method", "The selected shipping method is not available for your address.");
    
    public static readonly Problem UserNotFound
        = new("Checkout failed", "checkout.user_not_found", "Unable to start checkout. The user by id is not found.");
    
    public static readonly Problem EmailRequired
        = new("Email is required", "checkout.email_required", "Email address is required.");
    
    public static readonly Problem CheckoutNotEditable
        = new("Checkout not editable", "checkout.not_editable", "Checkout is not editable when not in draft status.");
    
    public static readonly Problem AlreadyComplete
        = new("Checkout already complete", "checkout.already_complete", "Cannot complete an already completed checkout.");
    
    public static Problem IncompleteCheckout(ValidationState state)
        => new ValidationProblem(state, "checkout.incomplete");
}