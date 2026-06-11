using TrailStore.Domain.Auth.Models;
using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class RefreshToken : IModel<RefreshToken>, IEntityCreatable, IEntityExpirable
{
    public required Id<RefreshToken> Id { get; init; }
    public required Id<Customer> CustomerId { get; init; }
    public required Id<RefreshTokenFamily> FamilyId { get; init; }
    public required string TokenHash { get; init; }
    public required string LookupHash { get; init; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public DateTime? RevokedAt { get; set; } = null;

    public Customer Customer { get; private set; } = null!;

    public static RefreshToken Create(
        Id<Customer> customerId,
        string tokenHash,
        string lookupHash,
        Id<RefreshTokenFamily>? familyId,
        TimeSpan expireTime)
        => new()
        {
            Id = Id<RefreshToken>.New(),
            CustomerId = customerId,
            TokenHash = tokenHash,
            LookupHash = lookupHash,
            FamilyId = familyId ?? Id<RefreshTokenFamily>.New(),
            ExpiresAt = DateTime.UtcNow.Add(expireTime)
        };

    public void Revoke()
    {
        RevokedAt = DateTime.UtcNow;
    }
}