using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Contracts.Users;

public interface IUserService
{
    Task<UserProfileSnapshot[]> GetUserProfilesAsync(Id<UserRef>[] ids, CancellationToken ct);
}