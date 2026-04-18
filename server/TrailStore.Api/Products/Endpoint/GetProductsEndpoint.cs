using FastEndpoints;
using TrailStore.Api.Products.Binding;
using TrailStore.Api.Products.Dto;
using TrailStore.Api.Products.Mapping;
using TrailStore.Domain.Products;
using TrailStore.Infrastructure.Products;

namespace TrailStore.Api.Products.Endpoint;

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
        foreach (var (g, v) in req.Filter)
        {
            Console.WriteLine($"{g}: {v}");
        }
        
        var filter = req.MapToFilter();
        
        return await productsRepository.ListAsync(new ProductsQuery
        {
            Specification = ProductsSpecificationBuilder.Build(filter),
            SortBy        = filter.SortBy,
            Pagination    = filter.Pagination,
            Page          = filter.Page,
            PageSize      = 30
        }, selector: ProductMappingSelectors.ToSummaryDto());
    }
}