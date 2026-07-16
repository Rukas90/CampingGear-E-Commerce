using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Domain.Auth;

public static class AuthProblems
{
    public static readonly Problem InvalidCredentials 
        = new("Invalid Credentials", "auth.invalid_credentials", "Invalid login credentials.");
}