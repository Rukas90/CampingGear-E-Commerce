using TrailStore.Shared.Common;

namespace TrailStore.Domain.Products.Errors;

public class ProductProblems
{
    public static Problem NotFoundBySlug(string slug)
        => new("Not Found", "product.not_found", $"Product was not found by slug '{slug}'");
}