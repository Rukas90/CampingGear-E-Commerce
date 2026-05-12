using TrailStore.Domain.Shared.Enums;

namespace TrailStore.Api.Reviews.Dto;

public sealed record ReviewsRequest
{
    public required string Slug { get; set; }
    public int? Page { get; init; }
    public int? PageSize { get; init; }
    public ReviewsSortBy? SortBy { get; init; }
    public ReviewsFilter? Filter { get; init; }
}