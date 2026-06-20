namespace TrailStore.Identity.Api.Api.Endpoints.Login;

public class LoginRequest
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}