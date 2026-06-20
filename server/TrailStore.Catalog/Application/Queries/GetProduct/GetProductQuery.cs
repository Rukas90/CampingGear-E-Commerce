using TrailStore.Catalog.Application.Contracts;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Catalog.Application.Queries.GetProduct;

public sealed record GetProductQuery(string Slug) : IQuery<ProductDetails>;