using TrailStore.Domain.Enums;

namespace TrailStore.Api.Filters.Dto;

public record FiltersRequest
{
    public string? QueryBrand    { get; init; }
    public string? QueryCategory { get; init; }
    
     public string[]?                   Brand        { get; init; }
     public string[]?                   Category     { get; init; }
     public decimal?                    PriceGte     { get; init; }
     public decimal?                    PriceLte     { get; init; }
     public Availability?               Availability { get; init; }
     public Dictionary<string, string>? Option       { get; init; }
}