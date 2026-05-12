using TrailStore.Shared.Common;

namespace TrailStore.Domain.Auth.Errors;

public static class AuthProblems
{
    public static readonly Problem EmailAlreadyTaken
        = new("Email Already Taken", "auth.email_already_taken", "Email already taken.");

    public static readonly Problem InvalidCredentials =
        new("Invalid Credentials", "auth.invalid_credentials", "Invalid email or password.");

    public static readonly Problem RefreshTokenInvalid =
        new("Invalid Refresh Token", "auth.refresh_token_invalid", "Invalid refresh token.");

    public static readonly Problem RefreshTokenReused =
        new("Refresh Token Reused", "auth.refresh_token_reused", "Refresh token reused.");

    public static readonly Problem RefreshTokenExpired =
        new("Refresh Token Expired", "auth.refresh_token_expired", "Refresh token expired.");

    public static readonly Problem RefreshTokenNotFound =
        new("Refresh Token Not Found", "auth.refresh_token_not_found", "Refresh token not found.");

    public static readonly Problem Unauthenticated =
        new("Unauthenticated", "auth.unauthenticated", "You are not authenticated.");
}