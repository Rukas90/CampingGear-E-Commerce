using TrailStore.Domain.Enums;

namespace TrailStore.Api.Reviews.Dto;

public sealed record ReviewsRequest
{
    public int?           Page     { get; init; }
    public int?           PageSize { get; init; }
    public ReviewsSortBy? SortBy   { get; init; }
    public ReviewsFilter? Filter   { get; init; }
}