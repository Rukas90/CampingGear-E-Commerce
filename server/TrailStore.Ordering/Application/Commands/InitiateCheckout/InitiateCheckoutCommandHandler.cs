using TrailStore.Basket.Contracts.Carts;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.Commands.InitiateCheckout;

[AppService<InitiateCheckoutCommandHandler>]
public sealed class InitiateCheckoutCommandHandler(
    ICartService cartService,
    ICheckoutSessionService checkoutSessionService, 
    IOrderingUnitOfWork unitOfWork) : ICommandHandler<InitiateCheckoutCommand>
{
    public async Task<Result> Handle(InitiateCheckoutCommand command, CancellationToken ct)
    {
        var items = await cartService.GetCartItems(command.Ctx, ct);

        if (items.Length <= 0)
        {
            return CheckoutProblems.EmptyCart;
        }
        
        var result = await checkoutSessionService.GetCreateCheckoutSession(command.Ctx, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        await unitOfWork.SaveAsync(ct);
        
        return Result.Ok();
    }
}