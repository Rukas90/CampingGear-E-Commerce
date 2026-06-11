using TrailStore.Domain.Payments.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Payments;

[AppService<IPaymentRepository>]
public class PaymentRepository(AppDbContext context) : IPaymentRepository
{
    public Payment Add(Payment payment)
    {
        context.Payments.Add(payment);
        
        return  payment;
    }
}