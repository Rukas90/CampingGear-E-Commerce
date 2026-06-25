using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Application.Commands.UpdateCartItemQuantity;

[AppService<UpdateCartItemQuantityCommandHandler>]
public class UpdateCartItemQuantityCommandHandler(
    IShoppingSessionService shoppingSessionService, IBasketUnitOfWork unitOfWork) 
    : ICommandHandler<UpdateCartItemQuantityCommand, Id<ShoppingSession>>
{
    public async Task<Result<Id<ShoppingSession>>> Handle(UpdateCartItemQuantityCommand command, CancellationToken ct)
    {
        var session = await shoppingSessionService.FindOrCreateSession(command.ctx, ct);

        try
        {
            session.UpdateCartItemQuantity(command.ItemId, command.NewQuantity);

            await unitOfWork.SaveAsync(ct);

            return session.Id;
        }
        catch (Exception e)
        {
            return CartProblems.UnexpectedProblem(e.Message);
        }
    }
}