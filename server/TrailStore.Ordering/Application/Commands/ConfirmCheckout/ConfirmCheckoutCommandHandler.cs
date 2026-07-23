using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Application.Results;
using TrailStore.Ordering.Contracts.IntegrationEvents;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.Commands.ConfirmCheckout;

[AppService<ConfirmCheckoutCommandHandler>]
public sealed class ConfirmCheckoutCommandHandler(
    ICheckoutSessionRepository checkoutSessionRepository,
    ICheckoutService checkoutService,
    IOrderingUnitOfWork unitOfWork,
    IOrderingOutbox outbox)
    : ICommandHandler<ConfirmCheckoutCommand, OrderCreatedResult>
{
    public async Task<Result<OrderCreatedResult>> Handle(ConfirmCheckoutCommand command, CancellationToken ct)
    {
        var checkoutSession = await checkoutSessionRepository.FindByCartIdAsync(command.cartId, ct);
        
        if (checkoutSession is null) { return CheckoutProblems.NoSession; }
        
        var validation = CheckoutSessionValidator.Validate(checkoutSession);
        
        if (!validation.IsSuccess) { return validation.Problem; }

        var validatedInformation = validation.Value;
        
        var order = await checkoutService.CheckoutToOrder(command.cartId, validatedInformation, ct);
        
        if (!order.IsSuccess) { return order.Problem; }
        
        outbox.AddMessage(new OrderCreatedIntegrationEvent(checkoutSession.CartId, checkoutSession.UserId));

        if (command.SaveInformation && checkoutSession.UserId is not null)
        {
            await checkoutService.PersistCheckoutDetails(checkoutSession.UserId.Value, validatedInformation, ct);
        }
        else if (!command.SaveInformation && checkoutSession.UserId is not null)
        {
            await checkoutService.ClearAnyPersistedCheckoutDetails(checkoutSession.UserId.Value, ct);
        }
        
        checkoutSessionRepository.Delete(checkoutSession);
        
        await unitOfWork.SaveAsync(ct);
        
        return Result.Success(new OrderCreatedResult(order.Value.Id));
    }
}