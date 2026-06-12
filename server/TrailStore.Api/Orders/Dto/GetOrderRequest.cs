using Microsoft.AspNetCore.Mvc;

namespace TrailStore.Api.Orders.Dto;

public class GetOrderRequest
{
    [FromRoute]
    public string Token { get; init; } = null!;
}