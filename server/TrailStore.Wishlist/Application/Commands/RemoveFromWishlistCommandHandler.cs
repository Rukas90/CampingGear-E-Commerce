using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Wishlist.Application.Abstractions;
using TrailStore.Wishlist.Domain;

namespace TrailStore.Wishlist.Application.Commands;

[AppService<RemoveFromWishlistCommandHandler>]
public sealed class RemoveFromWishlistCommandHandler(
    IWishlistRepository repository, IWishlistUnitOfWork unitOfWork) : ICommandHandler<RemoveFromWishlistCommand>
{
    public async Task<Result> Handle(RemoveFromWishlistCommand command, CancellationToken ct)
    {
        var wishlist = await repository.FindByUserId(command.UserId, ct);

        if (wishlist is null)
        {
            return WishlistProblems.NotFound;
        }

        var result = wishlist.RemoveItem(command.SkuId);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        await unitOfWork.SaveAsync(ct);
            
        return Result.Ok();
    }
}