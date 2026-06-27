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
        var result = await checkoutSessionService.FindCheckoutSession(query.Ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var (checkoutSession, _) = result.Value;

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
        
        var subtotal = await cartService.CalculateSubtotal(query.Ctx, ct);

        if (!subtotal.IsSuccess)
        {
            return subtotal.Problem;
        }
        
        if (country is null || selectedShippingMethod is null)
        {
            return new CheckoutStats
            {
                Status = checkoutSession.Status,
                Subtotal = subtotal.Value,
                Tax = null,
                Total = null,
                ShippingCost = null,
                AddCostForFreeShipping = null,
                EligibleForFreeShipping = false
            };
        }
        
        var financials = FinancialsCalculator.Calculate(input: new FinancialsCalculationsInput
        {
            Subtotal = subtotal.Value,
            TaxRate = country.TaxRate,
            ShippingFlatFee = selectedShippingMethod.FlatFee,
            FreeShippingThreshold = selectedShippingMethod.FreeShippingThreshold
        });
        
        return new CheckoutStats
        {
            Status = checkoutSession.Status,
            Subtotal = subtotal.Value,
            Tax = financials.Tax,
            Total = financials.Total,
            ShippingCost = financials.ShippingCost,
            AddCostForFreeShipping = financials.AddCostForFreeShipping,
            EligibleForFreeShipping = financials.EligibleForFreeShipping
        };
    }
}