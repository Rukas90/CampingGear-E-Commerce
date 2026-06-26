using TrailStore.Identity.Contracts.Users;
using TrailStore.Identity.Domain.Users;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Infrastructure.Users;

[AppService<IUserService>]
public sealed class UserService(IUserRepository userRepository) : IUserService
{
    public Task<UserProfileSnapshot[]> GetUserProfilesAsync(
        Id<UserRef>[] ids, CancellationToken ct) => userRepository.GetProfilesAsync(
            ids.Select(id => Id<User>.From(id)).ToArray(), ct);
}