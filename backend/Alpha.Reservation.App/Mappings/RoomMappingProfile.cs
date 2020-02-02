using Alpha.Reservation.App.Models.RoomModels;
using Alpha.Reservation.Data.Entities;
using AutoMapper;

namespace Alpha.Reservation.App.Mappings
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<Room, RoomModel>();
            
            CreateMap<RoomModel, Room>();
            
            CreateMap<ShortRoomModel, Room>();
        }
    }
}