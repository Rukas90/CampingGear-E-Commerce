using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Api.Domain.Auth;

public static class AuthProblems
{
    public static readonly Problem InvalidCredentials 
        = new("Invalid Credentials", "auth.invalid_credentials", "Invalid login credentials.");
    
    public static readonly Problem Unauthenticated =
        new("Unauthenticated", "auth.unauthenticated", "You are not authenticated.");
}