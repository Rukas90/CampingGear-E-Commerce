using FastEndpoints;
using TrailStore.Api.Account.Extensions;
using TrailStore.Api.Auth.Dto;

namespace TrailStore.Api.Account.Endpoints;

public class GetAccountEndpoint : EndpointWithoutRequest<AccountDto?>
{
    public override void Configure()
    {
        Get("/api/v1/me");
    }

    public override Task<AccountDto?> ExecuteAsync(CancellationToken ct)
    {
        return Task.FromResult(User.ToAccountDto());
    }
}