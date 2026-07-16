using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Abstractions;

public interface ISavedCheckoutDetailsRepository : IAggregateRepository<SavedCheckoutDetails>
{
    Task<SavedCheckoutDetails?> FindByUserIdAsync(Id<UserRef> userId, CancellationToken ct);
}