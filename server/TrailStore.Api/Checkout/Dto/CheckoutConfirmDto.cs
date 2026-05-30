namespace TrailStore.Api.Checkout.Dto;

public class CheckoutConfirmDto
{
    public bool CheckoutConfirmed { get; init; }
    public bool CheckoutFailed { get; init; }
    public bool CheckoutLost { get; init; }
}