using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alpha.Reservation.App.Models.RoomModels;
using Alpha.Reservation.Data.Entities;
using Alpha.Reservation.Data.Repository.Contracts;

namespace Alpha.Reservation.App.Services.Contracts
{
    public interface IRoomService : IRepositoryBase<Room>
    {
        Task<List<Room>> GetWithDetailsAsync();

        Task<Room> GetWithDetailsAsync(Guid id);
    
        Task<Room> AddRoomAsync(ShortRoomModel roomModel);

        Task<Room> UpdateRoomAsync(Guid id, ShortRoomModel roomModel);
    }
}