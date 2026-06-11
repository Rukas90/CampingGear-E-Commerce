using System.ComponentModel.DataAnnotations;
using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public enum Privileges
{
    User,
    Admin
}

public class Customer : IModel<Customer>, IEntityCreatable
{
    public required Id<Customer> Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }

    [MaxLength(254)]
    public required string Email { get; init; }

    public required string PasswordHash { get; init; }
    public Privileges Privileges { get; init; } = Privileges.User;

    public DateTime CreatedAt { get; set; }

    public ICollection<Review> Reviews { get; private set; } = [];
    public ICollection<Address> Addresses { get; private set; } = [];
    public ICollection<RefreshToken>? RefreshTokens { get; private set; } = [];

    public static Customer Create(string email, string passwordHash)
        => new()
        {
            Id = Id<Customer>.New(),
            Email = email,
            PasswordHash = passwordHash,
        };
}