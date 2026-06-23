using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Identity.Domain.Users;

public interface IUserRepository : IAggregateRepository<User>
{
    Task<User?> FindByEmailAsync(string email, CancellationToken ct);
    
    Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);
}