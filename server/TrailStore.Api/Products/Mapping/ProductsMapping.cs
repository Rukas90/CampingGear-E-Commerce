using TrailStore.Api.Products.Dto;
using TrailStore.Domain.Enums;
using TrailStore.Domain.Products;

namespace TrailStore.Api.Products.Mapping;

public static class ProductsMapping
{
    public static ProductsFilter MapToFilter(this ProductsRequest request)
    {
        return new ProductsFilter
        {
            SortBy       = request.SortBy ?? SortBy.Manual,
            BrandSlug    = request.Brand,
            CategorySlug = request.Category,
            Pagination   = request.Pagination ?? false,
            Page         = request.Page ?? 0,
            PageSize     = request.PageSize ?? 30,
            PriceGte     = request.PriceGte ?? 0,
            PriceLte     = request.PriceLte ?? decimal.MaxValue,
            Availability = request.Availability ?? Availability.All,
            Option       = request.Option?
                                         .Select(ConvertToOptionFilter)
                                         .Where(filter => filter.IsValid)
                                         .ToArray() ?? []
        };
    }
    private static OptionFilter ConvertToOptionFilter(string option)
    {
        var index = option.IndexOf(':');

        if (index <= 0 || index >= option.Length - 1)
        {
            return new OptionFilter();
        }
        return new OptionFilter(
            GroupSlug: option[..index],
            ValueSlug: option[(index + 1)..]);
    }
}