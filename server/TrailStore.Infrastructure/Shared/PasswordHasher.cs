using Isopoh.Cryptography.Argon2;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Shared;

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