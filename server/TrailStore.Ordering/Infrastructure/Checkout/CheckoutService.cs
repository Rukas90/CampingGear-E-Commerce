using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Inventory.Contracts;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Addresses;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Payments.Contracts.Payments;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Infrastructure.Checkout;

[AppService<ICheckoutService>]
internal sealed class CheckoutService(
    IShippingMethodRepository shippingMethodRepository,
    IOrderService orderService,
    IInventoryService inventoryService,
    IPaymentService paymentService,
    ISavedCheckoutDetailsRepository savedCheckoutDetailsRepository) : ICheckoutService
{
    public async Task<ShippingMethod?> ValidateCheckoutShipping(
        CheckoutSession checkoutSession, CancellationToken ct)
    {
        var selectedMethod = await GetShippingMethod(
            checkoutSession.ShippingMethodId, checkoutSession.ShippingAddress, ct);
        
        if (checkoutSession.ShippingMethodId != selectedMethod?.Id)
        {
            checkoutSession.UpdateShippingMethodId(selectedMethod?.Id);
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
    
    public async Task<Result<Order>> CheckoutToOrder(
        Id<CartRef> cartId, ValidatedCheckoutInformation validatedInformation, CancellationToken ct)
    {
        var request = await orderService.BuildOrderCreationInput(
            Id<CartRef>.From(cartId), validatedInformation, ct);

        if (!request.IsSuccess) { return request.Problem; }

        var order = orderService.CreateOrder(request.Value);
        
        var reservation = await inventoryService.ReserveStock(
            order.Items.Select(item => new StockReserveItem(item.SkuId, item.Quantity)).ToArray(), ct);

        if (!reservation.IsSuccess) { return reservation.Problem; }
        
        var payment = await paymentService.CreatePayment(
            new PaymentCreationInput(order.Id, order.TotalPrice, request.Value.CurrencyCode, MaxAttempts: 3), ct);

        if (!payment.IsSuccess) { return payment.Problem; }

        return order;
    }

    public async Task PersistCheckoutDetails(
        Id<UserRef> UserId, ValidatedCheckoutInformation validatedInformation, CancellationToken ct)
    {
        var details = await savedCheckoutDetailsRepository.FindByUserIdAsync(UserId, ct);

        if (details is null)
        {
            savedCheckoutDetailsRepository.Add(
                SavedCheckoutDetails.Create(UserId, validatedInformation));
        }
        else
        {
            details.Snapshot(validatedInformation);
        }
    }

    public async Task ClearAnyPersistedCheckoutDetails(Id<UserRef> UserId, CancellationToken ct)
    {
        var details = await savedCheckoutDetailsRepository.FindByUserIdAsync(UserId, ct);

        if (details is null)
        {
            return;
        }
        
        savedCheckoutDetailsRepository.Delete(details);
    }
}