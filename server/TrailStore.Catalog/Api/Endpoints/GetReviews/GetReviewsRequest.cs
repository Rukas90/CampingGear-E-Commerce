using TrailStore.Catalog.Domain.Reviews.Enums;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Api.Endpoints.GetReviews;

public sealed class GetReviewsRequest
{
    public required Slug Slug { get; set; }
    public int? Page { get; init; }
    public int? PageSize { get; init; }
    public ReviewsSortBy? SortBy { get; init; }
    public StarFilter? StarFilter { get; init; }
}