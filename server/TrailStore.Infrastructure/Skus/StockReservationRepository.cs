using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.Skus.Interfaces;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Skus;

[AppService<IStockReservationRepository>]
public class StockReservationRepository(AppDbContext context) : IStockReservationRepository
{
    public StockReservation Add(StockReservation reservation)
    {
        context.StockReservations.Add(reservation);

        return reservation;
    }
}