using TrailStore.Api.Reviews.Dto;
using TrailStore.Domain.Reviews.Models;
using TrailStore.Domain.Reviews.Specifications;
using TrailStore.Domain.Shared.Enums;

namespace TrailStore.Api.Reviews.Mapping;

public static class ReviewsMapping
{
    public static ReviewsQuery ToQuery(this ReviewsRequest request)
    {
        return new ReviewsQuery
        {
            Specification = ReviewsSpecificationBuilder.BuildFromFilter(request.Filter ?? ReviewsFilter.AllStars),
            SortBy = request.SortBy ?? ReviewsSortBy.MostRecent,
            Pagination = request.Page.HasValue,
            Page = request.Page ?? 0,
            PageSize = request.PageSize ?? 10
        };
    }
}