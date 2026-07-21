using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Catalog.Application.Queries.GetCategories;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Catalog.Api.Endpoints.GetCategoryGroups;

public class GetCategoryGroupsEndpoint(GetCategoryGroupsQueryHandler query)
    : EndpointWithoutRequest<IEnumerable<CategoryGroupResponse>>
{
    public override void Configure()
    {
        Get("/api/v1/category/groups");
        AllowAnonymous();
        Options(x => x.CacheOutput(policy => policy
            .Expire(TimeSpan.FromDays(31))
            .Tag("category-groups")));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await query.Handle(ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        var groups = result.Value;
        
        await Send.OkAsync(groups.ToResponses(), ct);
    }
}