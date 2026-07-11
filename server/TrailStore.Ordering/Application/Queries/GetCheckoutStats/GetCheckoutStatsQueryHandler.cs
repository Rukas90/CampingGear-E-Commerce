using TrailStore.Basket.Contracts.Carts;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Addresses;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Ordering.Domain.Countries.Data;
using TrailStore.Ordering.Domain.Financials;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.Queries.GetCheckoutStats;

[AppService<GetCheckoutStatsQueryHandler>]
public sealed class GetCheckoutStatsQueryHandler(
    ICheckoutSessionService checkoutSessionService,
    IShippingMethodRepository shippingMethodRepository,
    ICartService cartService)
    : IQueryHandler<GetCheckoutStatsQuery, CheckoutStats>
{
    public async Task<Result<CheckoutStats>> Handle(
        GetCheckoutStatsQuery query, CancellationToken ct)
    {
        var result = await checkoutSessionService.FindCheckoutSession(query.CartId, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var checkoutSession = result.Value;

        if (checkoutSession is null)
        {
            return CheckoutProblems.NoSession;
        }
        
        var hasValidShippingAddress = checkoutSession.ShippingAddress.IsValid();
        
        var country = hasValidShippingAddress 
            ? CountryRegistry.For(checkoutSession.ShippingAddress!.CountryCode) 
            : null;

        
        var selectedShippingMethod = checkoutSession.ShippingMethodId is not null 
            ? await shippingMethodRepository.FindAsync(checkoutSession.ShippingMethodId.Value, ct) : null;
        
        var cart = await cartService.GetCart(query.CartId, ct);

        if (cart is null or { Items.Length: <= 0 })
        {
            return CheckoutProblems.EmptyCart;
        }
        
        var subtotal = cart.Items.Sum(item => item.UnitPrice * item.Quantity);
        
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

        var lines = cart.Items.Select(
            item => FinancialsCalculator.CalculateLine(new LineFinancialsCalculationInput
        {
            UnitPrice = item.UnitPrice,
            TaxRate = country.TaxRate,
            Quantity = item.Quantity
        })).ToArray();

        var shipping = FinancialsCalculator.CalculateShipping(new ShippingFinancialsCalculationsInput
        {
            Lines = lines,
            TaxRate = country.TaxRate,
            ShippingFlatFee = selectedShippingMethod.FlatFee,
            FreeShippingThreshold = selectedShippingMethod.FreeShippingThreshold
        });

        var order = FinancialsCalculator.CalculateOrder(new OrderFinancialsCalculationsInput
        {
            Lines = lines,
            Shipping = shipping
        });
        
        return new CheckoutStats
        {
            Status = checkoutSession.Status,
            Subtotal = subtotal,
            Tax = order.TaxAmount,
            Total = order.TotalPrice,
            ShippingCost = shipping.CostBeforeTaxes,
            AddCostForFreeShipping = shipping.AddCostForFreeShipping,
            EligibleForFreeShipping = shipping.EligibleForFreeShipping
        };
    }
}