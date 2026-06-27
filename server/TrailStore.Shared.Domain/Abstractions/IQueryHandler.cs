using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Domain.Abstractions;

public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    Task<Result<TResponse>> Handle(TQuery query, CancellationToken ct);
}

public interface IQueryWithoutRequestHandler<TResponse>
{
    Task<Result<TResponse>> Handle(CancellationToken ct);
}