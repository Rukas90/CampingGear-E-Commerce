using TrailStore.Domain.Carts.Interfaces;
using TrailStore.Domain.Checkout.Errors;
using TrailStore.Domain.Checkout.Interfaces;
using TrailStore.Domain.Checkout.Models;
using TrailStore.Domain.Checkout.Validators;
using TrailStore.Domain.Countries.Data;
using TrailStore.Domain.Orders.Interfaces;
using TrailStore.Domain.Orders.Models;
using TrailStore.Domain.Orders.Requests;
using TrailStore.Domain.Orders.Results;
using TrailStore.Domain.Shared.Extensions;
using TrailStore.Domain.Shared.Financials;
using TrailStore.Domain.Shared.Interfaces;
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
    IShippingMethodRepository shippingMethodRepository,
    IOrderService orderService,
    IUnitOfWork unitOfWork) 
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

        if (country is null || selectedShippingMethod is null)
        {
            return new CheckoutStats
            {
                Status = checkoutSession.Status,
                Subtotal = subtotal,
                Tax = null,
                Total = null,
                ShippingCost = null,
                AddCostForFreeShipping = null,
                EligibleForFreeShipping = false
            };
        }
        
        var financials = FinancialsCalculator.Calculate(input: new FinancialsCalculationsInput
        {
            Subtotal = subtotal,
            TaxRate = country.TaxRate,
            ShippingFlatFee = selectedShippingMethod.FlatFee,
            FreeShippingThreshold = selectedShippingMethod.FreeShippingThreshold
        });
        
        return new CheckoutStats
        {
            Status = checkoutSession.Status,
            Subtotal = subtotal,
            Tax = financials.Tax,
            Total = financials.Total,
            ShippingCost = financials.ShippingCost,
            AddCostForFreeShipping = financials.AddCostForFreeShipping,
            EligibleForFreeShipping = financials.EligibleForFreeShipping
        };
    }
    
    public async Task<Result> UpdateCheckoutContact(ShoppingContext ctx, CheckoutContact contact, CancellationToken ct)
    {
        await using var scope = await unitOfWork.BeginScope(ct);
        
        var result = await checkoutSessionService.GetCreateCheckoutSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        var session = result.Value;
        
        session.EmailAddress = contact.EmailAddress;
        
        await scope.CompleteAsync();
        
        return Result.Ok();
    }
    
    public async Task<Result<CheckoutShipping>> UpdateCheckoutShippingAddress(ShoppingContext ctx, ShippingAddress address, CancellationToken ct)
    {
        await using var scope = await unitOfWork.BeginScope(ct);
        
        var result = await checkoutSessionService.GetCreateCheckoutSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        var session = result.Value;
        
        session.ShippingAddress = address;
        
        var selectedMethod = await ValidateCheckoutShipping(session, ct);

        await scope.CompleteAsync();
        
        return new CheckoutShipping
        {
            Address = session.ShippingAddress,
            SelectedMethodId = selectedMethod?.Id
        };
    }
    
    public async Task<Result> UpdateCheckoutShippingMethod(
        ShoppingContext ctx, Id<ShippingMethod> selectedMethodId, CancellationToken ct)
    {
        await using var scope = await unitOfWork.BeginScope(ct);
        
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
        
        await scope.CompleteAsync();
        
        return Result.Ok();
    }
    
    public async Task<Result> UpdateCheckoutBilling(ShoppingContext ctx, CheckoutBilling billing, CancellationToken ct)
    {
        await using var scope = await unitOfWork.BeginScope(ct);
        
        var result = await checkoutSessionService.GetCreateCheckoutSession(ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        var session = result.Value;
        
        session.ShippingAddressAsBillingAddress = billing.AsShippingAddress;
        session.BillingAddress = billing.Address;
        
        await scope.CompleteAsync();
        
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

    public async Task<Result<CreateOrderResult>> ConfirmCheckout(ShoppingContext ctx, CancellationToken ct)
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
        
        var cartItems = await cartItemRepository.FindAllBySessionAsync(shoppingSession.Id, item => new
        {
            item.Quantity,
            item.Sku.AvailableStock,
            SkuCode = item.Sku.Code,
            item.Sku.UnitPrice,
            SkuId = item.Sku.Id
        }, ct);

        if (cartItems.Count == 0)
        {
            return CheckoutProblems.EmptyCart; 
        }

        var validationResult = CheckoutSessionValidator.Validate(checkoutSession);

        if (!validationResult.IsSuccess)
        {
            return validationResult.Problem;
        }

        var validated = validationResult.Value;
        
        var shippingMethod = await shippingMethodRepository.FindByIdAsync(validated.ShippingMethodId, ct);

        if (shippingMethod is null)
        {
            return CheckoutProblems.InvalidShippingMethod;
        }
        
        await using var scope = await unitOfWork.BeginScope(ct);

        var request = new CreateOrderRequest(
            CustomerId: ctx.CustomerId,
            EmailAddress: validated.EmailAddress,
            ShippingAddress: validated.ShippingAddress,
            BillingAddress: validated.BillingAddress,
            ShippingMethod: shippingMethod,
            Country: validated.Country,
            Items: cartItems.Select(i => new OrderLineItem(
                SkuId: i.SkuId,
                SkuCode: i.SkuCode,
                UnitPrice: i.UnitPrice,
                Quantity: i.Quantity
            )).ToList()
        );

        var orderResult = await orderService.CreateOrder(request, ct);

        if (!orderResult.IsSuccess)
        {
            return orderResult.Problem;
        }
        
        await cartItemRepository.DeleteAllBySessionAsync(shoppingSession.Id, ct);
        checkoutSessionRepository.Remove(checkoutSession);

        await scope.CompleteAsync();
        
        return orderResult.Value;
    }
}