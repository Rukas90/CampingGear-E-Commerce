using Isopoh.Cryptography.Argon2;
using TrailStore.Shared.DependencyInjection;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Shared.Infrastructure.Security;

[AppService<IPasswordHasher>]
public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return Argon2.Hash(password);
    }

    public bool Verify(string password, string hash)
    {
        return Argon2.Verify(hash, password);
    }
}