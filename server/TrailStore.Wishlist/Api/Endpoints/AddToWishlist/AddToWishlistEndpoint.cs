using FastEndpoints;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Problems;
using TrailStore.Wishlist.Application.Commands;

namespace TrailStore.Wishlist.Api.Endpoints.AddToWishlist;

public sealed class AddToWishlistEndpoint(
    AddToWishlistCommandHandler command) : Endpoint<AddToWishlistRequest, string>
{
    public override void Configure()
    {
        Post("/api/v1/wishlist");
    }

    public override async Task HandleAsync(AddToWishlistRequest req, CancellationToken ct)
    {
        var userId = User.GetSubjectTypedId<UserRef>();

        if (userId is null)
        {
            await this.SendProblemAsync(SharedAuthProblems.Unauthenticated);
            
            return;
        }
        
        var result = await command.Handle(new AddToWishlistCommand(userId.Value, req.SkuId), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        await Send.OkAsync("Item was added to the wishlist.", ct);
    }
}