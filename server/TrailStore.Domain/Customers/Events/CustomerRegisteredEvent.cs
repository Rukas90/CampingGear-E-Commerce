using MediatR;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Customers.Events;

public record CustomerRegisteredEvent(Customer Customer) : INotification;