using TrailStore.Domain.Models;

namespace TrailStore.Domain.Auth;

public interface IJwtService
{
    string GenerateAccessToken(Customer customer);
}