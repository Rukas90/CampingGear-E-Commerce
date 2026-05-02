using MediatR;
using TrailStore.Domain.Models;

namespace TrailStore.Domain.Customers;

public record CustomerRegisteredEvent(Customer Customer) : INotification;