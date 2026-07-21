using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Catalog.Application.Queries.GetCategories;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Catalog.Api.Endpoints.GetCategories;

public sealed class GetCategoriesEndpoints(GetAllCategoriesQueryHandler query)
    : EndpointWithoutRequest<CategoryResponse[]>
{
    public override void Configure()
    {
        Get("/api/v1/categories");
        AllowAnonymous();
        ResponseCache(durationSeconds: 3600, location: ResponseCacheLocation.Any);
        Options(x => x.CacheOutput(policy => policy
            .Expire(TimeSpan.FromDays(31))
            .Tag("categories")));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await query.Handle(ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);

            return;
        }

        var categories = result.Value;

        await Send.OkAsync(categories.ToResponses(), ct);
    }
}