namespace TrailStore.Api.Auth.Constants;

public static class CsrfConstants
{
    public const string CookieName = "csrf_token";
    public const string HeaderName = "X-Csrf-Token";

    public static readonly string[] SafeMethods = ["GET", "HEAD", "OPTIONS"];
}