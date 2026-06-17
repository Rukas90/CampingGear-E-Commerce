using FastEndpoints;
using TrailStore.Shared.Api.Converters;

namespace TrailStore.Shared.Api.Extensions;

public static class FastEndpointsExtensions
{
    public static void ConfigureAppDefaults(this Config config)
    {
        config.Errors.UseProblemDetails();
        config.Errors.ProducesMetadataType = typeof(ProblemDetails);

        config.Serializer.Options.Converters.Add(new IdJsonConverterFactory());

        config.Errors.ResponseBuilder = (failures, _, statusCode) => new ProblemDetails
        {
            Status = statusCode,
            Errors = failures.Select(f => new ProblemDetails.Error
            {
                Name = f.PropertyName,
                Code = f.ErrorCode,
                Reason = f.ErrorMessage
            }).ToArray()
        };
    }
}