using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.Commands.UpdateBilling;

[AppService<UpdateBillingCommandHandler>]
public sealed class UpdateBillingCommandHandler(ICheckoutSessionService checkoutSessionService, IOrderingUnitOfWork unitOfWork)
    : ICommandHandler<UpdateBillingCommand>
{
    public async Task<Result> Handle(UpdateBillingCommand command, CancellationToken ct)
    {
        var result = await checkoutSessionService.GetCreateCheckoutSession(command.Ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        var session = result.Value;
        
        session.ShippingAddressAsBillingAddress = command.Data.AsShippingAddress;
        session.BillingAddress = command.Data.Address;

        await unitOfWork.SaveAsync(ct);
        
        return Result.Ok();
    }
}