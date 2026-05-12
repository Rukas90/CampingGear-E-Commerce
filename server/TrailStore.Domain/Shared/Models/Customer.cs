using System.ComponentModel.DataAnnotations;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public enum Privileges
{
    User,
    Admin
}

public class Customer : IModel<Customer>
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }

    [MaxLength(254)] public required string Email { get; init; }

    public required string PasswordHash { get; init; }
    public Privileges Privileges { get; init; } = Privileges.User;

    public Cart Cart { get; private set; } = null!;
    public ICollection<Review> Reviews { get; private set; } = [];
    public ICollection<Address> Addresses { get; private set; } = [];
    public ICollection<RefreshToken>? RefreshTokens { get; private set; } = [];
    public required Id<Customer> Id { get; init; }
}