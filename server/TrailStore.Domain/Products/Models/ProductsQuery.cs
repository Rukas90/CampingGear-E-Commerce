using TrailStore.Domain.Shared.Enums;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Products.Models;

public class ProductsQuery
{
    public Specification<Product>? Specification { get; init; }
    public ProductsSortBy SortBy { get; init; }
    public bool Pagination { get; init; }
    public int Page { get; init; }
    public int PageSize { get; init; }
}