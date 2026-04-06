using FastEndpoints;
using TrailStore.Api.Products.Dto;
using TrailStore.Domain.Models;

namespace TrailStore.Api.Products.Endpoints;

public class GetProductEndpoint : Endpoint<ProductRequest, Product>
{
    public override void Configure()
    {
        Get("product/{id}");
        AllowAnonymous();
    }
    public override Task<Product> ExecuteAsync(ProductRequest req, CancellationToken ct)
    {
        return null;
    }
}