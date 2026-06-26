using TrailStore.Catalog.Domain.Products;
using TrailStore.Catalog.Domain.Reviews.Enums;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Reviews.Inputs;

public sealed class ReviewsFilter
{
    public Id<Product> ProductId { get; init; }
    public StarFilter StarFilter { get; init; }
    public ReviewsSortBy SortBy { get; init; }
    public bool Pagination { get; init; }
    public int Page { get; init; }
    public int PageSize { get; init; }
}