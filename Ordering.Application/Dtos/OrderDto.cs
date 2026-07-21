using Ordering.Domain.Enums;
using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Dtos;

public record OrderDto
(
    Guid Id,
    Guid CustomerId,
    string OrderName,
    AddressDto ShippingAddress,
    Address BillingAddress,
    Payment Payment,
    OrderStatus Status,
    List<OrderItemDto> OrderItems
);