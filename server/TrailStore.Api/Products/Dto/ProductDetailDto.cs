using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Products.Dto;

public sealed class ProductDetailDto : ProductSummaryDto
{
    public string?                 Description { get; init; }
    public ProductSkuDto[]         Skus        { get; init; } = [];
    public ProductOptionGroupDto[] Options     { get; init; } = [];
    public ProductImageDto[]       Images      { get; init; } = [];
}

public sealed class ProductImageDto
{
    public required Id<Option>?          OptionId { get; init; }
    public required ProductImageUrlDto[] Urls     { get; init; } = [];
}

public sealed class ProductImageUrlDto
{
    public required string Url       { get; init; }
    public required int    SortOrder { get; init; }
}