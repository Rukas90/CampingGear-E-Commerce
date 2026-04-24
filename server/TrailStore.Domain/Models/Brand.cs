using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public class Brand : IModel<Brand>
{
    public required Id<Brand> Id          { get; init; }
    public required string    Name        { get; init; }
    public string?            Description { get; init; }
    public required string    Slug        { get; init; }
    public required string    LogoUrl     { get; init; }
    public required string    WebsiteUrl  { get; init; }
    
    public IReadOnlyList<Product> Products { get; private set; } = [];
    
    public static Brand Create(Id<Brand> id, string name, string slug, string logoUrl, string websiteUrl, string description = "")
        => new()
        {
            Id          = id,
            Name        = name,
            Slug        = slug,
            LogoUrl     = logoUrl,
            WebsiteUrl  = websiteUrl,
            Description = description
        };
    
    public static Brand Create(string name, string slug, string logoUrl, string websiteUrl, string description = "")
        => new()
        {
            Id          = Id<Brand>.Part(slug).Build(),
            Name        = name,
            Slug        = slug,
            LogoUrl     = logoUrl,
            WebsiteUrl  = websiteUrl,
            Description = description
        };
}