namespace TrailStore.Api.Products.Dto;

public class ProductSkuDto
{
    public Guid           Id        { get; init; }
    public decimal        UnitPrice { get; init; }
    public int            Stock     { get; init; }
    public string?        ImageUrl  { get; init; }
    public SkuOptionDto[] Options   { get; init; } = [];
}