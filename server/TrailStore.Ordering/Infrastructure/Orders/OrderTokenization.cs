using System.Security.Cryptography;

namespace TrailStore.Ordering.Infrastructure.Orders;

public static class OrderTokenization
{
    public const string Characters = "23456789abcdefghjkmnpqrstuvwxyz";
    public const int Length = 25;
    public const int GroupSize = 5;
    public const char Separator = '-';
    
    public static string GenerateToken()
    {
        var chars = new char[Length];
        var maxValid = 256 - 256 % Characters.Length;

        for (var i = 0; i < Length; i++)
        {
            byte b;
            do
            {
                b = RandomNumberGenerator.GetBytes(1)[0];
            } while (b >= maxValid);

            chars[i] = Characters[b % Characters.Length];
        }

        return new string(chars);

    }

    public static string ToDisplayToken(string token)
    {
        return string.Join(Separator, 
            Enumerable.Range(0, (token.Length + GroupSize - 1) / GroupSize)
                .Select(i => token.Substring(
                    i * GroupSize, 
                    Math.Min(GroupSize, token.Length - i * GroupSize))));
    }

    public static bool TryNormalizeToken(string input, out string token)
    {
        var normalized = new string(input.Where(char.IsLetterOrDigit).ToArray()).ToLowerInvariant();

        if (normalized.Length != Length)
        {
            token = string.Empty;
            
            return false;
        }
        
        token = normalized;

        return true;
    }
}