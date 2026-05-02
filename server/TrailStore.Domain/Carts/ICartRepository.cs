using TrailStore.Domain.Models;

namespace TrailStore.Domain.Carts;

public interface ICartRepository
{
    public Task<Cart> CreateAsync(Cart cart);
}