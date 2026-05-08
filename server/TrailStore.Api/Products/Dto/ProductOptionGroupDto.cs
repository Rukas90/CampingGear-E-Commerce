namespace TrailStore.Api.Products.Dto;

public sealed class ProductOptionGroupDto
{
    public required string    Name      { get; init; }
    public int                SortOrder { get; init; }
    public ProductOptionDto[] Options   { get; init; } = [];
}