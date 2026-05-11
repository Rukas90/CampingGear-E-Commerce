using System.Text.Json;
using Bogus;
using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Seed.Data;

// ReSharper disable All

public static class Reviews
{
    private record ReviewTemplate(int Rating, bool Recommended, string Headline, string Text);

    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
        { PropertyNameCaseInsensitive = true };
    
    [SeededEntity]
    public static readonly List<Review> All = GenerateAll();

    private static List<Review> GenerateAll()
    {
        var templates = LoadReviews();

        var products = SeedRunner.Discover<Product>(SeedAssembly.Reference).ToArray();

        var faker = new Faker { Random = new Randomizer(94375185) };
        var reviews = new List<Review>();

        foreach (var product in products)
        {
            if (!templates.TryGetValue(product.Slug, out var productReviews))
                continue;

            foreach (var template in productReviews)
            {
                var customer = faker.PickRandom(Customers.All);

                reviews.Add(new Review
                {
                    Id          = Id<Review>.Part(product.Slug).Part(template.Headline).Build(),
                    CustomerId  = customer.Id,
                    ProductId   = product.Id,
                    CreatedAt   = faker.Date.Past(3).ToUniversalTime(),
                    Rating      = template.Rating,
                    Headline    = template.Headline,
                    Recommended = template.Recommended,
                    Text        = template.Text,
                    Likes       = faker.Random.Int(0, 40),
                    Dislikes    = faker.Random.Int(0, 8),
                });
            }
        }

        return reviews;
    }
    
    private static Dictionary<string, List<ReviewTemplate>> LoadReviews()
    {
        var basePath = Path.GetDirectoryName(SeedAssembly.Reference.Location)!;
        
        var json = File.ReadAllText(
            Path.Combine(basePath, "Data", "Reviews.json"));
        
        return JsonSerializer.Deserialize<Dictionary<string, List<ReviewTemplate>>>(json, SerializerOptions)!;
    }
}