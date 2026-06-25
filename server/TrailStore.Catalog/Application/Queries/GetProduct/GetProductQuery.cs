using TrailStore.Catalog.Application.Results;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Catalog.Application.Queries.GetProduct;

public sealed record GetProductQuery(string Slug) : IQuery<ProductDetailsResult>;