namespace TrailStore.Ordering.Domain.Orders;

public static class OrderTokenConfig
{
    public const int RandomPartLength = 12;
    public const string Prefix = "TS-";
    public static readonly int TotalLength = Prefix.Length + RandomPartLength;
}