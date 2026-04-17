namespace TrailStore.Api.Products.Dto;

public class ProductSummaryDto
{
    public Guid             Id            { get; init; }
    public required string  Name          { get; init; }
    public required string  Slug          { get; init; }
    public Guid             BrandId       { get; init; }
    public Guid             CategoryId    { get; init; }
    public decimal          PriceGte      { get; init; }
    public decimal          PriceLte      { get; init; }
    public double           AverageRating { get; init; }
    public int              ReviewCount   { get; init; }
    public bool             InStock       { get; init; }
    public string?          ImageUrl      { get; init; }
}