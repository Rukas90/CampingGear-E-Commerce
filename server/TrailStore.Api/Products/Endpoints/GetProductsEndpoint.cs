using FastEndpoints;
using TrailStore.Api.Products.Bindings;
using TrailStore.Api.Products.Dto;
using TrailStore.Api.Products.Mapping;
using TrailStore.Domain.Products.Interfaces;
using TrailStore.Domain.Products.Models;
using TrailStore.Domain.Products.Specifications;

namespace TrailStore.Api.Products.Endpoints;

public class GetProductsEndpoint(IProductsRepository productsRepository)
    : Endpoint<ProductsRequest, IEnumerable<ProductSummaryDto>>
{
    public override void Configure()
    {
        Get("/api/v1/products");
        AllowAnonymous();
        RequestBinder(new ProductsRequestBinder());
    }

    public override async Task<IEnumerable<ProductSummaryDto>> ExecuteAsync(ProductsRequest req, CancellationToken ct)
    {
        var filter = req.MapToFilter();

        return await productsRepository.ListAsync(new ProductsQuery
        {
            Specification = ProductsSpecificationBuilder.Build(filter),
            SortBy = filter.SortBy,
            Pagination = filter.Pagination,
            Page = filter.Page,
            PageSize = 30
        }, ProductMappingSelectors.ToSummaryDto());
    }
}