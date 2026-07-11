using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Domain.RefreshTokens;

public class RefreshToken : IModel<RefreshToken>, IEntityCreatable, IEntityExpirable
{
    public required Id<RefreshToken> Id { get; init; }
    public required Id<RefreshFamily> FamilyId { get; init; }
    public required string TokenHash { get; init; }
    public required string LookupHash { get; init; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public DateTime? RevokedAt { get; set; } = null;
    
    public bool IsRevoked => RevokedAt is not null;
    public bool IsExpired => DateTime.UtcNow > ExpiresAt;
    
    internal static RefreshToken Create(
        Id<RefreshFamily> familyId,
        string tokenHash,
        string lookupHash,
        TimeSpan expireTime)
        => new()
        {
            Id = Id<RefreshToken>.New(),
            FamilyId = familyId,
            TokenHash = tokenHash,
            LookupHash = lookupHash,
            ExpiresAt = DateTime.UtcNow.Add(expireTime)
        };

    internal void Revoke()
    {
        RevokedAt = DateTime.UtcNow;
    }
}