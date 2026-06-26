using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Reviews.Models;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Reviews.Specifications;

public static class ReviewsSpecifications
{
    public static Specification<Review> ProductId(Id<Product> id)
        => Specification<Review>.Where(review => review.ProductId == id);
    
    public static Specification<Review> Rating(int rating)
    {
        return Specification<Review>.Where(review => review.Rating == rating);
    }
}