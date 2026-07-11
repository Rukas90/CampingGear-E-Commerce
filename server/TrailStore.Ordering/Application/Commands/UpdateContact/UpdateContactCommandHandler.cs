using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.Commands.UpdateContact;

[AppService<UpdateContactCommandHandler>]
public sealed class UpdateContactCommandHandler(
    ICheckoutSessionService checkoutSessionService, IOrderingUnitOfWork unitOfWork)
    : ICommandHandler<UpdateContactCommand>
{
    public async Task<Result> Handle(UpdateContactCommand command, CancellationToken ct)
    {
        var result = await checkoutSessionService.GetCreateCheckoutSession(
            command.CartId, command.UserId, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        var session = result.Value;
        
        session.EmailAddress = command.Data.EmailAddress;

        await unitOfWork.SaveAsync(ct);
        
        return Result.Ok();
    }
}