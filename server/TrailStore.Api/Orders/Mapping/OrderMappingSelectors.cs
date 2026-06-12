using System.Linq.Expressions;
using TrailStore.Api.Orders.Dto;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Api.Orders.Mapping;

public static class OrderMappingSelectors
{
    public static Expression<Func<Order, OrderDto>> ToDto()
        => order => new OrderDto
        {
            Token = order.Token,
            Subtotal = order.Items.Sum(item => item.UnitPrice * item.Quantity),
            TaxAmount = order.TaxAmount,
            TotalPrice = order.TotalPrice,
            Items = order.Items.Select(item => new OrderItemDto
            {
                SkuCode = item.Sku.Code,
                ProductName = item.Sku.Product.Name,
                VariantLine = string.Join(", ", item.Sku.Options.Select(option => option.Name)),
                ImageUrl = item.Sku.Product.ThumbnailUrl,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            })
        };
}