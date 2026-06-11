using FastEndpoints;
using TrailStore.Shared.Common;
using TrailStore.Shared.Validation;

namespace TrailStore.Api.Common.Mapping;

public static class ProblemMapper
{
    public static Task SendProblemAsync(this BaseEndpoint endpoint, Problem problem)
    {
        if (problem is ValidationProblem validationProblem)
        {
            return new ProblemDetails
            {
                Status = 400,
                Detail = problem.Reason,
                Errors = validationProblem.State.Map(failure => new ProblemDetails.Error
                {
                    Name = failure.Field,
                    Code = "validation",
                    Reason = failure.Message
                })
            }.ExecuteAsync(endpoint.HttpContext);
        }
        
        var status = problem.Code switch
        {
            var code when code.StartsWith("auth.") => GetAuthStatus(code),
            var code when code.StartsWith("product.") => GetProductStatus(code),
            var code when code.StartsWith("checkout.") => GetCheckoutStatus(code),
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
    
    private static int GetProductStatus(string code)
    {
        return code switch
        {
            "product.not_found" => 404,
            _ => 400
        };
    }
    
    private static int GetCheckoutStatus(string code)
    {
        return code switch
        {
            "checkout.invalid_sku_codes" => 422,
            "checkout.payment_provider_error" => 502,
            _ => 400
        };
    }
}