namespace TrailStore.Api.Products.Dto;

public class ProductSummaryDto
{
    public required string  Name          { get; init; }
    public required string  Slug          { get; init; }
    public required string  BrandName     { get; init; }
    public required string  BrandSlug     { get; init; }
    public required string  Category      { get; init; }
    public decimal          MinPrice      { get; init; }
    public decimal          MaxPrice      { get; init; }
    public double           AverageRating { get; init; }
    public int              ReviewCount   { get; init; }
    public bool             InStock       { get; init; }
    public string?          ThumbnailUrl  { get; init; }
}