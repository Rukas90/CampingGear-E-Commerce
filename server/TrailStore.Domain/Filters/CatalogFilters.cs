namespace TrailStore.Domain.Filters;

public class CatalogFilters
{
    public required FilterValue[]       Brands     { get; init; }
    public required FilterValue[]       Categories { get; init; }
    public required OptionGroupFilter[] Options    { get; init; }
    public required decimal             MinPrice   { get; init; }
    public required decimal             MaxPrice   { get; init; }
    public required int                 InStock    { get; init; }
    public required int                 OutOfStock { get; init; }
    
    public static CatalogFilters None => new()
    {
        Brands = [],
        Categories = [],
        InStock = 0,
        OutOfStock = 0,
        MinPrice = 0,
        MaxPrice = 0,
        Options = []
    };
}