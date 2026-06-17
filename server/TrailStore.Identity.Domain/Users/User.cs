using System.ComponentModel.DataAnnotations;
using TrailStore.Identity.Domain.RefreshTokens;
using TrailStore.Shared.Domain;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Domain.Users;

public class User : AggregateRoot<User>, IEntityCreatable
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }

    [MaxLength(254)]
    public required string Email { get; init; }

    public required string PasswordHash { get; init; }
    public Privileges Privileges { get; init; } = Privileges.User;

    public DateTime CreatedAt { get; set; }
    
    public static User Create(string email, string passwordHash)
        => new()
        {
            Id = Id<User>.New(),
            Email = email,
            PasswordHash = passwordHash,
        };
}