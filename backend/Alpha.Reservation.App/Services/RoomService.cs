using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpha.Reservation.App.Models.RoomModels;
using Alpha.Reservation.App.Services.Contracts;
using Alpha.Reservation.Data;
using Alpha.Reservation.Data.Entities;
using Alpha.Reservation.Data.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Alpha.Reservation.App.Services
{
    public class RoomService : RepositoryBase<Room, DatabaseContext>, IRoomService
    {
        private readonly DatabaseContext _context;
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        
        public RoomService(DatabaseContext context, IMapper mapper, IReservationService reservationService) 
            : base(context)
        {
            _context = context;
            _mapper = mapper;
            _reservationService = reservationService;
        }

        public async Task<List<Room>> GetWithDetailsAsync()
        {
            var rooms = await _context.Rooms
                .Include(a => a.Reservations)
                .AsNoTracking()
                .ToListAsync();

            rooms.ForEach(a =>
                a.Reservations = a.Reservations
                    .Where(_reservationService.IsValidReservationDate)
                    .OrderBy(b => b.BeginTime)
                    .ThenBy(b => b.BeginTime.TimeOfDay)
                    .ToList()
            );

            return rooms;
        }

        public async Task<Room> GetWithDetailsAsync(Guid id)
        {
            var room =  await _context.Rooms
                .Include(a => a.Reservations)
                .AsNoTracking()
                .SingleOrDefaultAsync(a => a.Id == id);

            room.Reservations = room.Reservations
                .Where(_reservationService.IsValidReservationDate)
                .OrderBy(b => b.BeginTime)
                .ThenBy(b => b.BeginTime.TimeOfDay)
                .ToList();

            return room;
        }

        public async Task<Room> AddRoomAsync(ShortRoomModel roomModel)
        {
            if (await AnyAsync(a => a.Name == roomModel.Name))
                throw new Exception("Room exist");
            
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