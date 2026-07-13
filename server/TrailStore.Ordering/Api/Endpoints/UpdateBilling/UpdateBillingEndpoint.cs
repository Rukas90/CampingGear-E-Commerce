using FastEndpoints;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Api.Common.PostalAddress;
using TrailStore.Ordering.Api.Extensions;
using TrailStore.Ordering.Api.PreProcessors;
using TrailStore.Ordering.Application.Commands.UpdateBilling;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Api.Endpoints.UpdateBilling;

public sealed class UpdateBillingEndpoint(UpdateBillingCommandHandler command)
    : Endpoint<UpdateBillingRequest, string>
{
    public override void Configure()
    {
        Patch("/api/v1/checkout/billing");
        AllowAnonymous();
        PreProcessor<RequireCartId<UpdateBillingRequest>>();
    }
    
    public override async Task HandleAsync(UpdateBillingRequest req, CancellationToken ct)
    {
        var result = await command.Handle(
            new UpdateBillingCommand(HttpContext.GetCartId()!.Value, Id<UserRef>.FromNullable(User.GetSubjectId()),
                new CheckoutBilling
                {
                    AsShippingAddress = req.AsShippingAddress ?? true,
                    Address = req.Address is not null 
                        ? new BillingAddress(req.Address.ToPostalAddress()) 
                        : null
                }), 
            ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        await Send.OkAsync("Success", ct);
    }
}