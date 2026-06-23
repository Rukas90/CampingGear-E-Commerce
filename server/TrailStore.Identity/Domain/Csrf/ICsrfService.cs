namespace TrailStore.Identity.Domain.Csrf;

public interface ICsrfService
{
    public string GenerateToken();

    public bool VerifyToken(string token);
}