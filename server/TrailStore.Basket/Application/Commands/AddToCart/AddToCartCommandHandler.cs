using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Application.Commands.AddToCart;

[AppService<AddToCartCommandHandler>]
public class AddToCartCommandHandler(
    IShoppingSessionService shoppingSessionService, IBasketUnitOfWork unitOfWork) 
    : ICommandHandler<AddToCartCommand, Id<ShoppingSession>>
{
    public async Task<Result<Id<ShoppingSession>>> Handle(AddToCartCommand command, CancellationToken ct)
    {
        var session = await shoppingSessionService.FindOrCreateSession(command.ctx, ct);
        
        session.AddCartItem(command.SkuId, command.Quantity);

        await unitOfWork.SaveAsync(ct);

        return session.Id;
    }
}