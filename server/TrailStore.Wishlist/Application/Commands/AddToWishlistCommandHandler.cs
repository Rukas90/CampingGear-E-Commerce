using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Wishlist.Application.Abstractions;
using TrailStore.Wishlist.Domain;

namespace TrailStore.Wishlist.Application.Commands;

[AppService<AddToWishlistCommandHandler>]
public sealed class AddToWishlistCommandHandler(
    IWishlistRepository repository, IWishlistUnitOfWork unitOfWork) : ICommandHandler<AddToWishlistCommand>
{
    public async Task<Result> Handle(AddToWishlistCommand command, CancellationToken ct)
    {
        var wishlist = await repository.FindByUserId(command.UserId, ct);

        if (wishlist is not null)
        {
            wishlist.AddItem(command.SkuId);

            await unitOfWork.SaveAsync(ct);
            
            return Result.Ok();
        }

        wishlist = CustomerWishlist.Create(command.UserId);
       
        var result = wishlist.AddItem(command.SkuId);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        repository.Add(wishlist);
        
        await unitOfWork.SaveAsync(ct);
            
        return Result.Ok();
    }
}