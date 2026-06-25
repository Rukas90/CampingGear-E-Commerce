using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Application.Results;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Application.Queries.GetCart;

[AppService<GetCartQueryHandler>]
public class GetCartQueryHandler(
    ISkuService skuService,
    IShoppingSessionService shoppingSessionService) : IQueryHandler<GetCartQuery, CartResult>
{
    public async Task<Result<CartResult>> Handle(GetCartQuery query, CancellationToken ct)
    {
        var session = await shoppingSessionService.FindSession(query.ctx, ct);

        if (!session.IsSuccess)
        {
            return session.Problem;
        }
        
        try
        {
            var items = session.Value.CartItems;

            if (items.Count == 0)
            {
                return CartResult.Empty;
            }
            
            var ids = items.Select(i => i.SkuId).ToArray();
            var skus = await skuService.GetSkusFromIds(ids, ct);

            return new CartResult(session.Value.Id, items.ToResultItems(skus));
        }
        catch (Exception e)
        {
            return CartProblems.UnexpectedProblem(e.Message);
        }
    }
}