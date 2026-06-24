namespace TrailStore.Basket.Api.Endpoints;

public class AddToCartRequest
{
    public Guid SkuId { get; set; }
    public int Quantity { get; set; }
}