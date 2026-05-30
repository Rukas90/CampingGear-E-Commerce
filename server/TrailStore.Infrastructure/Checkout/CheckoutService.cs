using TrailStore.Domain.Checkout.Interfaces;
using TrailStore.Domain.Checkout.Models;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.ShoppingSessions.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Checkout;

[AppService<ICheckoutService>]
public class CheckoutService(
    ICheckoutSessionService checkoutSessionService,
    ICheckoutSessionRepository checkoutSessionRepository) 
    : ICheckoutService
{
    public async Task<Result<CheckoutForm>> GetCheckoutForm(ShoppingContext ctx, CancellationToken ct)
    {
        var result = await checkoutSessionService.GetCreateCheckoutSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var session = result.Value;

        return new CheckoutForm
        {
            Contact = new CheckoutContact
            {
                EmailAddress = session.EmailAddress
            },
            ShippingAddress = session.ShippingAddress,
            Billing = new CheckoutBilling
            {
                AsShippingAddress = session.ShippingAddressAsBillingAddress,
                Address = session.BillingAddress
            }
        };
    }
    
    public async Task<Result> UpdateCheckoutContact(ShoppingContext ctx, CheckoutContact contact, CancellationToken ct)
    {
        var result = await checkoutSessionService.GetCreateCheckoutSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        var session = result.Value;
        
        session.EmailAddress = contact.EmailAddress;

        await checkoutSessionRepository.UpdateAsync(session, ct);
        
        return Result.Ok();
    }
    
    public async Task<Result> UpdateCheckoutShipping(ShoppingContext ctx, PostalAddress address, CancellationToken ct)
    {
        var result = await checkoutSessionService.GetCreateCheckoutSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        var session = result.Value;
        
        session.ShippingAddress = address;

        await checkoutSessionRepository.UpdateAsync(session, ct);
        
        return Result.Ok();
    }
    
    public async Task<Result> UpdateCheckoutBilling(ShoppingContext ctx, CheckoutBilling billing, CancellationToken ct)
    {
        var result = await checkoutSessionService.GetCreateCheckoutSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        var session = result.Value;
        
        session.ShippingAddressAsBillingAddress = billing.AsShippingAddress;
        session.BillingAddress = billing.Address;

        await checkoutSessionRepository.UpdateAsync(session, ct);
        
        return Result.Ok();
    }
    
    public async Task ConfirmCheckout(ShoppingContext ctx)
    {
        
    }
}