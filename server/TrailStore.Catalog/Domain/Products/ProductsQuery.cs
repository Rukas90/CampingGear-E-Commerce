using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Products;

public class ProductsQuery
{
    public Specification<Product>? Specification { get; init; }
    public ProductsSortBy SortBy { get; init; }
    public bool Pagination { get; init; }
    public int Page { get; init; }
    public int PageSize { get; init; }
}