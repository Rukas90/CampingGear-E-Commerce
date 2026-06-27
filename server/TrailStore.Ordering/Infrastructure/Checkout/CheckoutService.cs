using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Addresses;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Infrastructure.Checkout;

[AppService<ICheckoutService>]
internal sealed class CheckoutService(
    IShippingMethodRepository shippingMethodRepository) : ICheckoutService
{
    public async Task<ShippingMethod?> ValidateCheckoutShipping(
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
    
    public async Task<ShippingMethod?> GetShippingMethod(
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
}