using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Products;

public class ProductProblems
{
    public static Problem NotFoundBySlug(string slug)
        => new("Not Found", "product.not_found", $"Product was not found by slug '{slug}'");
}