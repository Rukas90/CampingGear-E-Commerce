using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Contracts.Users;

public interface IUserService
{
    Task<UserProfileSnapshot?> GetUserProfileAsync(Id<UserRef> id, CancellationToken ct);
    
    Task<UserProfileSnapshot[]> GetUserProfilesAsync(Id<UserRef>[] ids, CancellationToken ct);
}