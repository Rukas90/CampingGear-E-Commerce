using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Application.Commands.EmptyCart;

[AppService<EmptyCartCommandHandler>]
public class EmptyCartCommandHandler(
    IShoppingSessionService shoppingSessionService, IBasketUnitOfWork unitOfWork)
    : ICommandHandler<EmptyCartCommand, Id<ShoppingSession>>
{
    public async Task<Result<Id<ShoppingSession>>> Handle(EmptyCartCommand command, CancellationToken ct)
    {
        var session = await shoppingSessionService.FindSession(command.ctx, ct);

        if (!session.IsSuccess)
        {
            return session.Problem;
        }
        
        try
        {
            session.Value.ClearCart();

            await unitOfWork.SaveAsync(ct);

            return session.Value.Id;
        }
        catch (Exception e)
        {
            return CartProblems.UnexpectedProblem(e.Message);
        }
    }
}