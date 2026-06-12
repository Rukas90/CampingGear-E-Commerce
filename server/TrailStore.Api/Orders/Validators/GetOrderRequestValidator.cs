using FastEndpoints;
using FluentValidation;
using TrailStore.Api.Orders.Dto;

namespace TrailStore.Api.Orders.Validators;

public class GetOrderRequestValidator : Validator<GetOrderRequest>
{
    public GetOrderRequestValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty();
    }
}