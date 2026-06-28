using TrailStore.Ordering.Application.Results;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Ordering.Application.Queries.GetShippingMethods;

public sealed record GetShippingMethodsQuery(string CountryCode) : IQuery<ShippingMethodResult[]>;