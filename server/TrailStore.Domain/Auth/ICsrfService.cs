namespace TrailStore.Domain.Auth;

public interface ICsrfService
{
    public string GenerateToken();
    
    public bool VerifyToken(string token);
}