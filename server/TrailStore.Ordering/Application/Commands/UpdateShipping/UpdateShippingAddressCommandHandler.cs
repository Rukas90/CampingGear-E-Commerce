using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.Commands.UpdateShipping;

[AppService<UpdateShippingAddressCommandHandler>]
public sealed class UpdateShippingAddressCommandHandler(
    ICheckoutSessionService checkoutSessionService, 
    ICheckoutService checkoutService,
    IOrderingUnitOfWork unitOfWork)
    : ICommandHandler<UpdateShippingAddressCommand, CheckoutShipping>
{
    public async Task<Result<CheckoutShipping>> Handle(
        UpdateShippingAddressCommand command, CancellationToken ct)
    {
        var result = await checkoutSessionService.GetCreateCheckoutSession(command.CartId, command.UserId, ct);
        
        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        var session = result.Value;
        
        session.ShippingAddress = command.Address;
        
        var selectedMethod = await checkoutService.ValidateCheckoutShipping(session, ct);

        await unitOfWork.SaveAsync(ct);
        
        return new CheckoutShipping
        {
            Address = session.ShippingAddress,
            SelectedMethodId = selectedMethod?.Id
        };
    }
}