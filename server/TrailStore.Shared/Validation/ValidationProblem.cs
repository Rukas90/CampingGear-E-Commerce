using TrailStore.Shared.Common;

namespace TrailStore.Shared.Validation;

public record ValidationProblem(
    ValidationFailure[] Failures, string Code) 
    : Problem("Validation Error", Code, "Failed validation.");