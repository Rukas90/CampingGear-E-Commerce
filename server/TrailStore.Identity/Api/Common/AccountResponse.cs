namespace TrailStore.Identity.Api.Common;

public sealed class AccountResponse
{
    public required Guid Id { get; init; }
    public required string Email { get; init; }
}