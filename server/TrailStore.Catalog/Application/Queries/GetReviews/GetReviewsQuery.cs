using TrailStore.Catalog.Application.Results;
using TrailStore.Catalog.Domain.Reviews.Enums;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Application.Queries.GetReviews;

public sealed record GetReviewsQuery(
    Slug ProductSlug,
    StarFilter StarFilter,
    ReviewsSortBy SortBy,
    bool Pagination,
    int Page,
    int PageSize) : IQuery<ReviewResult[]>;