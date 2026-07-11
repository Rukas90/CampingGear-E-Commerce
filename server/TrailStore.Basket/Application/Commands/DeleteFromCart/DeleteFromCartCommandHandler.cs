using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Application.Commands.DeleteFromCart;

[AppService<DeleteFromCartCommandHandler>]
public class DeleteFromCartCommandHandler(
    ICartSessionService cartSessionService, IBasketUnitOfWork unitOfWork) 
    : ICommandHandler<DeleteFromCartCommand, Id<Cart>>
{
    public async Task<Result<Id<Cart>>> Handle(DeleteFromCartCommand command, CancellationToken ct)
    {
        var cart = await cartSessionService.FindCart(command.cartId, command.userId, ct);

        if (!cart.IsSuccess)
        {
            return cart.Problem;
        }
        
        var result = cart.Value.RemoveItem(command.ItemId);
        
        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        await unitOfWork.SaveAsync(ct);

        return cart.Value.Id;
    }
}