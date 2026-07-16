using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Application.Queries.GetCartSummary;

[AppService<GetCartSummaryQueryHandler>]
public sealed class GetCartSummaryQueryHandler(
    ICartSessionService cartSessionService)
    : IQueryHandler<GetCartSummaryQuery, CartSummary>
{
    public async Task<Result<CartSummary>> Handle(
        GetCartSummaryQuery query, CancellationToken ct)
    {
        var result = await cartSessionService.FindCart(query.Ctx.CartId, query.Ctx.UserId, ct);
        
        if (!result.IsSuccess)
        {
            return CartProblems.NotFound;
        }

        var cart = result.Value;
        
        return new CartSummary
        {
            CartId = cart.Id,
            ItemsCount = cart.Items.Count,
        };
    }
}