using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Carts.Interfaces;

public interface ICartRepository
{
    public Task<Cart> CreateAsync(Cart cart);
}