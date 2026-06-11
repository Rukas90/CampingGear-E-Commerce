using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Skus.Interfaces;

public interface IStockReservationRepository
{
    StockReservation Add(StockReservation reservation);
}