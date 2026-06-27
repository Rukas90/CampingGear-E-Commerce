using FastEndpoints;
using TrailStore.Ordering.Api.ShoppingSession;
using TrailStore.Ordering.Application.Commands.UpdateContact;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Ordering.Api.Endpoints.UpdateContact;

public sealed class UpdateContactEndpoint(UpdateContactCommandHandler command)
    : Endpoint<UpdateContactRequest, string>
{
    public override void Configure()
    {
        Patch("/api/v1/checkout/contact");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateContactRequest req, CancellationToken ct)
    {
        var result = await command.Handle(
            new UpdateContactCommand(
                HttpContext.GetShoppingContext(User), 
                new CheckoutContact
                {
                    EmailAddress = req.EmailAddress,
                }), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        await Send.OkAsync("Success", ct);
    }
}