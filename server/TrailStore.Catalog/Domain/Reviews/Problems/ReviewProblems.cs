using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Domain.Reviews.Problems;

public static class ReviewProblems
{
    public static readonly Problem ProductNotFound 
        = new("Product not found", "reviews.product_not_found", "Product was not found.");
}