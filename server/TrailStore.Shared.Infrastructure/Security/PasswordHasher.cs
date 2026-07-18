using Isopoh.Cryptography.Argon2;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Shared.Infrastructure.Security;

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