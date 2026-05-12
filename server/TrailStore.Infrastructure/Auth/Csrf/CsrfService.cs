using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using TrailStore.Domain.Auth.Interfaces;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Auth.Csrf;

[AppService<ICsrfService>]
public class CsrfService(IOptions<CsrfOptions> options) : ICsrfService
{
    private readonly CsrfOptions _options = options.Value;

    public string GenerateToken()
    {
        var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
        var signature = GenerateSignature(token);

        return $"{token}.{signature}";
    }

    public bool VerifyToken(string token)
    {
        var parts = token.Split('.');

        if (parts.Length != 2) return false;

        var expectedSignature = GenerateSignature(parts[0]);

        return CryptographicOperations.FixedTimeEquals(
            Convert.FromHexString(parts[1]), Convert.FromHexString(expectedSignature));
    }

    private string GenerateSignature(string value)
    {
        var keyBytes = Encoding.UTF8.GetBytes(_options.SecretKey);
        var valueBytes = Encoding.UTF8.GetBytes(value);

        return Convert.ToHexString(HMACSHA256.HashData(keyBytes, valueBytes));
    }
}