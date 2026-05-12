using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Auth.Interfaces;

public interface IJwtService
{
    string GenerateAccessToken(Customer customer);
}