using TrailStore.Basket.Application.Abstractions;
using TrailStore.Basket.Application.Results;
using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Application.Queries.GetCart;

[AppService<GetCartQueryHandler>]
public class GetCartQueryHandler(
    ISkuService skuService,
    ICartSessionService cartSessionService) : IQueryHandler<GetCartQuery, CartResult>
{
    public async Task<Result<CartResult>> Handle(GetCartQuery query, CancellationToken ct)
    {
        var cart = await cartSessionService.FindCart(query.cartId, query.userId, ct);

        if (!cart.IsSuccess)
        {
            return cart.Problem;
        }
        
        var items = cart.Value.Items;

        if (items.Count == 0)
        {
            return CartResult.Empty;
        }
            
        var ids = items.Select(i => i.SkuId).ToArray();
        var skus = await skuService.GetSkusFromIds(ids, ct);

        return new CartResult(cart.Value.Id, items.ToResultItems(skus));
    }
}