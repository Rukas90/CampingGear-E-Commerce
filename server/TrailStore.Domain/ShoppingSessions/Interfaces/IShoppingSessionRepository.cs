using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.ShoppingSessions.Interfaces;

public interface IShoppingSessionRepository
{
    Task<ShoppingSession?> FindByIdAsync(Id<ShoppingSession> id, CancellationToken ct);
    
    Task<ShoppingSession?> FindByCustomerIdAsync(Id<Customer> id, CancellationToken ct);

    ShoppingSession Add(ShoppingSession shoppingSession);
}