using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Products.Dto;

public class ProductRequest
{
    public Id<Product> Id { get; set; }
}