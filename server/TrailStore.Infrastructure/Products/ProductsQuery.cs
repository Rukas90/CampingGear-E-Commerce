using TrailStore.Domain.Enums;
using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Products;

public class ProductsQuery
{
    public Specification<Product>? Specification { get; init; }
    public SortBy                  SortBy        { get; init; }
    public int                     Page          { get; init; }
    public int                     PageSize      { get; init; }
}