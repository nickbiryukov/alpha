using Alpha.Reservation.App.Models.ReservationModels;
using Alpha.Reservation.App.Models.RoomModels;
using Alpha.Reservation.Data.Entities;
using AutoMapper;

namespace Alpha.Reservation.App.MappingProfiles
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<Room, RoomModel>();
            
            CreateMap<RoomModel, Room>();
            
            CreateMap<ShortRoomModel, Room>();

            CreateMap<Room, RoomWithDetailsModel>()
                .ForMember(a => a.ReservationModels, a =>
                    a.MapFrom(b => b.Reservations));
        }
    }
}