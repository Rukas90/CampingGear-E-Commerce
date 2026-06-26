using TrailStore.Catalog.Domain.Products;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Reviews.Projections;

public record ReviewsSummary(Id<Product> ProductId, int ReviewsCount, double AverageRating);