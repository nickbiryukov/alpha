using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alpha.Reservation.App.Models.ReservationModels;
using Alpha.Reservation.Data.Repository.Contracts;

namespace Alpha.Reservation.App.Services.Contracts
{
    public interface IReservationService : IRepositoryBase<Data.Entities.Reservation>
    {
        List<Reservation.Data.Entities.Reservation> GetAllWithOrder();
        
        Task<Data.Entities.Reservation> GetWithDetailsAsync(Guid id);

        Task<Reservation.Data.Entities.Reservation> UpdateConfirmationAsync(Guid id, bool confirmation);

        Task<Data.Entities.Reservation> AddReservationAsync(CreateReservationModel reservationModel);

        Task<Data.Entities.Reservation> UpdateReservationAsync(Guid id, ShortReservationModel reservationModel);

        bool IsValidReservationDate(Data.Entities.Reservation reservation);
    }
}