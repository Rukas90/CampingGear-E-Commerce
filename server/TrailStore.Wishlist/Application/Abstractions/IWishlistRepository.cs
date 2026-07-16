using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Wishlist.Domain;

namespace TrailStore.Wishlist.Application.Abstractions;

public interface IWishlistRepository : IAggregateRepository<CustomerWishlist>
{
    Task<CustomerWishlist?> FindByUserId(Id<UserRef> userId, CancellationToken ct);
}