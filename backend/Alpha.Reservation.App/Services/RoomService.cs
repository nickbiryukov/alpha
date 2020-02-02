using System;
using System.Threading.Tasks;
using Alpha.Reservation.App.Models.RoomModels;
using Alpha.Reservation.App.Services.Contracts;
using Alpha.Reservation.Data;
using Alpha.Reservation.Data.Entities;
using Alpha.Reservation.Data.Repository;
using AutoMapper;

namespace Alpha.Reservation.App.Services
{
    public class RoomService : RepositoryBase<Room, DatabaseContext>, IRoomService
    {
        private readonly IMapper _mapper;
        
        public RoomService(DatabaseContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<Room> AddRoomAsync(ShortRoomModel roomModel)
        {
            var room = _mapper.Map<Room>(roomModel);
            return await AddAsync(room);
        }

        public async Task<Room> UpdateRoomAsync(Guid id, ShortRoomModel roomModel)
        {
            var room = await GetAsync(id);

            room.Name = roomModel.Name;
            room.Description = roomModel.Description;
            room.Projector = roomModel.Projector;
            room.Board= roomModel.Board;
            room.Seat = roomModel.Seat;
            
            return await UpdateAsync(room);
        }
    }
}