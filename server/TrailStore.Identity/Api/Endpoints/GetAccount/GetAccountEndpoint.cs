using FastEndpoints;

namespace TrailStore.Identity.Api.Endpoints.Me;

public class GetAccountEndpoint : EndpointWithoutRequest<AccountResponse?>
{
    public override void Configure()
    {
        Get("/api/v1/me");
    }

    public override Task<AccountResponse?> ExecuteAsync(CancellationToken ct)
    {
        return Task.FromResult(User.ToAccountResponse());
    }
}