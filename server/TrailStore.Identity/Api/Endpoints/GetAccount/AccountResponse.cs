namespace TrailStore.Identity.Api.Endpoints.GetAccount;

public sealed class AccountResponse
{
    public required Guid Id { get; init; }
    public required string Email { get; init; }
}