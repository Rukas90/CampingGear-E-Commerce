using TrailStore.Domain.Shared.Enums;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Reviews.Models;

public class ReviewsQuery
{
    public required Specification<Review> Specification { get; init; }
    public required ReviewsSortBy SortBy { get; init; }
    public required bool Pagination { get; init; }
    public required int Page { get; init; }
    public required int PageSize { get; init; }
}