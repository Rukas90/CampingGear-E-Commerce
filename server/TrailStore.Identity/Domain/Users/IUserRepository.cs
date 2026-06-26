using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Domain.Users;

public interface IUserRepository : IAggregateRepository<User>
{
    Task<UserProfileSnapshot[]> GetProfilesAsync(Id<User>[] ids, CancellationToken ct);
    
    Task<User?> FindByEmailAsync(string email, CancellationToken ct);
    
    Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);
}