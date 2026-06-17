using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Domain.RefreshTokens;

public static class RefreshProblems
{
    public static readonly Problem TokenNotFound
        = new("Refresh Token Not Found", "refresh_token.not_found", "Refresh token is not found.");
    
    public static readonly Problem TokenInvalid 
        = new("Invalid Refresh Token", "refresh_token.invalid", "Invalid refresh token.");
    
    public static readonly Problem TokenExpired 
        = new("Refresh Token Expired", "refresh_token.expired", "Refresh token expired.");
    
    public static readonly Problem TokenReuse
        = new("Token Reuse", "refresh_token.reuse", "Refresh token reuse.");
}