using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Products;

public record ProductNotFound() : Error("Product not found");