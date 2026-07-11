using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Application.Queries.GetSessionSummary;

[AppService<GetSessionSummaryQueryHandler>]
public sealed class GetSessionSummaryQueryHandler(
    ICartSessionService cartSessionService)
    : IQueryHandler<GetSessionSummaryQuery, ShoppingSessionSummary>
{
    public async Task<Result<ShoppingSessionSummary>> Handle(
        GetSessionSummaryQuery query, CancellationToken ct)
    {
        var result = await cartSessionService.FindCart(query.Ctx.CartId, query.Ctx.UserId, ct);
        
        if (!result.IsSuccess)
        {
            return ShoppingSessionSummary.Blank;
        }

        var session = result.Value;
        
        return new ShoppingSessionSummary(
            CartId: session.Id,
            CartCount: session.Items.Count,
            WishlistCount: 0);
    }
}