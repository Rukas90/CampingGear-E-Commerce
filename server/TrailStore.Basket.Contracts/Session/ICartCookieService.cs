namespace TrailStore.Basket.Contracts.Session;

public interface ICartCookieService
{
    void SyncCart(Guid next);

    void UpdateCart(Guid? id);

    Guid? GetId();

    void ClearCart();
}