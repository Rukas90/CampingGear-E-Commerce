using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Products;

public class Brand : IModel<Brand>
{
    public required Id<Brand> Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required string Slug { get; init; }
    public required string LogoUrl { get; init; }
    public required string WebsiteUrl { get; init; }
    
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