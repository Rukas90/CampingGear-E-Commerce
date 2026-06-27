using FastEndpoints;
using TrailStore.Ordering.Api.ShoppingSession;
using TrailStore.Ordering.Application.Commands.InitiateCheckout;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Ordering.Api.Endpoints.InitiateCheckout;

public sealed class InitiateCheckoutEndpoint(InitiateCheckoutCommandHandler command) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/api/v1/checkout");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await command.Handle(new InitiateCheckoutCommand(
            HttpContext.GetShoppingContext(User)), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        await Send.OkAsync("Ok", ct);
    }
}