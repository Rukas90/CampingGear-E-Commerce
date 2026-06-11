using TrailStore.Shared.Common;

namespace TrailStore.Shared.Validation;

public record ValidationProblem(
    ValidationState State, string Code) : Problem("Validation Error", Code, "Failed validation.");