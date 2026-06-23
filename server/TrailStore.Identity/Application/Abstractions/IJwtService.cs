using TrailStore.Identity.Domain.Users;

namespace TrailStore.Identity.Application.Abstractions;

public interface IJwtService
{
    string GenerateAccessToken(User user);
}