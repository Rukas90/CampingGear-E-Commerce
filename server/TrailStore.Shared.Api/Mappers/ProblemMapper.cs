using FastEndpoints;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Domain.Validation;

namespace TrailStore.Shared.Api.Mappers;

public delegate int StatusCodeExtractCallback(string code);

public static class ProblemMapper
{
    public static Task SendProblemAsync(this BaseEndpoint endpoint, Problem problem, StatusCodeExtractCallback? statusCodeExtract = null)
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
        
        var status = statusCodeExtract?.Invoke(problem.Code) ?? 400;

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
}