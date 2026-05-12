using TrailStore.Domain.Carts.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Carts;

[AppService<ICartRepository>]
public class CartRepository(AppDbContext context) : ICartRepository
{
    public async Task<Cart> CreateAsync(Cart cart, CancellationToken ct)
    {
        await context.Carts.AddAsync(cart, ct);
        await context.SaveChangesAsync(ct);

        return cart;
    }
}