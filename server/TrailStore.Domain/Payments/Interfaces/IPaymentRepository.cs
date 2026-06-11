using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Payments.Interfaces;

public interface IPaymentRepository
{
    Payment Add(Payment payment);
}