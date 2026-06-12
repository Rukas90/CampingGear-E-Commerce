using TrailStore.Domain.Checkout.Models;
using TrailStore.Domain.Orders.Models;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.ShoppingSessions.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Checkout.Interfaces;

public interface ICheckoutService
{
    Task<Result<CheckoutForm>> GetCheckoutForm(ShoppingContext ctx, CancellationToken ct);

    Task<Result<CheckoutStats>> GetCheckoutStats(ShoppingContext ctx, CancellationToken ct);
    
    Task<Result> UpdateCheckoutContact(ShoppingContext ctx, CheckoutContact contact, CancellationToken ct);
    
    Task<Result<CheckoutShipping>> UpdateCheckoutShippingAddress(ShoppingContext ctx, ShippingAddress address, CancellationToken ct);

    Task<Result> UpdateCheckoutShippingMethod(
        ShoppingContext ctx, Id<ShippingMethod> selectedMethodId, CancellationToken ct);
    
    Task<Result> UpdateCheckoutBilling(ShoppingContext ctx, CheckoutBilling billing, CancellationToken ct);

    Task<Result<Id<Order>>> ConfirmCheckout(ShoppingContext ctx, CancellationToken ct);
}