namespace TrailStore.Identity.Api.Api.Endpoints.Register;

public class RegisterRequest
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}