using FastEndpoints;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Api.Extensions;
using TrailStore.Ordering.Api.PreProcessors;
using TrailStore.Ordering.Application.Commands.UpdateContact;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Api.Endpoints.UpdateContact;

public sealed class UpdateContactEndpoint(UpdateContactCommandHandler command)
    : Endpoint<UpdateContactRequest, string>
{
    public override void Configure()
    {
        Patch("/api/v1/checkout/contact");
        AllowAnonymous();
        PreProcessor<RequireCartId<UpdateContactRequest>>();
    }

    public override async Task HandleAsync(UpdateContactRequest req, CancellationToken ct)
    {
        var result = await command.Handle(
            new UpdateContactCommand(
                HttpContext.GetCartId()!.Value, Id<UserRef>.FromNullable(User.GetSubjectId()),
                req.EmailAddress), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        await Send.OkAsync("Success", ct);
    }
}