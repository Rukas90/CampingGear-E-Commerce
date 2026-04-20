using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Products.Dto;

public class ProductRequest
{
    public string Slug { get; set; }
}