namespace TrailStore.Basket.Api.Endpoints.GetSessionSummary;

public sealed class SessionSummaryResponse
{
    public int CartCount { get; init; }
    public int WishlistCount { get; init; }
}