using TrailStore.Domain.Shared.Enums;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Reviews.Specifications;

public static class ReviewsSpecificationBuilder
{
    public static Specification<Review> BuildFromFilter(ReviewsFilter filter)
    {
        return filter switch
        {
            ReviewsFilter.OneStar => ReviewsSpecifications.Rating(1),
            ReviewsFilter.TwoStars => ReviewsSpecifications.Rating(2),
            ReviewsFilter.ThreeStars => ReviewsSpecifications.Rating(3),
            ReviewsFilter.FourStars => ReviewsSpecifications.Rating(4),
            ReviewsFilter.FiveStars => ReviewsSpecifications.Rating(5),
            _ => Specification<Review>.Blank
        };
    }
}