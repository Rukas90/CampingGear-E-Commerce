using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using TrailStore.Inventory.Application.Commands;
using TrailStore.Shared.Api.Filters;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Api.Metadata;

namespace TrailStore.Inventory.Api.Endpoints;

public sealed class RestockEndpoint(RestockItemsCommandHandler command) 
    : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/api/v1/inventory/restock");
        AllowAnonymous();
        Options(builder =>
        {
            builder.WithMetadata(new IgnoreAntiforgery());
            builder.AddEndpointFilter(new ApiKeyEndpointFilter("CronJobs:RestockApiKey"));
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await command.Handle(new RestockItemsCommand(), ct);
        
        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        await Send.OkAsync("Items re-stocked", ct);
    }
}