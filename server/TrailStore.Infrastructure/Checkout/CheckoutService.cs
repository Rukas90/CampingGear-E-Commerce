using TrailStore.Domain.Carts.Interfaces;
using TrailStore.Domain.Checkout.Errors;
using TrailStore.Domain.Checkout.Interfaces;
using TrailStore.Domain.Checkout.Models;
using TrailStore.Domain.Countries.Data;
using TrailStore.Domain.Shared.Extensions;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.Shipping.Interfaces;
using TrailStore.Domain.ShoppingSessions.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Checkout;

[AppService<ICheckoutService>]
public class CheckoutService(
    ICheckoutSessionService checkoutSessionService,
    ICheckoutSessionRepository checkoutSessionRepository,
    ICartItemRepository cartItemRepository,
    IShippingMethodRepository shippingMethodRepository) 
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
        
        var selectedShippingMethod = 
            await GetShippingMethod(session.ShippingMethodId, session.ShippingAddress, ct);
        
        return new CheckoutForm
        {
            Contact = new CheckoutContact
            {
                EmailAddress = session.EmailAddress
            },
            Shipping = new CheckoutShipping
            {
                Address = session.ShippingAddress,
                SelectedMethodId = selectedShippingMethod?.Id
            },
            Billing = new CheckoutBilling
            {
                AsShippingAddress = session.ShippingAddressAsBillingAddress,
                Address = session.BillingAddress
            }
        };
    }
    
    public async Task<Result<CheckoutStats>> GetCheckoutStats(ShoppingContext ctx, CancellationToken ct)
    {
        var result = await checkoutSessionService.FindCheckoutSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var (checkoutSession, shoppingSession) = result.Value;

        if (checkoutSession is null)
        {
            return CheckoutProblems.NoSession;
        }
        
        var hasValidShippingAddress = checkoutSession.ShippingAddress.IsValid();
        
        var country = hasValidShippingAddress 
            ? CountryRegistry.For(checkoutSession.ShippingAddress!.CountryCode) 
            : null;

        var selectedShippingMethod = checkoutSession.ShippingMethod;
        
        var subtotal = await cartItemRepository.CalculateSubtotalBySessionAsync(shoppingSession.Id, ct);
        
        var tax = subtotal * country?.TaxRate ?? null;

        var eligibleForFreeShipping = selectedShippingMethod is not null 
                                      && subtotal >= selectedShippingMethod.FreeShippingThreshold;
        
        var shippingCost = eligibleForFreeShipping ? 0m : selectedShippingMethod?.FlatFee;
        
        var Total = subtotal + (tax ?? 0m) + (shippingCost ?? 0m);

        return new CheckoutStats
        {
            Status = checkoutSession.Status,
            Subtotal = subtotal,
            Tax = tax,
            Total = Total,
            ShippingCost = shippingCost,
            EligibleForFreeShipping = eligibleForFreeShipping
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
    
    public async Task<Result<CheckoutShipping>> UpdateCheckoutShippingAddress(ShoppingContext ctx, PostalAddress address, CancellationToken ct)
    {
        var result = await checkoutSessionService.GetCreateCheckoutSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        var session = result.Value;
        
        session.ShippingAddress = address;

        await checkoutSessionRepository.UpdateAsync(session, ct);
        
        var selectedMethod = await ValidateCheckoutShipping(session, ct);
        
        return new CheckoutShipping
        {
            Address = session.ShippingAddress,
            SelectedMethodId = selectedMethod?.Id
        };
    }
    
    public async Task<Result> UpdateCheckoutShippingMethod(
        ShoppingContext ctx, Id<ShippingMethod> selectedMethodId, CancellationToken ct)
    {
        var result = await checkoutSessionService.GetCreateCheckoutSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var session = result.Value;
        var hasValidShippingAddress = session.ShippingAddress.IsValid();

        if (!hasValidShippingAddress)
        {
            return CheckoutProblems.IncompleteShippingAddress;
        }
        
        session.ShippingMethodId = selectedMethodId;

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
    
    private async Task<ShippingMethod?> ValidateCheckoutShipping(
        CheckoutSession checkoutSession, CancellationToken ct)
    {
        var selectedMethod = await GetShippingMethod(
            checkoutSession.ShippingMethodId, checkoutSession.ShippingAddress, ct);
        
        if (checkoutSession.ShippingMethodId != selectedMethod?.Id)
        {
            checkoutSession.ShippingMethodId = selectedMethod?.Id;
            await checkoutSessionRepository.UpdateAsync(checkoutSession, ct);
        }
        
        return selectedMethod;
    }
    
    private async Task<ShippingMethod?> GetShippingMethod(
        Id<ShippingMethod>? currentMethodId, PostalAddress? shippingAddress, CancellationToken ct)
    {
        var availableMethods = shippingAddress.IsValid()
            ? await shippingMethodRepository.ListAvailableAsync(shippingAddress!.CountryCode, ct)
            : [];

        var selectedMethod = currentMethodId is not null
            ? availableMethods.FirstOrDefault(m => m.Id == currentMethodId)
            : null;
        
        selectedMethod ??= availableMethods.FirstOrDefault();
        
        return selectedMethod;
    }

    public async Task ConfirmCheckout(ShoppingContext ctx)
    {
        // TODO
    }
}