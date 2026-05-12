using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Products.Dto;

public sealed class ProductOptionDto
{
    public required Id<Option> Id { get; init; }
    public required string Name { get; init; }
    public required int SortOrder { get; init; }
    public required bool InStock { get; init; }
    public PreviewType? PreviewType { get; init; }
    public string? PreviewValue { get; init; }
}