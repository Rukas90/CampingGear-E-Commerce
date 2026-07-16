using Microsoft.EntityFrameworkCore;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;
using TrailStore.Wishlist.Application.Abstractions;
using TrailStore.Wishlist.Domain;
using TrailStore.Wishlist.Infrastructure.Database;

namespace TrailStore.Wishlist.Infrastructure;

[AppService<IWishlistRepository>]
public sealed class WishlistRepository(WishlistDbContext _context)
    : AggregateRepository<CustomerWishlist, WishlistDbContext>(_context), IWishlistRepository
{
    public Task<CustomerWishlist?> FindByUserId(Id<UserRef> userId, CancellationToken ct)
        => AggregateWriteQuery.Where(wishlist => wishlist.UserId == userId.Value).SingleOrDefaultAsync(ct);

    protected override IQueryable<CustomerWishlist> BuildAggregateQuery(DbSet<CustomerWishlist> set)
        => set.Include(wishlist => wishlist.Items);
}