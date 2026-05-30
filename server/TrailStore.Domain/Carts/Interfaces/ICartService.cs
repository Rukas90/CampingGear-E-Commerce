using System.Linq.Expressions;
using TrailStore.Domain.Carts.Models;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.ShoppingSessions.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Carts.Interfaces;

public interface ICartService
{
    Task<Result<Id<ShoppingSession>>> AddItemToCart(
        CartLineItem lineItem, ShoppingContext ctx, CancellationToken ct);

    Task<Result<Id<ShoppingSession>>> RemoveItemFromCart(
        string code, ShoppingContext ctx, CancellationToken ct);

    Task<Result<Id<ShoppingSession>>> EmptyCart(ShoppingContext ctx, CancellationToken ct);

    Task<Result<Id<ShoppingSession>>> UpdateCartItem(
        CartLineItem lineItem, ShoppingContext ctx, CancellationToken ct);
    
    Task<CartBag<TResult>> GetBag<TResult>(
        ShoppingContext ctx, Expression<Func<CartItem, TResult>> selector, CancellationToken ct);
}