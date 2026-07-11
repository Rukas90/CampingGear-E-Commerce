using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Application.Commands.UpdateCartItemQuantity;

[AppService<UpdateCartItemQuantityCommandHandler>]
public class UpdateCartItemQuantityCommandHandler(
    ICartSessionService cartSessionService, IBasketUnitOfWork unitOfWork) 
    : ICommandHandler<UpdateCartItemQuantityCommand, Id<Cart>>
{
    public async Task<Result<Id<Cart>>> Handle(UpdateCartItemQuantityCommand command, CancellationToken ct)
    {
        var cart = await cartSessionService.FindOrCreateCart(command.cartId, command.userId, ct);

        var result = cart.UpdateItemQuantity(command.ItemId, command.NewQuantity);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        await unitOfWork.SaveAsync(ct);

        return cart.Id;
    }
}