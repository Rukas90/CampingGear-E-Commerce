using Bogus;
using TrailStore.Identity.Api.Domain.Users;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Seeding;

namespace TrailStore.Identity.Api.Seed;

// ReSharper disable All
public static class Users
{
    public const string NO_LOGIN_HASH = "SEEDED_USER_NO_LOGIN";
    
    [SeededEntity] 
    public static readonly List<User> All = new Faker<User>()
        .UseSeed(94375185)
        .RuleFor(c => c.Id, f =>
            Id<User>.Part(f.Name.FullName()).Part(f.IndexFaker.ToString()).Build())
        .RuleFor(c => c.FirstName, f => f.Name.FirstName())
        .RuleFor(c => c.LastName, f => f.Name.LastName())
        .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.FirstName, c.LastName))
        .RuleFor(c => c.PasswordHash, NO_LOGIN_HASH)
        .Generate(75);
}