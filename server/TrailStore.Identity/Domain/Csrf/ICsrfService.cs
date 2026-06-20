namespace TrailStore.Identity.Api.Domain.Csrf;

public interface ICsrfService
{
    public string GenerateToken();

    public bool VerifyToken(string token);
}