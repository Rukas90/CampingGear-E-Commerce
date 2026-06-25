using TrailStore.Basket.Application.Results;

namespace TrailStore.Basket.Api.Endpoints.GetCart;

public static class CartResponseMapper
{
    public static CartItemResponse[] ToResponses(this IEnumerable<CartItemResult> items)
        => items.Select(ToResponse).ToArray();
    
    public static CartItemResponse ToResponse(this CartItemResult item)
        => new()
        {
            Id = item.Id,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            Stock = item.Stock,
            BrandName = item.BrandName,
            BrandSlug = item.BrandSlug,
            ProductName = item.ProductName,
            ProductSlug = item.ProductSlug,
            ThumbnailUrl = item.ThumbnailUrl,
            Options = item.Options.Select(option => new CartItemOptionResponse
            {
                GroupName = option.GroupName,
                ValueName = option.ValueName
            }).ToArray()
        };
}