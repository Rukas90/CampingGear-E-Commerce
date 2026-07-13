using FastEndpoints;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Api.Extensions;
using TrailStore.Ordering.Api.PreProcessors;
using TrailStore.Ordering.Application.Commands.InitiateCheckout;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Ordering.Api.Endpoints.InitiateCheckout;

public sealed class InitiateCheckoutEndpoint(InitiateCheckoutCommandHandler command) 
    : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/api/v1/checkout");
        AllowAnonymous();
        PreProcessor<RequireCartId<EmptyRequest>>();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await command.Handle(
            new InitiateCheckoutCommand(
                HttpContext.GetCartId()!.Value, User.GetSubjectTypedId<UserRef>()), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        await Send.OkAsync("Ok", ct);
    }
}