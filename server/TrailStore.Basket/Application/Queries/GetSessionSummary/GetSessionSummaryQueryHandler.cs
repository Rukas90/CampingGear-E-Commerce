using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Application.Queries.GetSessionSummary;

[AppService<GetSessionSummaryQueryHandler>]
public sealed class GetSessionSummaryQueryHandler(
    IShoppingSessionService shoppingSessionService)
    : IQueryHandler<GetSessionSummaryQuery, ShoppingSessionSummary>
{
    public async Task<Result<ShoppingSessionSummary>> Handle(
        GetSessionSummaryQuery query, CancellationToken ct)
    {
        var result = await shoppingSessionService.FindSession(query.Ctx, ct);
        
        if (!result.IsSuccess)
        {
            return ShoppingSessionSummary.Blank;
        }

        var session = result.Value;
        
        return new ShoppingSessionSummary(
            Id: session.Id,
            CartCount: session.CartItems.Count,
            WishlistCount: 0);
    }
}