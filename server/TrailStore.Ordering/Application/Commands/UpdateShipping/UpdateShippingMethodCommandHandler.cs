using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Addresses;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.Commands.UpdateShipping;

[AppService<UpdateShippingMethodCommandHandler>]
public sealed class UpdateShippingMethodCommandHandler(
    ICheckoutSessionService checkoutSessionService,
    IOrderingUnitOfWork unitOfWork)
    : ICommandHandler<UpdateShippingMethodCommand>
{
    public async Task<Result> Handle(
        UpdateShippingMethodCommand command, CancellationToken ct)
    {
        var result = await checkoutSessionService.GetCreateCheckoutSession(command.Ctx, ct);
        
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
        
        session.ShippingMethodId = command.ShippingMethodId;
        
        await unitOfWork.SaveAsync(ct);
        
        return Result.Ok();
    }
}