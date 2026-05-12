using TrailStore.Domain.Shared.Enums;

namespace TrailStore.Domain.Reviews.Models;

public class ReviewsQuery
{
    public string? ProductSlug { get; init; }
    public ReviewsFilter Filter { get; init; }
    public ReviewsSortBy SortBy { get; init; }
    public bool Pagination { get; init; }
    public int Page { get; init; }
    public int PageSize { get; init; }
}