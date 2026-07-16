using FastEndpoints;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Problems;
using TrailStore.Wishlist.Application.Queries;

namespace TrailStore.Wishlist.Api.Endpoints.GetWishlistItems;

public sealed class GetWishlistItemsEndpoint(GetItemsQueryHandler query)
    : EndpointWithoutRequest<WishlistItemResponse[]>
{
    public override void Configure()
    {
        Get("/api/v1/wishlist");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var userId = User.GetSubjectTypedId<UserRef>();

        if (userId is null)
        {
            await this.SendProblemAsync(SharedAuthProblems.Unauthenticated);
            
            return;
        }
        
        var result = await query.Handle(new GetItemsQuery(userId.Value), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var items = result.Value;
        
        await Send.OkAsync(items.ToResponses(), ct);
    }
}