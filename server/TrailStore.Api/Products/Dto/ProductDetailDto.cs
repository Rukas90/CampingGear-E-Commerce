namespace TrailStore.Api.Products.Dto;

public class ProductDetailDto : ProductSummaryDto
{
    public string          Description { get; init; }
    public ProductSkuDto[] Skus        { get; init; } = [];
}