using TrailStore.Catalog.Application.Results;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Catalog.Application.Queries.GetProducts;

public sealed record GetProductsQuery(
    ProductsSortBy? SortBy, 
    string[]? Brand, 
    string[]? Category, 
    bool? Pagination,
    int? Page,
    int? PageSize,
    decimal? PriceGte,
    decimal? PriceLte,
    Availability? Availability,
    Dictionary<string, string>? Option,
    string[]? SkuCode) : IQuery<ProductSummaryResult[]>;