using TrailStore.Identity.Api.Domain.Users;

namespace TrailStore.Identity.Api.Application.Abstractions;

public interface IJwtService
{
    string GenerateAccessToken(User user);
}