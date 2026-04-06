using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public class RefreshToken : IModel<RefreshToken>
{
    public required Id<RefreshToken> Id         { get; init; }
    public          Id<Customer>         UserId     { get; init; }
    public required string           FamilyId   { get; init; }
    public required string           TokenHash  { get; init; }
    public required string           LookupHash { get; init; }
    public required DateTime         CreatedAt  { get; init; }
    public required DateTime         ExpiresAt  { get; init; }
    public          DateTime?        RevokedAt  { get; set; } = null;

    public Customer Customer { get; private set; } = null!;
}