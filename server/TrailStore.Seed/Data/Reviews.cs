using System.Text.Json;
using Bogus;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Seed.Data;

// ReSharper disable All
public static class Reviews
{
    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
        { PropertyNameCaseInsensitive = true };

    [SeededEntity] public static readonly List<Review> All = GenerateAll();

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
                var reviewId = Id<Review>.Part(product.Slug).Part(template.Headline).Build();

                reviews.Add(new Review
                {
                    Id = reviewId,
                    CustomerId = customer.Id,
                    ProductId = product.Id,
                    CreatedAt = faker.Date.Past(3).ToUniversalTime(),
                    Rating = template.Rating,
                    Headline = template.Headline,
                    Recommended = template.Recommended,
                    Text = template.Text,
                    Votes = GenerateVotes(reviewId, faker)
                });
            }
        }

        return reviews;
    }
    
    private static List<ReviewVote> GenerateVotes(Id<Review> reviewId, Faker faker)
    {
        var voters = faker.PickRandom(Customers.All, faker.Random.Int(0, 40)).DistinctBy(c => c.Id).ToList();
    
        return voters.Select(customer => new ReviewVote
        {
            Id = Id<ReviewVote>.Part(reviewId.ToString()).Part(customer.Id.ToString()).Build(),
            ReviewId = reviewId,
            IsLike = faker.Random.Bool(0.85f),
            CreatedAt = faker.Date.Past(3).ToUniversalTime()
        }).ToList();
    }

    private static Dictionary<string, List<ReviewTemplate>> LoadReviews()
    {
        var basePath = Path.GetDirectoryName(SeedAssembly.Reference.Location)!;

        var json = File.ReadAllText(
            Path.Combine(basePath, "Data", "Reviews.json"));

        return JsonSerializer.Deserialize<Dictionary<string, List<ReviewTemplate>>>(json, SerializerOptions)!;
    }

    private record ReviewTemplate(int Rating, bool Recommended, string Headline, string Text);
}