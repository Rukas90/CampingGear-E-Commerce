using TrailStore.Catalog.Domain.Reviews.Enums;
using TrailStore.Catalog.Domain.Reviews.Inputs;
using TrailStore.Catalog.Domain.Reviews.Models;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Reviews.Specifications;

public static class ReviewsSpecificationBuilder
{
    public static Specification<Review> Build(ReviewsFilter filter)
    {
        var spec = filter.StarFilter switch
        {
            StarFilter.OneStar => ReviewsSpecifications.Rating(1),
            StarFilter.TwoStars => ReviewsSpecifications.Rating(2),
            StarFilter.ThreeStars => ReviewsSpecifications.Rating(3),
            StarFilter.FourStars => ReviewsSpecifications.Rating(4),
            StarFilter.FiveStars => ReviewsSpecifications.Rating(5),
            _ => Specification<Review>.All
        };
        
        spec = spec.And(ReviewsSpecifications.ProductId(filter.ProductId));
        
        return spec;
    }
}