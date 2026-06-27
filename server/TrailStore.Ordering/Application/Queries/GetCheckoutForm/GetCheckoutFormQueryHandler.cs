using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.Queries.GetCheckoutForm;

[AppService<GetCheckoutFormQueryHandler>]
public class GetCheckoutFormQueryHandler(
    ICheckoutSessionService checkoutSessionService,
    ICheckoutService checkoutService) : IQueryHandler<GetCheckoutFormQuery, CheckoutForm>
{
    public async Task<Result<CheckoutForm>> Handle(GetCheckoutFormQuery query, CancellationToken ct)
    {
        var result = await checkoutSessionService.GetCreateCheckoutSession(query.Ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var session = result.Value;

        var selectedShippingMethod 
            = await checkoutService.GetShippingMethod(session.ShippingMethodId, session.ShippingAddress, ct);
        
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
}