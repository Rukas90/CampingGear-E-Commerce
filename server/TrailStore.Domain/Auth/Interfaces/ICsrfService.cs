namespace TrailStore.Domain.Auth.Interfaces;

public interface ICsrfService
{
    public string GenerateToken();

    public bool VerifyToken(string token);
}