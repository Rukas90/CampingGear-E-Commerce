using Microsoft.EntityFrameworkCore;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Ordering.Infrastructure.Database;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Ordering.Infrastructure.Checkout;

[AppService<ISavedCheckoutDetailsRepository>]
public sealed class SavedCheckoutDetailsRepository(OrderingDbContext _context) 
    : AggregateRepository<SavedCheckoutDetails, OrderingDbContext>(_context), ISavedCheckoutDetailsRepository
{
    public Task<SavedCheckoutDetails?> FindByUserIdAsync(Id<UserRef> userId, CancellationToken ct)
        => AggregateWriteQuery.Where(details => details.UserId == userId).SingleOrDefaultAsync(ct);
}