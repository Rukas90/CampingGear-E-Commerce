using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Products.Dto;

public sealed class ProductSkuDto
{
    public required string Code { get; init; }
    public required decimal UnitPrice { get; init; }
    public required int Stock { get; init; }
    public required Id<Option>[] OptionIds { get; init; } = [];
}