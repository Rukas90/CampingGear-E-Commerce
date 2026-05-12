using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class Brand : IModel<Brand>
{
    public required Id<Brand> Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required string Slug { get; init; }
    public required string LogoUrl { get; init; }
    public required string WebsiteUrl { get; init; }

    public ICollection<Product> Products { get; private set; } = [];

    public static Brand Create(string name, string slug, string logoUrl, string websiteUrl, string description = "")
    {
        return new Brand
        {
            Id = Id<Brand>.Part(slug).Build(),
            Name = name,
            Slug = slug,
            LogoUrl = logoUrl,
            WebsiteUrl = websiteUrl,
            Description = description
        };
    }
}