using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Reviews.Specifications;

public static class ReviewsSpecifications
{
    public static Specification<Review> Rating(int rating)
    {
        return Specification<Review>.Where(review => review.Rating == rating);
    }
}