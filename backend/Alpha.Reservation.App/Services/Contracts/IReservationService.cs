using System;
using System.Threading.Tasks;
using Alpha.Reservation.App.Models.ReservationModels;
using Alpha.Reservation.Data.Repository.Contracts;

namespace Alpha.Reservation.App.Services.Contracts
{
    public interface IReservationService : IRepositoryBase<Data.Entities.Reservation>
    {
        Task<Data.Entities.Reservation> GetWithDetails(Guid id);
        
        Task<Data.Entities.Reservation> AddReservationAsync(CreateReservationModel reservationModel);

        Task<Data.Entities.Reservation> UpdateReservationAsync(Guid id, ShortReservationModel reservationModel);
    }
}