using FastEndpoints;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Common.Extensions;

public static class ProblemMapper
{
    public static Task SendProblemAsync(this BaseEndpoint endpoint, Problem problem)
    {
        var status = problem.Code switch
        {
            var code when code.StartsWith("auth.") => GetAuthStatus(code),
            _ => 400
        };

        return new ProblemDetails
        {
            Status = status,
            Errors =
            [
                new ProblemDetails.Error
                {
                    Name = problem.Title,
                    Code = problem.Code,
                    Reason = problem.Reason
                }
            ]
        }.ExecuteAsync(endpoint.HttpContext);
    }

    private static int GetAuthStatus(string code)
    {
        return code switch
        {
            "auth.email_already_taken" => 409,
            "auth.invalid_credentials" => 401,
            "auth.refresh_token_invalid" => 401,
            "auth.refresh_token_reused" => 401,
            "auth.refresh_token_expired" => 401,
            "auth.refresh_token_not_found" => 404,
            _ => 400
        };
    }
}