using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Domain.Validation;

public record ValidationProblem(
    ValidationState State, string Code) : Problem("Validation Error", Code, "Failed validation.");