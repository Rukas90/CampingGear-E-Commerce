using api.Products.Dto;
using api.Products.Models;
using FastEndpoints;

namespace api.Products.Endpoints;

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