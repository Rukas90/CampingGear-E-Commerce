using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Options;

public static class OptionSpecifications
{
    public static Specification<OptionGroup> Category(string slug)
        => Specification<OptionGroup>.Where(group => 
            group.Options.Any(o => 
                o.Skus.Any(sku => sku.Product.Category.Slug == slug)));
}