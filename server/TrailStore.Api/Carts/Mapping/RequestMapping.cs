using TrailStore.Api.Carts.Dto;
using TrailStore.Domain.Carts.Models;

namespace TrailStore.Api.Carts.Mapping;

public static class RequestMapping
{
    public static CartLineItem ToLineItem(this CartItemUpdateRequest request) 
        => new() { Code = request.Code, Quantity = request.Quantity };
}