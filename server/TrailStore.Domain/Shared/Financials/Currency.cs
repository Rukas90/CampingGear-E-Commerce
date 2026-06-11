namespace TrailStore.Domain.Shared.Financials;

public class Currency
{
    public required string Code { get; init; }
    public required string Symbol { get; init; }
    public required decimal ExchangeRate { get; init; }
}