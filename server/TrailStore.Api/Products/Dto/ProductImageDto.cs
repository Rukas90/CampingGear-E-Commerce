using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Products.Dto;

public sealed class ProductImageDto
{
    public required Id<Option>?          OptionId { get; init; }
    public required ProductImageUrlDto[] Urls     { get; init; } = [];
}