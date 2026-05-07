using Bogus;
using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Seed.Data;

// ReSharper disable All

public static class Customers
{
    [SeededEntity]
    public static readonly List<Customer> All = new Faker<Customer>()
        .UseSeed(94375185)
        .RuleFor(c => c.Id, f => 
            Id<Customer>.Part(f.Name.FullName()).Part(f.IndexFaker.ToString()).Build())
        .RuleFor(c => c.FirstName, f => f.Name.FirstName())
        .RuleFor(c => c.LastName, f => f.Name.LastName())
        .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.FirstName, c.LastName))
        .RuleFor(c => c.PasswordHash, SeedDefaults.NO_LOGIN_HASH)
        .Generate(75);
}