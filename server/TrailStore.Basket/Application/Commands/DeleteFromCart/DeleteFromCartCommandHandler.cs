using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Application.Commands.DeleteFromCart;

[AppService<DeleteFromCartCommandHandler>]
public class DeleteFromCartCommandHandler(
    IShoppingSessionService shoppingSessionService, IBasketUnitOfWork unitOfWork) 
    : ICommandHandler<DeleteFromCartCommand, Id<ShoppingSession>>
{
    public async Task<Result<Id<ShoppingSession>>> Handle(DeleteFromCartCommand command, CancellationToken ct)
    {
        var session = await shoppingSessionService.FindSession(command.ctx, ct);

        if (!session.IsSuccess)
        {
            return session.Problem;
        }
        
        try
        {
            var result = session.Value.RemoveCartItem(command.ItemId);

            if (!result.IsSuccess)
            {
                return result.Problem;
            }

            await unitOfWork.SaveAsync(ct);

            return session.Value.Id;
        }
        catch (Exception e)
        {
            return CartProblems.UnexpectedProblem(e.Message);
        }
    }
}