using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Application.Commands.AddToCart;

[AppService<AddToCartCommandHandler>]
public class AddToCartCommandHandler(
    ICartSessionService cartSessionService, IBasketUnitOfWork unitOfWork) 
    : ICommandHandler<AddToCartCommand, Id<Cart>>
{
    public async Task<Result<Id<Cart>>> Handle(AddToCartCommand command, CancellationToken ct)
    {
        var cart = await cartSessionService.FindOrCreateCart(command.cartId, command.userId, ct);
        
        var result = cart.AddItem(command.SkuId, command.Quantity);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        await unitOfWork.SaveAsync(ct);
        
        return cart.Id;
    }
}